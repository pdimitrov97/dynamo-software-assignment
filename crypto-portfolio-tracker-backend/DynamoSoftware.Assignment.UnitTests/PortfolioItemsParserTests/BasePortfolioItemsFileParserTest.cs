using DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser;
using DynamoSoftware.Assignment.UnitTests.Factories;
using NUnit.Framework;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioItemsParserTests
{
	internal abstract class BasePortfolioItemsFileParserTest
	{
		protected PortfolioItemsFileParser Parser { get; set; }

		[SetUp]
		public void Setup()
		{
			this.Parser = ModelFactory.CreateFileParser();
		}
	}
}