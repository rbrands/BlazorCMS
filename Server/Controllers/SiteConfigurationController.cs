using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlazorCMS.Shared;


namespace BlazorCMS.Server.Controllers
{
    [Route("api/siteconfiguration")]
    [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<Article> GetArticleByKey([FromRoute] string articleKey)
        {
            return await _siteConfiguration.GetArticleByKeyAsync(articleKey);
        }
    }
}
