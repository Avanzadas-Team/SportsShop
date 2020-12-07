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
        public ClientController(GraphDbContext graphDbContext)
        {
            _graphContext = graphDbContext;
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

        [HttpGet]
        public async Task<IActionResult> History(User user)
        {
            IEnumerable<Article> articlesBought = new List<Article>();
            return Ok(articlesBought);
        }
    }
}
