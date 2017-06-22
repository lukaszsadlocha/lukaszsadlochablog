using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lukaszsadlochablog.Models
{
    public class ArticleImage
    {
        public int ArticleImageID { get; set; }
        public string Path { get; set; }

        internal string GetHtmlTag()
        {
            //to do
            return this.Path;
        }
    }
}
