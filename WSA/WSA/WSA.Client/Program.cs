using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Sockets;
using WSA.Client.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure HttpClient
builder.Services.AddHttpClient();

builder.Services.AddScoped(sp =>
{
    return new HttpClient
    {
        BaseAddress = new Uri("http://localhost:8888/")
    };
});

// Register services
builder.Services.AddScoped<IDataService, DataService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
