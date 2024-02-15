namespace DynamoSoftware.Assignment.Domain
{
	public interface IPortfolioItemSimple
	{
		string Coin { get; }

		double Amount { get; }

		double BuyPrice { get; }
	}
}