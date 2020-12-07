﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SportsShopDBContext _context;

        public AdminController(SportsShopDBContext context)
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
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                fileBytes = stream.ToArray();
            }

            var product = _context.GetProduct(id);

            product.Imagen = fileBytes;

            _context.UpdateProduct(id, product);

            return product;
        }

        [HttpGet("productimages/{id}")]
        public IActionResult GetMovieImages(string id)
        {
            byte[] images = _context.GetProduct(id).Imagen;
            return File(images, "image/jpeg");
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
