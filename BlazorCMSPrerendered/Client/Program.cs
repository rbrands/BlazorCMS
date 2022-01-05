using BlazorCMSPrerendered.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using BlazorCMS.ClientData;
using BlazorCMS.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add typed HttpClient for http requests without authentication, see https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-3.1#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client-2
builder.Services.AddHttpClient<HttpNoAuthenticationClient>("BlazorCMS.ServerAPINoAuthentication", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorCMS.ServerAPINoAuthentication"));

// Create services to be used via dependency injection
builder.Services.AddSingleton<BlazorCMS.Shared.AppState>();
builder.Services.AddScoped<ISiteConfiguration, SiteConfiguration>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

await builder.Build().RunAsync();
