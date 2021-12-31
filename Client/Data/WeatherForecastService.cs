using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorCMS.Shared;

namespace BlazorCMS.Client.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
