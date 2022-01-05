using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCMS.Shared
{
    public interface ISiteConfiguration
    {
        Task<Article?> GetArticleByKeyAsync(string articleKey);
        Task<Article?> WriteArticleAsync(Article article);
    }
}
