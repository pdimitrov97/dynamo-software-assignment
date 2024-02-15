using Microsoft.AspNetCore.Http;

namespace DynamoSoftware.Assignment.WebApi.Controllers.Dtos
{
    public class CalculatePortfolioValueRequest
    {
        public IFormFile PortfolioFile { get; set; }
    }
}