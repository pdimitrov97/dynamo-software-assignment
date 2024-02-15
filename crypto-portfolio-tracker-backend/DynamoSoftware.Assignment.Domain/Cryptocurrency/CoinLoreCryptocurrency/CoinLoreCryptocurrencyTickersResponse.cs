using System.Collections.Generic;

namespace DynamoSoftware.Assignment.Domain.Cryptocurrency.CoinLoreCryptocurrency
{
	internal sealed class CoinLoreCryptocurrencyTickersResponse
	{
		public IEnumerable<CoinLoreCryptocurrencyItem> Data { get; set; }

		public CoinLoreCryptocurrencyTickersInfo Info { get; set; }
	}
}