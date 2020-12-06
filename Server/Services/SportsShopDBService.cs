using MongoDB.Driver;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class SportsShopDBService
    {
        private readonly IMongoCollection<UserMDB> _users;

        private readonly IMongoCollection<ProductMDB> _products;

        private readonly IMongoCollection<PromotionMDB> _promotions;

        public SportsShopDBService(ISportsShopDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<UserMDB>(settings.UsersCollectionName);

            _products = database.GetCollection<ProductMDB>(settings.ProductsCollectionName);

            _promotions = database.GetCollection<PromotionMDB>(settings.PromotionsCollectionName);
        }

        public List<UserMDB> GetUsers() =>
            _users.Find(user => true).ToList();

        public List<ProductMDB> GetProducts() =>
            _products.Find(product => true).ToList();

        public List<PromotionMDB> GetPromotions() =>
            _promotions.Find(promotion => true).ToList();

        public UserMDB GetUser(string id) =>
            _users.Find<UserMDB>(user => user.Id == id).FirstOrDefault();

        public ProductMDB GetProduct(string id) =>
            _products.Find<ProductMDB>(product => product.Id == id).FirstOrDefault();

        public PromotionMDB GetPromotion(string id) =>
            _promotions.Find<PromotionMDB>(promotion => promotion.Id == id).FirstOrDefault();

        public UserMDB CreateUser(UserMDB user)
        {
            _users.InsertOne(user);
            return user;
        }

        public ProductMDB CreateProduct(ProductMDB product)
        {
            _products.InsertOne(product);
            return product;
        }

        public PromotionMDB CreatePromotion(PromotionMDB promotion)
        {
            _promotions.InsertOne(promotion);
            return promotion;
        }

        public void UpdateUser(string id, UserMDB userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);
        public void UpdateProduct(string id, ProductMDB productIn) =>
            _products.ReplaceOne(product => product.Id == id, productIn);
        public void UpdatePromotion(string id, PromotionMDB promotionIn) =>
            _promotions.ReplaceOne(promotion => promotion.Id == id, promotionIn);

        public void RemoveUser(string id) =>
           _users.DeleteOne(user => user.Id == id);
        public void RemoveProduct(string id) =>
            _products.DeleteOne(product => product.Id == id);
        public void RemovePromotion(string id) =>
            _promotions.DeleteOne(promotion => promotion.Id == id);

        public void RemoveUser(UserMDB userIn) =>
          _users.DeleteOne(user => user.Id == userIn.Id);
        public void RemoveProduct(ProductMDB productIn) =>
            _products.DeleteOne(product => product.Id == productIn.Id);
        public void RemovePromotion(PromotionMDB promotionIn) =>
            _promotions.DeleteOne(promotion => promotion.Id == promotionIn.Id);


    }
}
