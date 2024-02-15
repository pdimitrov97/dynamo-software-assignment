namespace DynamoSoftware.Assignment.Domain
{
	public interface IPortfolioItem : IPortfolioItemSimple
	{
		double CurrentPrice { get; }

		double InitialValue { get; }

		double CurrentValue { get; }

		double ChangeValue { get; }

		double ChangePercentage { get; }
	}
}