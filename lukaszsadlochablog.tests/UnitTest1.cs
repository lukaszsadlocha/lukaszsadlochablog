using lukaszsadlochablog.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using Xunit;

namespace lukaszsadlochablog.tests
{
    public class UnitTest1
    {
        [Fact]
        public void ArticleSerializationTest()
        {
            var articles = new ArticleCollection();
            var article1 = new Article()
            {
                ArticleID = 1,
                RawText = "Text of 1. article",
                ArticleImages = new ArticleImageCollection()
            };


            article1.ArticleImages.AddImage(new ArticleImage() { ArticleImageID = 1, Path = "articleAssets/1/images/1.jpg" });
            article1.ArticleImages.AddImage(new ArticleImage() { ArticleImageID = 2, Path = "articleAssets/1/images/2.jpg" });

            articles.AddArticle(article1);


            var article2 = new Article()
            {
                ArticleID = 2,
                RawText = "Text of 2. article",
                ArticleImages = new ArticleImageCollection()
            };
            article2.ArticleImages.AddImage(new ArticleImage() { ArticleImageID = 1, Path = "articleAssets/2/images/1.jpg" });
            article2.ArticleImages.AddImage(new ArticleImage() { ArticleImageID = 2, Path = "articleAssets/2/images/2.jpg" });

            articles.AddArticle(article2);

            var json = JsonConvert.SerializeObject(articles);

            Assert.True(json.Contains(article1.RawText));
            Assert.True(json.Contains("1.jpg"));
            Assert.True(json.Contains("ArticleID"));
        }

        [Fact]
        public void ArticleRendererImagesTest()
        {
            var article1 = new Article()
            {
                ArticleID = 1,
                RawText = "Article title. First paragraph, first image [[img1]] some text and next image [[img2]] and the rest...",
                ArticleImages = new ArticleImageCollection()
            };


            article1.ArticleImages.AddImage(new ArticleImage() { ArticleImageID = 1, Path = "articleAssets/1/images/1.jpg" });
            article1.ArticleImages.AddImage(new ArticleImage() { ArticleImageID = 2, Path = "articleAssets/1/images/2.jpg" });

            var articleRenderer = new ArticleRenderer(new ArticleSettings());
            Assert.True(articleRenderer.LoadArticle(article1).RenderArticleText().Contains(article1.ArticleImages.GetImage(2).Path));


        }
    }
}
