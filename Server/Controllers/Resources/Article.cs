using Server.Models;
using System;

namespace Server.Controllers.Resources
{
    public class Article
    {
        public string Date { get; set; }
        public Models.ProductMDB Product { get; set; }

        public Article(string date, ProductMDB article)
        {
            Date = date;
            this.Product = article;
        }

    }
}
