using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lukaszsadlochablog.Models
{
    public class ArticleRenderer
    {
        private Article article;
        private ArticleSettings articleSettings;

        private string articleImagePattern = @"\[\[img(\d)\]\]";

        public ArticleRenderer(ArticleSettings articleSettings)
        {
            this.articleSettings = articleSettings;
        }

        public ArticleRenderer LoadArticle(Article article)
        {
            this.article = article;
            return this;
        }

        public string RenderArticleText()
        {
            var output = this.article.RawText;
            var regex = new Regex(articleImagePattern);
            var matches = Regex.Matches(output, this.articleImagePattern);

            IDictionary<string, string> maps = new Dictionary<string, string>();

            foreach (Match match in matches)
            {
                int imageID = int.Parse(match.Groups[1].Value);
                var htmlTag = this.article.ArticleImages.GetImage(imageID).GetHtmlTag();
                maps.Add(match.Value, htmlTag);
            }
            foreach (var map in maps)
            {
                output = output.Replace(map.Key, map.Value);
            }

            return output;
        }
    }
}
