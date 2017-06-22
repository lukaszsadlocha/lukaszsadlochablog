using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaszsadlochablog.Models
{
    public class ArticleCollection
    {
        [JsonProperty]
        private List<Article> articles;

        public ArticleCollection()
        {
            this.articles = new List<Article>();
        }

        public void AddArticle(Article article)
        {
            this.articles.Add(article);
        }

        public Article GetArticleByID(int id)
        {
            try
            {
                return this.articles.First(x => x.ArticleID == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
