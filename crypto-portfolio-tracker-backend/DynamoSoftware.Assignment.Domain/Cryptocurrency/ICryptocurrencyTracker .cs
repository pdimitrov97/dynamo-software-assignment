using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.Domain.Cryptocurrency
{
	public interface ICryptocurrencyTracker
	{
		Task<IEnumerable<ICryptocurrencyItem>> GetCryptocurrencies(string[] symbols);
	}
}