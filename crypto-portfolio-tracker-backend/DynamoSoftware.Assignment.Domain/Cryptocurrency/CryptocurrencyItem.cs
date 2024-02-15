using System;

namespace DynamoSoftware.Assignment.Domain.Cryptocurrency
{
	internal sealed class CryptocurrencyItem : ICryptocurrencyItem
	{
		public CryptocurrencyItem(string symbol, double price)
		{
			if (string.IsNullOrEmpty(symbol))
			{
				throw new ArgumentException(nameof(symbol));
			}

			if (price < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(price));
			}

			this.Symbol = symbol;
			this.Price = price;
		}

		public string Symbol { get; }

		public double Price { get; }
	}
}