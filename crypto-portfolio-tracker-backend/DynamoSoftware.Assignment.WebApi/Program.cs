using DynamoSoftware.Assignment.Domain;
using DynamoSoftware.Assignment.Domain.Cryptocurrency;
using DynamoSoftware.Assignment.Domain.Cryptocurrency.CoinLoreCryptocurrency;
using DynamoSoftware.Assignment.Domain.Portfolios;
using DynamoSoftware.Assignment.Domain.Portfolios.Parsers;
using DynamoSoftware.Assignment.Domain.Portfolios.Parsers.FileParser;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using Serilog.Filters;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
	options.SerializerSettings.Converters.Add(new StringEnumConverter());
	options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});

// Allow the front-end to use the WebAPI
builder.Services.AddCors(options =>
{ 
	options.AddPolicy("AllowOrigin", policyBuilder => policyBuilder
		.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());
});

builder.Services.Configure<CoinLoreCryptocurrencyTrackerSettings>(builder.Configuration.GetSection(CoinLoreCryptocurrencyTrackerSettings.ConfigurationName));
builder.Services.AddScoped<IPortfolioItemsFileParser, PortfolioItemsFileParser>();
builder.Services.AddScoped<ICryptocurrencyTracker, CoinLoreCryptocurrencyTracker>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();

// Use Serilog for logging user actions to a file.
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Information()
	.Filter.ByIncludingOnly(Matching.FromSource<PortfolioService>())
	.WriteTo.RollingFile(AppDomain.CurrentDomain.BaseDirectory + "/Logs/UserActions-{Date}.log")
	.CreateLogger();

builder.Logging.AddSerilog();

var app = builder.Build();
app.UseHttpsRedirection();

// Allow the front-end to use the WebAPI
app.UseCors(cors => cors
	.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod());
app.MapControllers();
app.Run();