using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Bought
    {
        public string clientId { get; set; }
        public IEnumerable<Cart> Cart { get; set; }
        DateTime Date { get; set; }
    }
}
