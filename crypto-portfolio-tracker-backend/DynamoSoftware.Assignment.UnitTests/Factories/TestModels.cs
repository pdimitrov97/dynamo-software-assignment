namespace DynamoSoftware.Assignment.UnitTests.Factories
{
	internal class TestModels
	{
		public const string InvalidPortfolioItem = "12.12454|BTC";

		public const string TestCoin = "BTC";
		public const double TestAmount = 12.12454;
		public const double TestBuyPrice = 24012.43;
		public const double TestCurrentPrice = 25012.43;
		public static readonly string TestPortfolioLineValid = ModelFactory.CreatePortfolioItemLine(TestCoin, TestAmount, TestBuyPrice);
		public static readonly string TestPortfolioLineInvalidCoin = ModelFactory.CreatePortfolioItemLine(string.Empty, TestAmount, TestBuyPrice);
		public static readonly string TestPortfolioLineInvalidAmount = ModelFactory.CreatePortfolioItemLine(TestCoin, -TestAmount, TestBuyPrice);
		public static readonly string TestPortfolioLineInvalidBuyPrice = ModelFactory.CreatePortfolioItemLine(TestCoin, TestAmount, -TestBuyPrice);

		public const string FileTest =
@"10|ETH|123.14
12.12454|BTC|24012.43
10000000|SHIB|60
1200|USDT|1123.23";

		public const string InvalidCoinFileTest =
@"10||123.14
12.12454|BTC|24012.43
10000000|SHIB|60
1200|USDT|1123.23";

		public const string InvalidAmountFileTest =
@"10|ETH|123.14
|BTC|24012.43
10000000|SHIB|60
1200|USDT|1123.23";

		public const string InvalidBuyPriceFileTest =
@"10|ETH|123.14
12.12454|BTC|24012.43
10000000|SHIB|
1200|USDT|1123.23";

		public const string InvalidTokenFileTest =
@"10|ETH|123.14
12.12454|BTC|24012.43
10000000|SHIB|60
1200|USDT";

	}
}