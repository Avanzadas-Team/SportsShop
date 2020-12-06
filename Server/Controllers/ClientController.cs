using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly GraphDbContext _graphContext;
        public ClientController(GraphDbContext graphDbContext)
        {
            _graphContext = graphDbContext;
        }
        [HttpPut]
        public async Task<IActionResult> Register(User user)
        {
            return Ok(user);
        }/*
        [HttpPut]
        public async Task<IActionResult> Buy(User user, Article article)
        {
            return Ok(article);
        }*/

        [HttpGet]
        public async Task<IActionResult> History(User user)
        {
            IEnumerable<Article> articlesBought = new List<Article>();
            //_graphContext
            return Ok(articlesBought);
        }
    }
}
