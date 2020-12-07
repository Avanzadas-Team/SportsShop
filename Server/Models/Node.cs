using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Node : INode
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Node(INode obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
        }

        public Node(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public Node()
        {
        }
    }
}
