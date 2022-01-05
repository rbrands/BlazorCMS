using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCMS.Shared;

namespace BlazorCMSPrerendered.Server.Controllers
{
    [Route("api/siteconfiguration")]
    [ApiController]
    public class SiteConfigurationController : ControllerBase
    {
        private readonly ISiteConfiguration _siteConfiguration;
        private readonly ILogger<ISiteConfiguration> _logger;
        public SiteConfigurationController(ILogger<ISiteConfiguration> logger, ISiteConfiguration siteConfiguration)
        {
            _logger = logger;
            _siteConfiguration = siteConfiguration;
        }
        [HttpGet("getarticlebykey/{articleKey}")]
        public async Task<Article> GetArticleByKey([FromRoute] string articleKey)
        {
            return await _siteConfiguration.GetArticleByKeyAsync(articleKey);
        }
        [HttpPost("writearticle")]
        public Task<Article> WriteArticle([FromBody] Article article)
        {
            throw new NotImplementedException("WriteArticle not supported in this version of the app.");
        }

    }
}
