using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlazorCMS.Shared;
namespace BlazorCMS.Server.Controllers
{
    [Route("api/shortcuts")]
    [AllowAnonymous]
    [ApiController]
    public class ShortcutsController : ControllerBase
    {
        private readonly IShortcutService _shortcutService;
        private readonly ILogger<IShortcutService> _logger;
        public ShortcutsController(ILogger<IShortcutService> logger, IShortcutService shortcutService)
        {
            _logger = logger;
            _shortcutService = shortcutService;
        }
        [HttpGet("getshortcut/{category}/{nickname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShortcut([FromRoute] string category, [FromRoute]string nickname)
        {
            Shortcut? target = await _shortcutService.GetShortcut(category, nickname);
            if (target == null)
            {
                target = new Shortcut();
            }
            return Ok(target);
        }
    }
}
