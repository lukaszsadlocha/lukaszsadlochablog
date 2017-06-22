using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaszsadlochablog.Models
{
    public class ArticleImageCollection
    {
        [JsonProperty]
        private List<ArticleImage> articleImages;
        public ArticleImageCollection()
        {
            this.articleImages = new List<ArticleImage>();
        }

        public void AddImage(ArticleImage articleImage) {

            articleImages.Add(articleImage);
        }

        public ArticleImage GetImage(int articleImageId)
        {

            return articleImages.First(x => x.ArticleImageID == articleImageId);
        }


    }
}
