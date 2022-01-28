using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCMS.Shared
{
    public interface IShortcutService
    {
        Task<Shortcut?> GetShortcut(string category, string? nickname);
        Task<IEnumerable<Shortcut>> GetShortcuts();
    }
}
