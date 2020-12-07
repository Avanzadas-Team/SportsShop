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
        public async Task<IActionResult> Register(User user)
        {
            return Ok(user);
        }
        [HttpPut("bought")]
        public async Task<IActionResult> Buy(Resources.Bought bought)
        {
            var article = (Article) _graphContext.CreateRelation(bought.User, new Bought(), bought.Article);
            return Ok(article);
        }

        [HttpGet("bought")]
        public async Task<IActionResult> History(User user)
        {
            List<Resources.Article> articlesBought = new List<Resources.Article>();
            var articles = _graphContext.GetRelatives(user, typeof(Bought));
            _sportsShopDBContext.GetProducts().ForEach(value =>
            {
                foreach (var article in articles)
                    if (article.Node.Id == value.Id)
                        articlesBought.Add(new Resources.Article(article.Date,value));
            });
            return Ok(articlesBought);
        }
    }
}
