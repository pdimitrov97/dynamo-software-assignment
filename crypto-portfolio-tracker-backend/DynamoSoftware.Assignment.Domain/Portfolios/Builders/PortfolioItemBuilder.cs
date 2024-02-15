using System;

namespace DynamoSoftware.Assignment.Domain.Portfolios.Builders
{
	internal sealed class PortfolioItemBuilder : PortfolioItemSimpleBuilder
	{
		private double currentPrice;

		public IPortfolioItem Build()
		{
			return new PortfolioItem(this.coin, this.amount, this.buyPrice, this.currentPrice);
		}

		public PortfolioItemBuilder WithCoinName(string coin)
		{
			base.CoinName(coin);
			return this;
		}

		public PortfolioItemBuilder WithAmount(double amount)
		{
			base.Amount(amount);
			return this;
		}

		public PortfolioItemBuilder WithBuyPrice(double buyPrice)
		{
			base.BuyPrice(buyPrice);
			return this;
		}

		public PortfolioItemBuilder WithSimplePortfolioItem(IPortfolioItemSimple portfolioItem)
		{
			base.CoinName(portfolioItem.Coin);
			base.Amount(portfolioItem.Amount);
			base.BuyPrice(portfolioItem.BuyPrice);
			return this;
		}

		public PortfolioItemBuilder WithCurrentPrice(double currentPrice)
		{
			if (currentPrice < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(currentPrice));
			}

			this.currentPrice = currentPrice;
			return this;
		}
	}
}