using DynamoSoftware.Assignment.Domain.Cryptocurrency;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoSoftware.Assignment.Domain.Portfolios.Builders
{
	internal sealed class PortfolioBuilder
	{
		private IEnumerable<IPortfolioItemSimple> simplePortfolioItems;
		private IEnumerable<ICryptocurrencyItem> cryptocurrencies;

        public PortfolioBuilder()
        {
            this.simplePortfolioItems = Enumerable.Empty<IPortfolioItemSimple>();
			this.cryptocurrencies = Enumerable.Empty<ICryptocurrencyItem>();
        }

        public IPortfolio BuildPortfolio()
		{
			var portfolioItems = new List<IPortfolioItem>();

			foreach (var simplePortfolioItem in this.simplePortfolioItems)
			{
				var cryptocurrency = this.cryptocurrencies.FirstOrDefault(x => x.Symbol == simplePortfolioItem.Coin);
				var portfolioItem = new PortfolioItemBuilder()
					.WithSimplePortfolioItem(simplePortfolioItem)
					.WithCurrentPrice(cryptocurrency?.Price ?? 0)
					.Build();

				portfolioItems.Add(portfolioItem);
			}

			return new Portfolio(portfolioItems);
		}

		public PortfolioBuilder WithSimplePortfolioItems(IEnumerable<IPortfolioItemSimple> simplePortfolioItems)
		{
			if (simplePortfolioItems == null)
			{
				throw new ArgumentNullException(nameof(simplePortfolioItems));
			}

			this.simplePortfolioItems = simplePortfolioItems;
			return this;
		}

		public PortfolioBuilder WithLatestCryptocurrencyValues(IEnumerable<ICryptocurrencyItem> cryptocurrencies)
		{
			if (cryptocurrencies == null)
			{
				throw new ArgumentNullException(nameof(cryptocurrencies));
			}

			this.cryptocurrencies = cryptocurrencies;
			return this;
		}
	}
}