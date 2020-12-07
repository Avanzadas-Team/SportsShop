using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Bought
    {
        public IEnumerable<Cart> Cart { get; set; }
        DateTime Date { get; set; }
    }
}
