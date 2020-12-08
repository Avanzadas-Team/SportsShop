using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class Bought : IRelation
    {
        public string clientId { get; set; }
        public IEnumerable<Cart> Cart { get; set; }
        DateTime Date { get; set; }
        public Bought()
        {
            Date = DateTime.Now;
        }
    }
}
