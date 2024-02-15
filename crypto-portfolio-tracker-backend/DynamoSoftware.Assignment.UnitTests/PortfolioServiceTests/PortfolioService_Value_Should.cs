using DynamoSoftware.Assignment.UnitTests.Factories;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioServiceTests
{
	internal class PortfolioService_Value_Should : BasePortfolioServiceTest
	{
		[Test]
		public void PortfolioService_Value_Calculate()
		{
			// Arrange
			var fileStream = ModelFactory.CreateFileStreamFromString(TestModels.FileTest);
			
			this.CryptocurrencyTrackerMock.Setup(m => m.GetCryptocurrencies(ValueTestModels.CryptocurrencyTrackerMockData))
				.ReturnsAsync(ValueTestModels.CryptocurrencyTrackerMockResult);

			// Act
			var portfolio = this.PortfolioService.ParseAndCalculatePortfolioValueAsync(fileStream).Result;

			// Assert
			Assert.That(portfolio, Is.Not.Null);
			Assert.That(portfolio.Items.Count(), Is.EqualTo(4));
			Assert.That(portfolio.InitialValue, Is.EqualTo(ValueTestModels.PortfolioValueTest.InitialValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.CurrentValue, Is.EqualTo(ValueTestModels.PortfolioValueTest.CurrentValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.OverallChangeValue, Is.EqualTo(ValueTestModels.PortfolioValueTest.OverallChangeValue).Within(TestConstants.PricePrecision));
			Assert.That(portfolio.OverallChangePercentage, Is.EqualTo(ValueTestModels.PortfolioValueTest.OverallChangePercentage).Within(TestConstants.PercentagePrecision));
		}
	}
}