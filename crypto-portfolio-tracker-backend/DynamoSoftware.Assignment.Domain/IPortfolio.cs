using System.Collections.Generic;

namespace DynamoSoftware.Assignment.Domain
{
    public interface IPortfolio
	{
		IEnumerable<IPortfolioItem> Items { get; }

		double InitialValue { get; }

		double CurrentValue { get; }

		double OverallChangeValue { get; }

		double OverallChangePercentage { get; }
	}
}