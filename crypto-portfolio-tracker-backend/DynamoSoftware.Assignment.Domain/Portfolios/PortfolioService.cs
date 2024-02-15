using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamoSoftware.Assignment.Domain.Cryptocurrency;
using DynamoSoftware.Assignment.Domain.Portfolios.Builders;
using DynamoSoftware.Assignment.Domain.Portfolios.Parsers;
using Microsoft.Extensions.Logging;

namespace DynamoSoftware.Assignment.Domain.Portfolios
{
	public sealed class PortfolioService : IPortfolioService
    {
		private readonly IPortfolioItemsFileParser parser;
		private readonly ICryptocurrencyTracker cryptocurrencyTracker;
		private readonly ILogger<PortfolioService> logger;

		public PortfolioService(IPortfolioItemsFileParser parser, ICryptocurrencyTracker cryptocurrencyTracker, ILogger<PortfolioService> logger)
        {
			this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
			this.cryptocurrencyTracker = cryptocurrencyTracker ?? throw new ArgumentNullException(nameof(cryptocurrencyTracker));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

        public async Task<IPortfolio> ParsePortfolioAsync(Stream portfolioFileStream)
        {
            var portfolioItems = await this.ParsePortfolioItemsAsync(portfolioFileStream);
			var portfolio = this.CreatePortfolio(portfolioItems, Enumerable.Empty<ICryptocurrencyItem>());
            return portfolio;
        }

        public async Task<IPortfolio> ParseAndCalculatePortfolioValueAsync(Stream portfolioFileStream)
        {
			var portfolioItems = await this.ParsePortfolioItemsAsync(portfolioFileStream);
            var cryptocurrencies = await this.GetCryptocurrencyItemsAsync(portfolioItems);
			var portfolio = this.CreatePortfolio(portfolioItems, cryptocurrencies);
			return portfolio;
		}

        private async Task<IEnumerable<IPortfolioItemSimple>> ParsePortfolioItemsAsync(Stream portfolioFileStream)
        {
			this.logger.LogInformation("User requested parsing portfolio file");

			var portfolioItems = await this.parser.ParseFile(portfolioFileStream);
            return portfolioItems;
		}

        private async Task<IEnumerable<ICryptocurrencyItem>> GetCryptocurrencyItemsAsync(IEnumerable<IPortfolioItemSimple> portfolioItems)
        {
			this.logger.LogInformation("User requested checking current cryptocurrencies values");

			var symbolsToSearch = portfolioItems.Select(x => x.Coin).ToArray();
			var cryptocurrencies = await cryptocurrencyTracker.GetCryptocurrencies(symbolsToSearch);
            return cryptocurrencies;
		}

        private IPortfolio CreatePortfolio(IEnumerable<IPortfolioItemSimple> portfolioItems, IEnumerable<ICryptocurrencyItem> cryptocurrencies)
        {
			this.logger.LogInformation("User requested creating a portfolio");

			var portfolio = new PortfolioBuilder()
				.WithSimplePortfolioItems(portfolioItems)
				.WithLatestCryptocurrencyValues(cryptocurrencies)
				.BuildPortfolio();

			return portfolio;
		}
	}
}