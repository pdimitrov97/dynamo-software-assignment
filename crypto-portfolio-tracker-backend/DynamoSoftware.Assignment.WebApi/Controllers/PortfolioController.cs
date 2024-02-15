using DynamoSoftware.Assignment.Domain;
using DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser;
using DynamoSoftware.Assignment.WebApi.Controllers.Dtos;
using DynamoSoftware.Assignment.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.WebApi.Controllers
{
	[ApiController]
	[Route("api/v1/portfolios")]
	public class PortfolioController : ControllerBase
	{
		private readonly IPortfolioService portfolioSvc;

		public PortfolioController(IPortfolioService portfolioSvc)
		{
			this.portfolioSvc = portfolioSvc ?? throw new ArgumentNullException(nameof(portfolioSvc));
		}

		[HttpPost]
		[Route("calculate-value")]
		public async Task<ActionResult<IPortfolio>> CalculateValueAsync([FromForm] CalculatePortfolioValueRequest calculateRequestDto)
		{
			try
			{
				var requestFile = await calculateRequestDto.PortfolioFile.ToMemoryStreamAsync();
				var result = await this.portfolioSvc.ParseAndCalculatePortfolioValueAsync(requestFile);
				return this.Ok(result);
			}
			catch (PortfolioItemParseException parseEx)
			{
				return this.BadRequest(parseEx);
			}
		}
	}
}