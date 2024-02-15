using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.UnitTests.Factories;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using NUnit.Framework;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioItemTests
{
	internal class PortfolioItemValue_Should
	{
		public static readonly TestPortfolioItemDataHolder[] ValueTests = ValueTestModels.PortfolioItemsValueTests;

		[Test]
		[TestCaseSource(nameof(ValueTests))]
		public void PortfolioItemValue_ValueCalculation(TestPortfolioItemDataHolder testPortfolio)
		{
			// Arrange
			var builder = ModelFactory.CreatePortfolioItemBuilder();
			var portfolioItem = builder.WithCoinName(testPortfolio.Coin)
				.WithAmount(testPortfolio.Amount)
				.WithBuyPrice(testPortfolio.BuyPrice)
				.WithCurrentPrice(testPortfolio.CurrentPrice)
				.Build();

			// Assert
			Assert.That(portfolioItem.InitialValue, Is.EqualTo(testPortfolio.InitialValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolioItem.CurrentValue, Is.EqualTo(testPortfolio.CurrentValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolioItem.ChangePercentage, Is.EqualTo(testPortfolio.ChangePercentage).Within(TestConstants.PercentagePrecision));
		}
	}
}