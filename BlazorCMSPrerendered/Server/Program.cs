using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Azure.Cosmos;
using BlazorCMS.Shared;
using BlazorCMS.ServerData;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add services to be available for Dependency injection
builder.Services.AddSingleton(builder.Configuration);
CosmosClient cosmosClient = new CosmosClient(builder.Configuration["COSMOS_DB_CONNECTION_STRING"]);
builder.Services.AddSingleton(cosmosClient);
builder.Services.AddScoped<BlazorCMS.Shared.AppState>();
builder.Services.AddScoped<CosmosDBRepository<Article>>();
builder.Services.AddScoped<ISiteConfiguration, SiteConfiguration>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<CosmosDBRepository<Shortcut>>();
builder.Services.AddScoped<IShortcutService, ShortcutService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
