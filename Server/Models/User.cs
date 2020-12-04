using Newtonsoft.Json;
using System.Collections.Generic;

namespace Server.Models
{
    public class User : INode
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("cart")]
        public IEnumerable<int> Cart { get; set; }
    }
}
