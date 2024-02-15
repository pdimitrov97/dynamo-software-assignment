using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.Domain.Cryptocurrency.CoinLoreCryptocurrency
{
	public sealed class CoinLoreCryptocurrencyTracker : ICryptocurrencyTracker
	{
		private const string CacheKeyPrefix = "SymbolSearch";
		private const int SearchPageSize = 100;
		private const int HoursToCacheSymbolIds = 1;

		private readonly IHttpClientFactory httpClientFactory;
		private readonly IMemoryCache memoryCache;
		private readonly IOptions<CoinLoreCryptocurrencyTrackerSettings> settings;

		public CoinLoreCryptocurrencyTracker(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache, IOptions<CoinLoreCryptocurrencyTrackerSettings> settings)
		{
			this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
			this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
			this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
		}

		public async Task<IEnumerable<ICryptocurrencyItem>> GetCryptocurrencies(string[] symbols)
		{
			// First fetch the ticker IDs since CoinLore does not have API for searching by Symbol
			var tickerIds = await this.GetTickerIdsAsync(symbols);

			using (var httpClient = this.httpClientFactory.CreateClient())
			{
				var url = $"{this.settings.Value.ApiUrl}/ticker/?id={string.Join(",", tickerIds)}";

				var response = await httpClient.GetAsync(url);
				var responseText = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					throw new Exception(responseText);
				}

				var items = JsonConvert.DeserializeObject<CoinLoreCryptocurrencyTickerResponse>(responseText);
				var result = items.Select(x => x.ToCryptocurrencyItem());

				return result;
			}
		}

		private async Task<IEnumerable<int>> GetTickerIdsAsync(string[] symbols)
		{
			// Get cached ticker IDs to reduce the number of requests to the API
			var (cachedTickerIds, nonCachedSymbolsToSearch) = GetCachedAndNonCachedSymbolIds(symbols);
			var tickerIds = cachedTickerIds.ToList();
			var symbolsToSearch = nonCachedSymbolsToSearch.ToList();

			// Only if there are symbols that are not cached, search for the symbols
			if (symbolsToSearch.Count > 0)
			{
				using (var httpClient = this.httpClientFactory.CreateClient())
				{
					var start = 0;
					var limit = SearchPageSize;
					var coinsNum = 0;

					do
					{
						var url = $"{this.settings.Value.ApiUrl}/tickers/?start={start}&limit={limit}";
						var responseMessage = await httpClient.GetAsync(url);
						var responseText = await responseMessage.Content.ReadAsStringAsync();

						if (!responseMessage.IsSuccessStatusCode)
						{
							throw new Exception(responseText);
						}

						var response = JsonConvert.DeserializeObject<CoinLoreCryptocurrencyTickersResponse>(responseText);
						coinsNum = response.Info?.Coins_Num ?? 0;
						start = start + SearchPageSize;

						foreach (var symbol in symbolsToSearch.ToList())
						{
							var symbolInResponse = response.Data?.FirstOrDefault(x => x.Symbol == symbol);

							if (symbolInResponse != null)
							{
								symbolsToSearch.Remove(symbol);
								tickerIds.Add(symbolInResponse.Id);
								this.StoreSymbolIdInCache(symbol, symbolInResponse.Id);
							}
						}
					}
					while (symbolsToSearch.Count > 0 && coinsNum > start);
				}
			}

			return tickerIds;
		}

		private (IEnumerable<int>, IEnumerable<string>) GetCachedAndNonCachedSymbolIds(string[] symbols)
		{
			var cachedSymbolIds = new List<int>();
			var nonCachedSymbols = new List<string>();

			foreach (var symbol in symbols)
			{
				if (this.memoryCache.TryGetValue(GetSymbolCacheKey(symbol), out int symbolId))
				{
					cachedSymbolIds.Add(symbolId);
				}
				else
				{
					nonCachedSymbols.Add(symbol);
				}
			}

			return (cachedSymbolIds, nonCachedSymbols);
		}

		private void StoreSymbolIdInCache(string symbol, int symbolId)
		{
			var options = new MemoryCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(HoursToCacheSymbolIds)
			};

			this.memoryCache.Set(GetSymbolCacheKey(symbol), symbolId, options);
		}

		private static string GetSymbolCacheKey(string symbol)
		{
			return $"{CacheKeyPrefix}-{symbol}";
		}
	}
}