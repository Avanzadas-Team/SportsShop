using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class AddToCart : IRelation
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public CartStatus Status { get; set; }
        public AddToCart()
        {
            Date = DateTime.Now;
            Status = CartStatus.InCart;
            Quantity = 1;
        }
        public AddToCart(int quantity)
        {
            Date = DateTime.Now;
            Status = CartStatus.InCart;
            Quantity = quantity;
        }

        public enum CartStatus
        {
            InCart, Deleted, Bought
        }
    }
}
