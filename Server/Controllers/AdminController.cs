using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SportsShopDBService _context;

        public AdminController(SportsShopDBService context)
        {
            _context = context;
        }


        // GET: api/<AdminController>
        [HttpGet("users")]
        public IEnumerable<UserMDB> GetUsers()
        {
            List<UserMDB> users = _context.GetUsers();
            return users;
        }

        [HttpGet("products")]
        public IEnumerable<ProductMDB> GetProducts()
        {
            List<ProductMDB> products = _context.GetProducts();
            return products;
        }

        // GET: api/<AdminController>
        [HttpPost("users/sname")]
        public UserMDB GetUserbyName(UserMDB user)
        {
            List<UserMDB> users = _context.GetUsers();

            var userFound = new UserMDB();

            foreach (var us in users)
            {
                if(us.Name == user.Name)
                {
                    userFound = us;
                    return userFound;
                }
            }

            return userFound;
        }

        [HttpPost("users/susername")]
        public UserMDB GetUserbyUserName(UserMDB user)
        {
            List<UserMDB> users = _context.GetUsers();

            var userFound = new UserMDB();

            foreach (var us in users)
            {
                if (us.UserName == user.UserName)
                {
                    userFound = us;
                    return userFound;
                }
            }

            return userFound;
        }

        [HttpPost("users/username")]
        public UserMDB RegisterUser(UserMDB user)
        {
            _context.CreateUser(user);

            return user;
        }

        [HttpPost("image/{id}")]
        public async Task<ProductMDB> CreateImage([FromForm] IFormFile image, string id)
        {
            var product = _context.GetProduct(id);

            _context.UpdateProduct(id, product);

            return product;
        }

        [HttpGet("productimages/{id}")]
        public IActionResult GetMovieImages(string id)
        {
            string images = _context.GetProduct(id).Imagen;
            return Ok(images);
        }

        [HttpPost("product")]
        public ProductMDB CreateProduct(ProductMDB product)
        {
            _context.CreateProduct(product);

            return product;
        }

        [HttpPost("promotion")]
        public PromotionMDB CreatePromotion(PromotionMDB promotion)
        {
            _context.CreatePromotion(promotion);

            return promotion;
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
