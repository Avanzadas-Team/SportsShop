﻿using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Resources
{
    public class Article
    {

        public DateTime Date { get; set; }
        public Models.ProductMDB article { get; set; }

        public Article(DateTime date, ProductMDB article)
        {
            Date = date;
            this.article = article;
        }

    }
}
