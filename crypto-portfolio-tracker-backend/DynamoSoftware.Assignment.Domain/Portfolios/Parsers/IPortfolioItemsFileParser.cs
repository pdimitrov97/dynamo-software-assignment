using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.Domain.Portfolios.Parsers
{
	public interface IPortfolioItemsFileParser
	{
		Task<IEnumerable<IPortfolioItemSimple>> ParseFile(Stream fileStream);

		IPortfolioItemSimple ParsePortfolioItem(string portfolioItemLine);
	}
}