using DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser;
using DynamoSoftware.Assignment.UnitTests.Factories;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using NUnit.Framework;
using System.Linq;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioServiceTests
{
	internal class PortfolioService_Parse_Should : BasePortfolioServiceTest
	{
		[Test]
		public void PortfolioService_Parse_ParseInvalidCoin()
		{
			// Arrange
			var fileStream = ModelFactory.CreateFileStreamFromString(TestModels.InvalidCoinFileTest);

			// Act
			var (result, ex) = ExceptionHelpers.Catch<PortfolioItemParseException>(async () => { await this.PortfolioService.ParsePortfolioAsync(fileStream); }).Result;

			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("coinToken"));
		}

		[Test]
		public void PortfolioService_Parse_ParseInvalidAmount()
		{
			// Arrange
			var fileStream = ModelFactory.CreateFileStreamFromString(TestModels.InvalidAmountFileTest);

			// Act
			var (result, ex) = ExceptionHelpers.Catch<PortfolioItemParseException>(async () => { await this.PortfolioService.ParsePortfolioAsync(fileStream); }).Result;

			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("amountToken"));
		}

		[Test]
		public void PortfolioService_Parse_ParseInvalidBuyPrice()
		{
			// Arrange
			var fileStream = ModelFactory.CreateFileStreamFromString(TestModels.InvalidBuyPriceFileTest);

			// Act
			var (result, ex) = ExceptionHelpers.Catch<PortfolioItemParseException>(async () => { await this.PortfolioService.ParsePortfolioAsync(fileStream); }).Result;

			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("buyPriceToken"));
		}

		[Test]
		public void PortfolioService_Parse_ParseInvalidToken()
		{
			// Arrange
			var fileStream = ModelFactory.CreateFileStreamFromString(TestModels.InvalidTokenFileTest);

			// Act
			var (result, ex) = ExceptionHelpers.Catch<PortfolioItemParseException>(async () => { await this.PortfolioService.ParsePortfolioAsync(fileStream); }).Result;

			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("portfolioItemLine"));
		}

		[Test]
		public void PortfolioService_Parse_ParseSimple()
		{
			// Arrange
			var fileStream = ModelFactory.CreateFileStreamFromString(TestModels.FileTest);

			// Act
			var portfolio = this.PortfolioService.ParsePortfolioAsync(fileStream).Result;

			// Assert
			Assert.That(portfolio, Is.Not.Null);
			Assert.That(portfolio.Items.Count(), Is.EqualTo(4));
			Assert.That(portfolio.InitialValue, Is.EqualTo(ValueTestModels.PortfolioValueTest.InitialValue).Within(TestConstants.PricePrecision));
		}
	}
}