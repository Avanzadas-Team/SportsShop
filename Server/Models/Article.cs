using Newtonsoft.Json;
using System.Collections.Generic;

namespace Server.Models
{
    public class Article : INode
    {
        public string Id { get; set; }
        public string Name { get; set ; }
        public string Make { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Sports { get; set; }
        public bool LimitEd { get; set; }
        public ArticleType Type { get; set; }
        public string ImageId { get; set; }
    }
    public enum ArticleType
    {
        Clothe, Article
    }
}
