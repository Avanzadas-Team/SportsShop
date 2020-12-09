using System.Collections.Generic;

namespace Server.Controllers.Resources
{
    public class Bought
    {
        public IEnumerable<CartModel> Articles { get; set; }
        public string UserId { get; set; }
    }
}
