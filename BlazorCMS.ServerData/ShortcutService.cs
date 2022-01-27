using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BlazorCMS.Shared;

namespace BlazorCMS.ServerData
{
    public class ShortcutService : IShortcutService
    {
        private readonly CosmosDBRepository<Shortcut> _shortcutRepository;
        private readonly ILogger _logger;
        public ShortcutService(ILogger<IShortcutService> logger,
                         CosmosDBRepository<Shortcut> shortcutRepository)
        {
            _logger = logger;
            _shortcutRepository = shortcutRepository;
        }
        public async Task<Shortcut?> GetShortcut(string category, string? nickname)
        {
            Shortcut? target = (await _shortcutRepository.GetItems(s => s.Category == category && s.Nickname == nickname)).FirstOrDefault();
            return target;
        }
    }
}
