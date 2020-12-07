using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.PresentationModel
{
    public class CartModel
    {
        public string prodId { get; set; }
        public string Name { get; set; }

        public int quantity { get; set; }

        public float price { get; set; }

        public string image { get; set; }
    }
}
