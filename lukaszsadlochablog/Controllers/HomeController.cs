using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using lukaszsadlochablog.Models;

namespace lukaszsadlochablog.Controllers
{
    public class HomeController : Controller
    {
        private ArticleCollection articles;
        private ArticleRenderer articleRenderer;

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Article(int articleID)
        {
            Article articleToDisplay = articles.GetArticleByID(articleID);

            return View(articleToDisplay);
        }
    }
}
