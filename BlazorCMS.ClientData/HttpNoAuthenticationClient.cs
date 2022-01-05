using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace BlazorCMS.ClientData
{
    public class HttpNoAuthenticationClient 
    {
        private readonly HttpClient _httpClient;

        public HttpClient HttpClient { get { return _httpClient; } }

        public HttpNoAuthenticationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
