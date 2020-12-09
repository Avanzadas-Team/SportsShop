using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Persistence;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminQueryController : ControllerBase
    {
        private readonly GraphDbContext _graphContext;

        private readonly SportsShopDBContext _sportsShopDBContext;

        public AdminQueryController(
            GraphDbContext graphDbContext,
            SportsShopDBContext sportsShopDBService
        )
        {
            _graphContext = graphDbContext;
            _sportsShopDBContext = sportsShopDBService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _sportsShopDBContext.GetUsers().Where(u=> u.role==1).ToList();
            List<Resources.Users> uList = new List<Resources.Users>();
            foreach (var u in users)
            {
                Resources.Users usr = new Resources.Users
                {
                    id = u.Id,
                    name = u.Name + " " + u.LName,
                    userName = u.UserName
                };
                uList.Add(usr);
            }
            return Ok(uList);
        }
        [HttpGet("history/{id}")]
        public async Task<IActionResult> SearchClientHistory(string id)
        {
            var user = _sportsShopDBContext.GetUser(id);
            List<Resources.Article> articlesBought =
                new List<Resources.Article>();
            var articles = _graphContext.GetRelatives<Bought>(user);

            var products = _sportsShopDBContext.GetProducts();

            foreach (var item in products)
            {
                foreach (var article in articles)
                {
                    if (article.Node.Id.Equals(item.Id))
                    {
                        var add =
                            new Resources.Article(article.Relation.Date, item);
                        articlesBought.Add (add);
                    }
                }
            }

            return Ok(articlesBought);
        }
        [HttpGet("aqproducts")]
        public async Task<IActionResult> AquiredProducts()
        {
            List<Resources.AquiredArticle> allProducts = new List<Resources.AquiredArticle>();
            IEnumerable<ProductMDB> products = _sportsShopDBContext.GetProducts();
            foreach (ProductMDB product in products)
            {
                var sales = _graphContext.GetRelativesInverse<Bought>(product).ToList();
                if (sales.Count > 0)
                    allProducts.Add(new Resources.AquiredArticle { Quantity = sales.Count, Article = product });
            }
            return Ok(allProducts);
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(_sportsShopDBContext.GetProducts());
        }

        [HttpGet("prods")]
        public async Task<IActionResult> ProductSearch()
        {
            List<Resources.Product> pList = new List<Resources.Product>();
            var products = _sportsShopDBContext.GetProducts().ToList();
            foreach(var p in products)
            {
                Resources.Product prod = new Resources.Product();
                prod.id = p.Id;
                prod.nameAndBrand = p.Name + " - " + p.Marca;
                pList.Add(prod);
            }
            return Ok(pList);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> SearchProduct(string id)
        {
           var prod = _sportsShopDBContext.GetProduct(id);
            Resources.ProductInfo productInfo =  new Resources.ProductInfo();
            productInfo.name = prod.Name;
            productInfo.brand = prod.Marca;
            productInfo.price = prod.Precio;
            if (prod.EdicionLim == false)
            {
                productInfo.ed = "Standar";
            }
            else
            {
                productInfo.ed = "Limited Edition";
            }
            productInfo.units = prod.UnDisp;
            productInfo.image = prod.Imagen;
            int i = 0;
            foreach(var d in prod.Deportes)
            {
                productInfo.sports += prod.Deportes.ElementAt(i) + "";
            }
            return Ok(productInfo);
        }

        [HttpGet("common/{id}")]
        public async Task<IActionResult> SearchClientsInCommon(string id)
        {
            var user = _sportsShopDBContext.GetUser(id);
            List<Resources.CommonUser> users = new List<Resources.CommonUser>();
            var articles = _graphContext.GetRelatives<Bought>(user);
            foreach (var article in articles)
            {
                var commonUsers = _graphContext.GetRelativesInverse<Bought>(article.Node);
                foreach (var commonUser in commonUsers)
                {
                    string commonUserId = commonUser.Node.Id;
                    if(commonUserId != id)
                    {
                        UserMDB userMDB = _sportsShopDBContext.GetUser(commonUserId);
                        ProductMDB product = _sportsShopDBContext.GetProduct(article.Node.Id);

                        var alreadyInCommon = users.Where(u => u.User.Id == commonUserId).FirstOrDefault();

                        if (alreadyInCommon != null)
                            alreadyInCommon.Products.Add(product);
                        else
                        {
                            var temp = new Resources.CommonUser(user);
                            temp.Products.Add(product);
                            users.Add(temp);
                        }
                    }
                }
            }

            return Ok(users);
        }
    }
}
