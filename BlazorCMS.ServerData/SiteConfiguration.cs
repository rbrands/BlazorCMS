using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorCMS.Shared;

namespace BlazorCMS.ServerData
{
    public class SiteConfiguration : ISiteConfiguration
    {
        private readonly CosmosDBRepository<Article> _articleRepository;
        private readonly ILogger _logger;

        public SiteConfiguration(ILogger<ISiteConfiguration> logger,
                                 CosmosDBRepository<Article> articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        public Task<Article> GetArticleByKeyAsync(string articleKey)
        {
            throw new NotImplementedException();
        }
    }
}
