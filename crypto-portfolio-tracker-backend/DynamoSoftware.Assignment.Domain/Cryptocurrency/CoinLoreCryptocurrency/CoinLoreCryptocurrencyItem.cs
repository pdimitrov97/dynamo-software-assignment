namespace DynamoSoftware.Assignment.Domain.Cryptocurrency.CoinLoreCryptocurrency
{
	internal sealed class CoinLoreCryptocurrencyItem
	{
		public int Id { get; set; }

		public string Symbol { get; set; }

		public double Price_Usd { get; set; }

		public CryptocurrencyItem ToCryptocurrencyItem()
		{
			return new CryptocurrencyItem(this.Symbol, this.Price_Usd);
		}
	}
}