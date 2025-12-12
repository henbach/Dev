using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PmsViz.Core.Dtos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

bool isDevelopment = builder.Environment.IsDevelopment();
AppSettings appSettings = new AppSettings();
builder.Configuration.GetSection("AppSettings").Bind(appSettings);

builder.Services.AddAppCustomServices(appSettings, isDevelopment);

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
