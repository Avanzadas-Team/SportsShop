using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Resources;
using Server.Models;
using Server.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly GraphDbContext _graphContext;
        private readonly SportsShopDBContext _sportsShopDBContext;

        public AdminController(GraphDbContext graphDbContext, SportsShopDBContext sportsShopDBService)
        {
            _graphContext = graphDbContext;
            _sportsShopDBContext = sportsShopDBService;
        }


        // GET: api/<AdminController>
        [HttpGet("users")]
        public IEnumerable<UserMDB> GetUsers()
        {
            List<UserMDB> users = _sportsShopDBContext.GetUsers();
            return users;
        }

        [HttpGet("products")]
        public IEnumerable<ProductMDB> GetProducts()
        {
            List<ProductMDB> products = _sportsShopDBContext.GetProducts();
            return products;
        }

        [HttpPost("cart/{id}")]
        public AddToCart AddProductToCart(string id, Cart cart)
        {
            UserMDB user = _sportsShopDBContext.GetUser(id);
            ProductMDB product = _sportsShopDBContext.GetProduct(cart.ProductId);

            AddToCart cartAdd = _graphContext
                .GetRelations<AddToCart>(user, product)
                .Where(c => c.Status == AddToCart.CartStatus.InCart || c.Status == AddToCart.CartStatus.Deleted || c.Status == AddToCart.CartStatus.Bought)
                .FirstOrDefault();

            bool itemInCart = cartAdd != null;
            if(itemInCart && (cartAdd.Status == AddToCart.CartStatus.InCart || cartAdd.Status == AddToCart.CartStatus.Deleted || cartAdd.Status == AddToCart.CartStatus.Bought))
            {
                cartAdd.Quantity += cart.Quantity;
                cartAdd.Date = System.DateTime.Now;
                cartAdd.Status = AddToCart.CartStatus.InCart;
                _graphContext.UpdateRelation(user,cartAdd,product);
            }
            else
            {
                cartAdd = new AddToCart(cart.Quantity);
                _graphContext.CreateRelation(user,cartAdd,product);
            }


            return cartAdd;
        }

        [HttpGet("cart/{id}")]
        public IEnumerable<Resources.CartModel> GetCarToUser(string id)
        {
            UserMDB user = _sportsShopDBContext.GetUser(id);

            //var cart = _sportsShopDBContext.GetUser(id).Cart;
            List<Resources.CartModel> carts = new List<Resources.CartModel>();
            IEnumerable<RelatedItem<AddToCart>> cart = _graphContext
                .GetRelatives<AddToCart>(user)
                .Where(p => p.Relation.Status == AddToCart.CartStatus.InCart);
            foreach (var c in cart)
            {
                Resources.CartModel cm = new Resources.CartModel();
                var prodInfo = _sportsShopDBContext.GetProduct(c.Node.Id);
                cm.image = prodInfo.Imagen;
                cm.Name = prodInfo.Name;
                cm.price = prodInfo.Precio;
                cm.prodId = c.Node.Id;
                cm.quantity = c.Relation.Quantity;
                carts.Add(cm);
            }

            return carts;
        }

        [HttpPut("cart/{id}")]
        public Cart UpdateProdToCart(string id, Cart prod)
        {
            UserMDB user = _sportsShopDBContext.GetUser(id);
            ProductMDB product = _sportsShopDBContext.GetProduct(prod.ProductId);

            AddToCart cartAdd = _graphContext
                .GetRelations<AddToCart>(user, product)
                .Where(c => c.Status == AddToCart.CartStatus.InCart)
                .FirstOrDefault();

            bool itemInCart = cartAdd != null;
            if (itemInCart && cartAdd.Status == AddToCart.CartStatus.InCart)
            {
                cartAdd.Quantity = prod.Quantity;
                cartAdd.Date = System.DateTime.Now;
                _graphContext.UpdateRelation(user, cartAdd, product);
            }

            return prod;
        }

        [HttpDelete("cart/{id}/{prodId}")]
        public List<CartModel> DeleteProdToCart(string id, string prodId)
        {
            UserMDB user = _sportsShopDBContext.GetUser(id);
            ProductMDB product = _sportsShopDBContext.GetProduct(prodId);

            AddToCart cartAdd = _graphContext
                .GetRelations<AddToCart>(user, product)
                .Where(c => c.Status == AddToCart.CartStatus.InCart)
                .FirstOrDefault();

            bool itemInCart = cartAdd != null;
            if (itemInCart && cartAdd.Status == AddToCart.CartStatus.InCart)
            {
                cartAdd.Quantity = 0;
                cartAdd.Date = System.DateTime.Now;
                cartAdd.Status = AddToCart.CartStatus.Deleted;
                _graphContext.UpdateRelation(user, cartAdd, product);
            }

            List<CartModel> newCartID = new List<CartModel>();

            _graphContext
                .GetRelatives<AddToCart>(user)
                .Where(p => p.Relation.Status == AddToCart.CartStatus.InCart).ToList().ForEach(
                value => newCartID.Add(new CartModel { prodId = value.Node.Id, quantity = value.Relation.Quantity}));

            List<CartModel> newCart = new List<CartModel>();
            foreach (var c in newCartID)
            {
                var productInfo = _sportsShopDBContext.GetProduct(c.prodId);
                c.image = productInfo.Imagen;
                c.price = productInfo.Precio;
                newCart.Add(c);
            }

            return newCart;
        }

        // GET: api/<AdminController>
        [HttpPost("users/sname")]
        public UserMDB GetUserbyName(UserMDB user)
        {
            List<UserMDB> users = _sportsShopDBContext.GetUsers();

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

        [HttpPost("login")]
        public UserMDB GetUserbyUserName(UserInfo user)
        {
            List<UserMDB> users = _sportsShopDBContext.GetUsers();

            var userFound = new UserMDB();

            bool t = false;

            foreach (var us in users)
            {
                if (us.UserName == user.Username && us.Password == user.Password)
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
            _sportsShopDBContext.CreateUser(user);

            return user;
        }

        [HttpPost("image/{id}")]
        public async Task<ProductMDB> CreateImage([FromForm] IFormFile image, string id)
        {
            var product = _sportsShopDBContext.GetProduct(id);
            _sportsShopDBContext.UpdateProduct(id, product);

            return product;
        }

        [HttpGet("productimages/{id}")]
        public IActionResult GetMovieImages(string id)
        {
            string images = _sportsShopDBContext.GetProduct(id).Imagen;
            return Ok(images);
        }

        [HttpPost("product")]
        public ProductMDB CreateProduct(ProductMDB product)
        {
            _sportsShopDBContext.CreateProduct(product);

            return product;
        }

        [HttpGet("promo")]
        public List<PromotionMDB> getPromo()
        {
            return _sportsShopDBContext.GetPromotions();

        }

        [HttpPost("promotion")]
        public PromotionMDB CreatePromotion(PromotionMDB promotion)
        {
            _sportsShopDBContext.CreatePromotion(promotion);

            return promotion;
        }

        // GET api/<AdminController>/5
        [HttpGet("username/{uname}")]
        public bool checkUsername(string uname)
        {
            var users = _sportsShopDBContext.GetUsers();
            foreach(var user in users)
            {
                if(user.UserName == uname)
                {
                    return false;
                }
            }
            return true;
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
