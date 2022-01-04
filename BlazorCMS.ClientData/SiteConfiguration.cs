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
        public SiteConfiguration(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Article> GetArticleByKeyAsync(string articleKey)
        {
            return await _httpClient.GetFromJsonAsync<Article>($"api/siteconfiguration/getarticlebykey/{articleKey}");
        }
    }
}
