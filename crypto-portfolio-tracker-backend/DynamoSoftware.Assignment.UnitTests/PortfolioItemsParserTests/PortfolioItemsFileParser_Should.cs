using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser;
using DynamoSoftware.Assignment.UnitTests.Factories;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioItemsParserTests
{
	internal class PortfolioItemsFileParser_Should : BasePortfolioItemsFileParserTest 
	{
		[Test]
		public void ParsePortfolioItem_Invalid()
		{
			// Arrange
			var testData = TestModels.InvalidPortfolioItem;

			// Act
			var result = ExceptionHelpers.Catch(() => this.Parser.ParsePortfolioItem(testData), out PortfolioItemParseException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("portfolioItemLine"));
		}

		[Test]
		public void ParsePortfolioItem_Valid()
		{
			// Arrange
			var testData = TestModels.TestPortfolioLineValid;

			// Act
			var result = this.Parser.ParsePortfolioItem(testData);

			// Assert
			Assert.That(result.Coin, Is.EqualTo(TestModels.TestCoin));
			Assert.That(result.Amount, Is.EqualTo(TestModels.TestAmount).Within(TestConstants.AmountPrecision));
			Assert.That(result.BuyPrice, Is.EqualTo(TestModels.TestBuyPrice).Within(TestConstants.PricePrecision));
		}

		[Test]
		public void ParsePortfolioItem_InvalidCoinName()
		{
			// Arrange
			var testData = TestModels.TestPortfolioLineInvalidCoin;

			// Act
			var result = ExceptionHelpers.Catch(() => this.Parser.ParsePortfolioItem(testData), out PortfolioItemParseException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("coinToken"));
		}

		[Test]
		public void ParsePortfolioItem_InvalidAmount()
		{
			// Arrange
			var testData = TestModels.TestPortfolioLineInvalidAmount;

			// Act
			var result = ExceptionHelpers.Catch(() => this.Parser.ParsePortfolioItem(testData), out ArgumentOutOfRangeException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("amount"));
		}

		[Test]
		public void ParsePortfolioItem_InvalidBuyPrice()
		{
			// Arrange
			var testData = TestModels.TestPortfolioLineInvalidBuyPrice;

			// Act
			var result = ExceptionHelpers.Catch(() => this.Parser.ParsePortfolioItem(testData), out ArgumentOutOfRangeException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("buyPrice"));
		}
	}
}