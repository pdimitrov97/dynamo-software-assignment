using DynamoSoftware.Assignment.Domain.Cryptocurrency;
using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.UnitTests.Factories;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace DynamoSoftware.Assignment.UnitTests.PortfolioServiceTests
{
	internal abstract class BasePortfolioServiceTest
	{
		protected PortfolioService PortfolioService { get; private set; }

		protected Mock<ICryptocurrencyTracker> CryptocurrencyTrackerMock { get; private set; }

		[SetUp]
		public void Setup()
		{
			var portfolioItemsParser = ModelFactory.CreateFileParser();
			var logger = new Mock<ILogger<PortfolioService>>(MockBehavior.Loose);
			var cryptocurrencyTracker = new Mock<ICryptocurrencyTracker>(MockBehavior.Loose);

			this.CryptocurrencyTrackerMock = cryptocurrencyTracker;
			this.PortfolioService = new PortfolioService(portfolioItemsParser, cryptocurrencyTracker.Object, logger.Object);
		}
	}
}