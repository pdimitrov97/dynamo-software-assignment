using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.UnitTests.Helpers;
using NUnit.Framework;
using System;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioTests
{
	internal class PortfolioConstructor_Should
	{
		[Test]
		public void PortfolioItemConstructor_InvalidPortfolioItems()
		{
			// Act
			var result = ExceptionHelpers.Catch(() => new Portfolio(null), out ArgumentNullException ex);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(ex.ParamName, Is.EqualTo("items"));
		}
	}
}