using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.UnitTests.Factories;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using NUnit.Framework;
using System;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioItemTests
{
	internal class PortfolioItemConstructor_Should
	{
		[Test]
		public void PortfolioItemConstructor_InvalidCoin()
		{
			// Act
			var result = ExceptionHelpers.Catch(() => new PortfolioItem(string.Empty, TestModels.TestAmount, TestModels.TestBuyPrice, TestModels.TestCurrentPrice), out ArgumentOutOfRangeException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("coin"));
		}

		[Test]
		public void PortfolioItemConstructor_InvalidAmount()
		{
			// Act
			var result = ExceptionHelpers.Catch(() => new PortfolioItem(TestModels.TestCoin, -TestModels.TestAmount, TestModels.TestBuyPrice, TestModels.TestCurrentPrice), out ArgumentOutOfRangeException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("amount"));
		}

		[Test]
		public void PortfolioItemConstructor_InvalidBuyPrice()
		{
			// Act
			var result = ExceptionHelpers.Catch(() => new PortfolioItem(TestModels.TestCoin, TestModels.TestAmount, -TestModels.TestBuyPrice, TestModels.TestCurrentPrice), out ArgumentOutOfRangeException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("buyPrice"));
		}

		[Test]
		public void PortfolioItemConstructor_InvalidCurrentPrice()
		{
			// Act
			var result = ExceptionHelpers.Catch(() => new PortfolioItem(TestModels.TestCoin, TestModels.TestAmount, TestModels.TestBuyPrice, -TestModels.TestCurrentPrice), out ArgumentOutOfRangeException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("currentPrice"));
		}
	}
}