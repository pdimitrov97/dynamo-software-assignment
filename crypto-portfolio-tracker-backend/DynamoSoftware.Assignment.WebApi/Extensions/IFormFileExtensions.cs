using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.WebApi.Extensions
{
	public static class IFormFileExtensions
	{
		public static async Task<Stream> ToMemoryStreamAsync(this IFormFile formFile)
		{
			var result = new MemoryStream();
			await formFile.CopyToAsync(result);
			result.Position = 0;

			return result;
		}
	}
}