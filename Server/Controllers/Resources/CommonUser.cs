using Server.Models;
using System.Collections.Generic;

namespace Server.Controllers.Resources
{
    public class CommonUser
    {
        public Models.UserMDB User {get; set;}

        public List<Models.ProductMDB> Products { get; set; }

        public CommonUser(UserMDB user)
        {
            User = user;
            Products = new List<ProductMDB>();
        }

        public CommonUser(UserMDB user,List<ProductMDB> products)
        {
            User = user;
            Products = products;
        }
    }
}
