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
    public class ShortcutService : IShortcutService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpNoAuthenticationClient _httpNoAuthenticationClient;
        public ShortcutService(HttpClient httpClient, HttpNoAuthenticationClient httpNoAuthenticationClient)
        {
            _httpClient = httpClient;
            _httpNoAuthenticationClient = httpNoAuthenticationClient;
        }
        public async Task<Shortcut?> GetShortcut(string mainTopic, string? subTopic)
        {
            string category = "Default";
            string nickname = String.IsNullOrEmpty(subTopic) ? mainTopic : subTopic;
            return await _httpNoAuthenticationClient.HttpClient.GetFromJsonAsync<Shortcut>($"api/shortcuts/getshortcut/{category}/{nickname}");
        }

    }
}
