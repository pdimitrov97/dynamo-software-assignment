using System;

namespace DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser
{
	public sealed class PortfolioItemParseException : Exception
	{
		public PortfolioItemParseException(string paramName, string message) : base(message)
		{
			this.ParamName = paramName;
		}

		public string ParamName { get; }
	}
}