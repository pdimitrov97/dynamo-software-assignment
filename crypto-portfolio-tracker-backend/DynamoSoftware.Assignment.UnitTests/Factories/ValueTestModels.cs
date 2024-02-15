using DynamoSoftware.Assignment.Domain.Cryptocurrency;

namespace DynamoSoftware.Assignment.UnitTests.Factories
{
	internal class ValueTestModels
	{
		public static readonly TestPortfolioItemDataHolder ValueTestModel1 = new TestPortfolioItemDataHolder
		{
			Coin = "ETH",
			Amount = 10,
			BuyPrice = 123.14,
			CurrentPrice = 2747.03,
			InitialValue = 1231.4,
			CurrentValue = 27470.3,
			ChangeValue = 26238.9,
			ChangePercentage = 2130.8185804
		};

		public static readonly TestPortfolioItemDataHolder ValueTestModel2 = new TestPortfolioItemDataHolder
		{
			Coin = "BTC",
			Amount = 12.12454,
			BuyPrice = 24012.43,
			CurrentPrice = 51620.29,
			InitialValue = 291139.6680322,
			CurrentValue = 625872.2709166,
			ChangeValue = 334732.6028844,
			ChangePercentage = 114.9732034
		};

		public static readonly TestPortfolioItemDataHolder ValueTestModel3 = new TestPortfolioItemDataHolder
		{
			Coin = "SHIB",
			Amount = 10000000,
			BuyPrice = 60,
			CurrentPrice = 0,
			InitialValue = 600000000,
			CurrentValue = 0,
			ChangeValue = -600000000,
			ChangePercentage = -100
		};

		public static readonly TestPortfolioItemDataHolder ValueTestModel4 = new TestPortfolioItemDataHolder
		{
			Coin = "USDT",
			Amount = 1200,
			BuyPrice = 1123.23,
			CurrentPrice = 1.00,
			InitialValue = 1347876,
			CurrentValue = 1200,
			ChangeValue = -1346676,
			ChangePercentage = -99.91097103
		};

		public static readonly TestPortfolioItemDataHolder[] PortfolioItemsValueTests = new TestPortfolioItemDataHolder[]
		{
			ValueTestModel1,
			ValueTestModel2,
			ValueTestModel3,
			ValueTestModel4
		};

		public static readonly TestPortfolioDataHolder PortfolioValueTest = new TestPortfolioDataHolder
		{
			Items = PortfolioItemsValueTests,
			InitialValue = 601640247.0680322,
			CurrentValue = 654542.5709166,
			OverallChangeValue = -600985704.4971156,
			OverallChangePercentage = -99.8912069,
		};

		public static readonly string[] CryptocurrencyTrackerMockData = new[]
		{ 
			ValueTestModel1.Coin,
			ValueTestModel2.Coin,
			ValueTestModel3.Coin,
			ValueTestModel4.Coin
		};
		public static readonly CryptocurrencyItem[] CryptocurrencyTrackerMockResult = new[]
		{
			new CryptocurrencyItem(ValueTestModel1.Coin, ValueTestModel1.CurrentPrice),
			new CryptocurrencyItem(ValueTestModel2.Coin, ValueTestModel2.CurrentPrice),
			new CryptocurrencyItem(ValueTestModel3.Coin, ValueTestModel3.CurrentPrice),
			new CryptocurrencyItem(ValueTestModel4.Coin, ValueTestModel4.CurrentPrice)
		};
	}
}