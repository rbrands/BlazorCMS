using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorCMS.Shared;

namespace BlazorCMS.ClientData
{
    public class SiteConfiguration : ISiteConfiguration
    {
        private readonly HttpClient _httpClient;
        private readonly HttpNoAuthenticationClient _httpNoAuthenticationClient;

        public SiteConfiguration(HttpClient httpClient, HttpNoAuthenticationClient httpNoAuthenticationClient)
        {
            _httpClient = httpClient;
            _httpNoAuthenticationClient = httpNoAuthenticationClient;
        }
        public async Task<Article> GetArticleByKeyAsync(string articleKey)
        {
            return await _httpNoAuthenticationClient.HttpClient.GetFromJsonAsync<Article>($"api/siteconfiguration/getarticlebykey/{articleKey}");
        }
    }
}
