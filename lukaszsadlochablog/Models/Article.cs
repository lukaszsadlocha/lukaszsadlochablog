using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaszsadlochablog.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string RawText { get; set; }
        public ArticleImageCollection ArticleImages { get; set; }


    }
}
