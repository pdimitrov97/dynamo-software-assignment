using System.IO;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.Domain
{
    public interface IPortfolioService
	{
		Task<IPortfolio> ParsePortfolioAsync(Stream portfolioFileStream);

		Task<IPortfolio> ParseAndCalculatePortfolioValueAsync(Stream portfolioFileStream);
	}
}