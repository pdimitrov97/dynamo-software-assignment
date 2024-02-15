using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.Domain.Portfolios.Builders;
using DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser;
using System.IO;
using System.Text;

namespace DynamoSoftware.Assignment.UnitTests.Factories
{
	internal class ModelFactory
	{
		public static PortfolioItemsFileParser CreateFileParser()
		{
			return new PortfolioItemsFileParser();
		}

		public static PortfolioItemBuilder CreatePortfolioItemBuilder()
		{
			return new PortfolioItemBuilder();
		}

		public static PortfolioBuilder CreatePortfolioBuilder()
		{
			return new PortfolioBuilder();
		}

		public static Stream CreateFileStreamFromString(string fileContent)
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
		}

		public static string CreatePortfolioItemLine(string coin, double amount, double buyPrice)
		{
			return $"{amount}{PortfolioConstants.FileDelimiter}{coin}{PortfolioConstants.FileDelimiter}{buyPrice}";
		}
	}
}