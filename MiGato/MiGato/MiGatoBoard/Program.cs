using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MiGato.Core.Interfaces;
using MiGatoBoard.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IGatoController, MiGato.Core.Controller.GatoController>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<GatoHub>("/gatoHub");

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
