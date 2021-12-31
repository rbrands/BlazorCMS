using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using BlazorCMS.Client;
using BlazorCMS.Client.Data;
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

builder.Services.AddGraphClient();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

await builder.Build().RunAsync();
