using System;

namespace Server.Models
{
    public class RelatedItem<T> where T : IRelation
    {
        public T Relation { get; set; }
        public Node Node { get; set; }
    }
}
