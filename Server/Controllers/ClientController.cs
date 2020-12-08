using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly GraphDbContext _graphContext;
        private readonly SportsShopDBContext _sportsShopDBContext;

        public ClientController(GraphDbContext graphDbContext, SportsShopDBContext sportsShopDBService)
        {
            _graphContext = graphDbContext;
            _sportsShopDBContext = sportsShopDBService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserMDB user)
        {
            return Ok(user);
        }
        [HttpPut("bought")]
        public async Task<IActionResult> Buy(Resources.Bought bought)
        {
            UserMDB user = _sportsShopDBContext.GetUser(bought.UserId);
            IEnumerable<Cart> products = bought.Articles;
            foreach (var cart in products)
            {
                ProductMDB product = _sportsShopDBContext.GetProduct(cart.ProductId);

                AddToCart cartAdd = _graphContext
                    .GetRelations<AddToCart>(user, product)
                    .Where(c => c.Status == AddToCart.CartStatus.InCart)
                    .FirstOrDefault();

                bool itemInCart = cartAdd != null;
                if (itemInCart && cartAdd.Status == AddToCart.CartStatus.InCart)
                {
                    cartAdd.Date = System.DateTime.Now;
                    cartAdd.Status = AddToCart.CartStatus.Bought;
                    _graphContext.UpdateRelation(user, cartAdd, product);
                }

                for (int i = 0; i < cart.Quantity; i++)
                    _graphContext.CreateRelation(user, new Bought(), product);
            }

            return Ok(_graphContext.GetRelatives<Bought>(user));
        }

        [HttpGet("bought/{id}")]
        public async Task<IActionResult> History(string id)
        {
            var user = _sportsShopDBContext.GetUser(id);
            List<Resources.Article> articlesBought = new List<Resources.Article>();
            var articles = _graphContext.GetRelatives<Bought>(user);

            var products = _sportsShopDBContext.GetProducts();

            foreach (var item in products)
            {
                foreach (var article in articles)
                {   
                    if (article.Node.Id.Equals(item.Id))
                    {
                        var add = new Resources.Article(article.Relation.Date, item);
                        articlesBought.Add(add);
                    }
                }
            }

            return Ok(articlesBought);
        }
    }
}
