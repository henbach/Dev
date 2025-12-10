using PmsViz.Core.Dtos;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

bool isDevelopment = builder.Environment.IsDevelopment();

ApiSettings apiSettings = new ApiSettings();
builder.Configuration.GetSection("ApiSettings").Bind(apiSettings);

// Add services to the container.
builder.Services.AddApiServices(apiSettings, isDevelopment);

var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapUserEndpoints();
app.Run();


