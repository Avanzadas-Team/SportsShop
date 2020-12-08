using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class SportsShopDBSettings : ISportsShopDBSettings
    {
        public string UsersCollectionName { get; set; }
        public string ProductsCollectionName { get; set; }
        public string PrmotionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class ISportsShopDBSettings
    {
        public string UsersCollectionName { get; set; }
        public string ProductsCollectionName { get; set; }
        public string PromotionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
