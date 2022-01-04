using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared=BlazorCMS.Shared;

namespace BlazorCMS.UIComponents
{
    public class AppState
    {
        public IDictionary<string, Shared.Article> ArticleCache { get; set; } = new Dictionary<string, Shared.Article>();
        public event Action OnChange;
        public bool NotificationSubscriptionRequested { get; set; } = false;
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
