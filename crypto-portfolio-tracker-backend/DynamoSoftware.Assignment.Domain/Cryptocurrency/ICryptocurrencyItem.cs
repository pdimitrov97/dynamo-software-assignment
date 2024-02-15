namespace DynamoSoftware.Assignment.Domain.Cryptocurrency
{
	public interface ICryptocurrencyItem
	{
		string Symbol { get; }

		double Price { get; }
	}
}