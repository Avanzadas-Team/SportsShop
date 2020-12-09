using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class Bought : IRelation
    {
        public DateTime Date { get; set; }
        public Bought()
        {
            Date = DateTime.Now;
        }
    }
}
