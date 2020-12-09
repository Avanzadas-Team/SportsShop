using Server.Models;
using System;

namespace Server.Controllers.Resources
{
    public class Article
    {
        public DateTime Date { get; set; }
        public Models.ProductMDB Product { get; set; }

        public Article(DateTime date, ProductMDB article)
        {
            Date = date;
            this.Product = article;
        }

    }
}
