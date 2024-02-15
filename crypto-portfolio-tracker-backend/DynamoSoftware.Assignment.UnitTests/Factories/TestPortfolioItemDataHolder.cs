using DynamoSoftware.Assignment.Domain;

namespace DynamoSoftware.Assignment.UnitTests.Factories
{
	internal class TestPortfolioItemDataHolder : IPortfolioItem
	{
		public string Coin { get; init; }

		public double Amount { get; init; }

		public double BuyPrice { get; init; }

		public double CurrentPrice { get; init; }

		public double InitialValue { get; init; }

		public double CurrentValue { get; init; }

		public double ChangeValue { get; init; }

		public double ChangePercentage { get; init; }
	}
}