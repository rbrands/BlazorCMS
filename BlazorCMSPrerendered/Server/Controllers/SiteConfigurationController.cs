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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArticleByKey([FromRoute] string articleKey)
        {
            Article? article = await _siteConfiguration.GetArticleByKeyAsync(articleKey);
            return Ok(article);
        }
        [HttpPost("writearticle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> WriteArticle([FromBody] Article article)
        {
            Article? updatedArticle = await _siteConfiguration.WriteArticleAsync(article);
            return Ok(updatedArticle);
        }


    }
}
