using DynamoSoftware.Assignment.Domain.Portfolios.Builders;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser
{
	public sealed class PortfolioItemsFileParser : IPortfolioItemsFileParser
	{
		public async Task<IEnumerable<IPortfolioItemSimple>> ParseFile(Stream fileStream)
		{
			var result = new List<IPortfolioItemSimple>();

			using (var reader = new StreamReader(fileStream, Encoding.UTF8))
			{
				string portfolioItemLine;

				while ((portfolioItemLine = await reader.ReadLineAsync()) != null)
				{
					var portfolioItem = ParsePortfolioItem(portfolioItemLine);
					result.Add(portfolioItem);
				}
			}

			return result;
		}

		public IPortfolioItemSimple ParsePortfolioItem(string portfolioItemLine)
		{
			var itemBuilder = new PortfolioItemSimpleBuilder();
			var portfolioItemTokens = portfolioItemLine.Split(PortfolioConstants.FileDelimiter);

			if (portfolioItemTokens.Length != 3)
			{
				throw new PortfolioItemParseException(nameof(portfolioItemLine), $"Cannot parse: {portfolioItemLine}");
			}

			var amountToken = portfolioItemTokens[0];
			var coinToken = portfolioItemTokens[1];
			var buyPriceToken = portfolioItemTokens[2];

			if (!string.IsNullOrEmpty(coinToken))
			{
				itemBuilder.CoinName(coinToken);
			}
			else
			{
				throw new PortfolioItemParseException(nameof(coinToken), $"Invalid coin name: {coinToken}");
			}

			if (double.TryParse(amountToken, CultureInfo.InvariantCulture, out double amount))
			{
				itemBuilder.Amount(amount);
			}
			else
			{
				throw new PortfolioItemParseException(nameof(amountToken), $"Invalid amount: {amountToken}");
			}

			if (double.TryParse(buyPriceToken, CultureInfo.InvariantCulture, out double buyPrice))
			{
				itemBuilder.BuyPrice(buyPrice);
			}
			else
			{
				throw new PortfolioItemParseException(nameof(buyPriceToken), $"Invalid buy price: {buyPriceToken}");
			}

			var result = itemBuilder.BuildSimple();
			return result;
		}
	}
}