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

        public async Task<Article?> GetArticleByKeyAsync(string articleKey)
        {
            try
            {
                if (String.IsNullOrEmpty(articleKey))
                {
                    throw new Exception("Missing key for call GetArticle()");
                }
                _logger.LogInformation("GetArticle(key = {articleKey})", articleKey);
                Article article = await _articleRepository.GetItemByKey(articleKey);
                if (null == article)
                {
                    article = new Article();
                    article.ArticleKey = articleKey;
                }
                return article;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetArticle() failed.");
                throw;
            }
        }
        public async Task<Article?> WriteArticleAsync(Article article)
        {
            try
            {
                if (null == article)
                {
                    throw new Exception("WriteArticleSync - argument article is null.");
                }
                if (String.IsNullOrEmpty(article.ArticleKey))
                {
                    throw new Exception("WriteArticleSync - argument article.ArticleKey is empty.");
                }
                _logger.LogInformation("WriteArticle(key = {article.ArticleKey})", article.ArticleKey);

                article.LogicalKey = article.ArticleKey;

                Article updatedArticle = await _articleRepository.UpsertItem(article);
                return updatedArticle;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WriteArticle() failed.");
                throw;
            }
        }
    }
}
