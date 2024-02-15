using DynamoSoftware.Assignment.Domain;
using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.UnitTests.Factories;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioTests
{
	internal class PortfolioValue_Should
	{
		[Test]
		public void PortfolioItemValue_Empty()
		{
			// Arrange
			var builder = ModelFactory.CreatePortfolioBuilder();
			var portfolio = builder.BuildPortfolio();

			// Assert
			Assert.That(portfolio.InitialValue, Is.EqualTo(0));
			Assert.That(portfolio.CurrentValue, Is.EqualTo(0));
			Assert.That(portfolio.OverallChangeValue, Is.EqualTo(0));
			Assert.That(portfolio.OverallChangePercentage, Is.EqualTo(0));
		}

		[Test]
		public void PortfolioItemValue_OneItem()
		{
			// Arrange
			var testModel = ValueTestModels.ValueTestModel1;
			var itemBuilder = ModelFactory.CreatePortfolioItemBuilder();
			var portfolioItem = itemBuilder
				.WithCoinName(testModel.Coin)
				.WithAmount(testModel.Amount)
				.WithBuyPrice(testModel.BuyPrice)
				.WithCurrentPrice(testModel.CurrentPrice)
				.Build();

			var portfolio = new Portfolio(new List<IPortfolioItem> { portfolioItem });

			// Assert
			Assert.That(portfolio.InitialValue, Is.EqualTo(testModel.InitialValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.CurrentValue, Is.EqualTo(testModel.CurrentValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.OverallChangeValue, Is.EqualTo(testModel.ChangeValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.OverallChangePercentage, Is.EqualTo(testModel.ChangePercentage).Within(TestConstants.PercentagePrecision));
		}

		[Test]
		public void PortfolioItemValue_ManyItems()
		{
			// Arrange
			var testModel = ValueTestModels.PortfolioValueTest;
			var portfolioItems = new List<IPortfolioItem>();

			foreach (var itemTestModel in testModel.Items)
			{
				var itemBuilder = ModelFactory.CreatePortfolioItemBuilder();
				var portfolioItem = itemBuilder
					.WithCoinName(itemTestModel.Coin)
					.WithAmount(itemTestModel.Amount)
					.WithBuyPrice(itemTestModel.BuyPrice)
					.WithCurrentPrice(itemTestModel.CurrentPrice)
					.Build();

				portfolioItems.Add(portfolioItem);
			}

			var portfolio = new Portfolio(portfolioItems);

			// Assert
			Assert.That(portfolio.InitialValue, Is.EqualTo(testModel.InitialValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.CurrentValue, Is.EqualTo(testModel.CurrentValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.OverallChangeValue, Is.EqualTo(testModel.OverallChangeValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.OverallChangePercentage, Is.EqualTo(testModel.OverallChangePercentage).Within(TestConstants.PercentagePrecision));
		}
	}
}