using BlazorCMSPrerendered.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCMS.ClientData;
using BlazorCMS.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Create services to be used via dependency injection
builder.Services.AddSingleton<BlazorCMS.UIComponents.AppState>();
builder.Services.AddScoped<ISiteConfiguration, SiteConfiguration>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

await builder.Build().RunAsync();
