using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Persistence;
using System.Collections.Generic;
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
            var article = (ProductMDB) _graphContext.CreateRelation(bought.User, new Bought(), bought.Article);
            return Ok(article);
        }

        [HttpGet("bought/{id}")]
        public async Task<IActionResult> History(string id)
        {
            var user = _sportsShopDBContext.GetUser(id);
            List<Resources.Article> articlesBought = new List<Resources.Article>();
            var articles = _graphContext.GetRelatives(user, typeof(Bought));

            var products = _sportsShopDBContext.GetProducts();

            foreach (var item in products)
            {
                foreach (var article in articles)
                {   
                    if (article.Node.Id.Equals(item.Id))
                    {
                        var add = new Resources.Article(article.Date, item);
                        articlesBought.Add(add);
                    }
                }
            }

            return Ok(articlesBought);
        }
    }
}
