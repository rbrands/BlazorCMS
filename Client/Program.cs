using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using BlazorCMS.Client;
using BlazorCMS.ClientData;
using BlazorCMS.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorCMS.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorCMS.ServerAPI"));
builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    // Add uri with client id of server API
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://9a501f23-40ef-4c61-9ea1-0e6038cb7643/API.Access");
    options.UserOptions.RoleClaim = "appRole";
})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount,
CustomAccountFactory>();

// Add typed HttpClient for http requests without authentication, see https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-3.1#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client-2
builder.Services.AddHttpClient<HttpNoAuthenticationClient>("BlazorCMS.ServerAPINoAuthentication", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorCMS.ServerAPINoAuthentication"));

// To get user details
builder.Services.AddGraphClient();

// Create services to be used via dependency injection by business logic
builder.Services.AddSingleton<BlazorCMS.Shared.AppState>();
builder.Services.AddScoped<ISiteConfiguration, SiteConfiguration>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IShortcutService, ShortcutService>();

await builder.Build().RunAsync();
