using DynamoSoftware.Assignment.Domain;
using System.Collections.Generic;

namespace DynamoSoftware.Assignment.UnitTests.Factories
{
	internal class TestPortfolioDataHolder : IPortfolio
	{
		public IEnumerable<IPortfolioItem> Items { get; init; }

		public double InitialValue { get; init; }

		public double CurrentValue { get; init; }

		public double OverallChangeValue { get; init; }

		public double OverallChangePercentage { get; init; }
	}
}