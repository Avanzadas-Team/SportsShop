using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.PresentationModel;
using Server.Services;
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

        [HttpGet("products")]
        public IEnumerable<ProductMDB> GetProducts()
        {
            List<ProductMDB> products = _context.GetProducts();
            return products;
        }

        [HttpPost("cart/{id}")]
        public int addProductToCart(string id, Cart cart)
        {
            var user = _context.GetUser(id);
            var x = user.Cart.Count();
            var carts = user.Cart.ToList();
            bool flag = false;
            if(x == 0)
            {
                carts.Add(cart);
            }
            else
            {
                for(int c = 0; c < x; c++)
                {
                    if(carts[c].ProductId == cart.ProductId)
                    {
                        carts[c].Quantity += cart.Quantity;
                        flag = true;
                    }else{ 
                        if (c == x - 1 && !flag)
                        {
                            carts.Add(cart);
                        }
                    }
                }
            }
            user.Cart = carts;   
            _context.UpdateUser(id, user);
            return x;
        }

        [HttpGet("cart/{id}")]
        public IEnumerable<CartModel> getCarToUser(string id)
        {
            var cart = _context.GetUser(id).Cart;
            List<CartModel> carts = new List<CartModel>();
            foreach(var c in cart)
            {
                CartModel cm = new CartModel();
                var prodInfo = _context.GetProduct(c.ProductId);
                cm.image = prodInfo.Imagen;
                cm.Name = prodInfo.Name;
                cm.price = prodInfo.Precio;
                cm.prodId = c.ProductId;
                cm.quantity = c.Quantity;
                carts.Add(cm);
            }

            return carts;
        }

        [HttpPut("cart/{id}")]
        public Cart updateProdToCart(string id, Cart prod)
        {
            var user = _context.GetUser(id);
            var x = user.Cart.Count();
            var carts = user.Cart.ToList();
            for (int c = 0; c < x; c++)
            {
                if (carts[c].ProductId == prod.ProductId)
                {
                    carts[c].Quantity = prod.Quantity;
                }
            }
            user.Cart = carts;
            _context.UpdateUser(id, user);
            return prod;
        }

        [HttpDelete("cart/{id}/{prodId}")]
        public List<Cart> deleteProdToCart(string id, string prodId)
        {
            var user = _context.GetUser(id);
            List<Cart> newcart = user.Cart.ToList();
            if(newcart.Count() == 1)
            {
                newcart = new List<Cart>();
            }
            for(int c = 0; c < newcart.Count(); c++)
            {
                if(newcart[c].ProductId != prodId)
                {
                    newcart.Remove(newcart[c]);
                }
            }
            //newcart.Remove();

            user.Cart = newcart;

            _context.UpdateUser(id, user);
            return newcart;
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
