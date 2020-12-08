using Neo4jClient;
using Newtonsoft.Json;
using Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Server.Persistence
{
    public class GraphDbContext
    {
        private readonly IGraphClient _client;

        public GraphDbContext(IGraphDbSettings settings)
        {
            _client = new GraphClient(new Uri(settings.ConnectionString),settings.User,settings.Password);
            _client.ConnectAsync().Wait();
        }

        /// <summary>
        /// Creates a relation between nodeForm and nodeTo in Neo4j.
        /// </summary>
        /// <param name="nodeFrom">Node From</param>
        /// <param name="relation">Type of the Edge</param>
        /// <param name="nodeTo">Node To</param>
        /// <returns></returns>
        public INode CreateRelation(INode nodeFrom, IRelation relation, INode nodeTo)
        {
            string tagFrom = nodeFrom.GetType().Name.ToLower();
            string tagTo = nodeTo.GetType().Name.ToLower();
            _client.Cypher.Merge(toNode(nodeFrom)).Merge(toNode(nodeTo)).Merge($"({tagFrom})-{toRelation(relation)}->({tagTo})").ExecuteWithoutResultsAsync();
            return nodeTo;
        }
        /// <summary>
        /// Get all Relations ot type relationType for node nodeFrom. (nodeFrom) -[relationType]-> (result)
        /// </summary>
        /// <param name="nodeFrom"></param>
        /// <param name="relationType"></param>
        /// <returns></returns>
        public IEnumerable<RelatedItem> GetRelatives(INode nodeFrom, Type relationType)
        {
            string tag = nodeFrom.GetType().Name.ToLower();
            var results = _client.Cypher.Match(toNode(nodeFrom)).Match($"({tag})-[r:{relationType.Name}]->(n)").Return((r, n) =>
            new RelatedItem { Date = r.As<Relation>().Date, Node = n.As<Node>()}).ResultsAsync.Result;

            return results;
        }
        /// <summary>
        /// Get all Relations ot type relationType for node nodeTo. (nodeTo) <-[relationType]- (result)
        /// </summary>
        /// <param name="nodeTo"></param>
        /// <param name="relationType"></param>
        /// <returns></returns>
        public IEnumerable<RelatedItem> GetRelativesInverse(INode nodeTo, Type relationType)
        {
            string tag = nodeTo.GetType().Name.ToLower();
            var results = _client.Cypher.Match(toNode(nodeTo)).Match($"({tag})<-[r:{relationType.Name}]-(n)").Return((r, n) =>
            new RelatedItem { Date = r.As<Relation>().Date, Node = n.As<Node>() }).ResultsAsync.Result;

            return results;
        }

        private string toRelation(IRelation obj)
        {
            return this.toRelation(obj, tag: obj.GetType().Name.ToLower());
        }

        private string toRelation(IRelation obj, string tag)
        {
            string type = obj.GetType().Name;
            obj = new Relation(obj);
            string jsonObj = JsonConvert.SerializeObject(obj);
            string regexPattern = "\"([^\"]+)\":";

            string query = $"[{tag}:{type} {Regex.Replace(jsonObj, regexPattern, "$1:")}]";
            return query;
        }
        private string toNode(INode obj)
        {
            return this.toNode(obj, tag: obj.GetType().Name.ToLower());
        }
        private string toNode(INode obj, string tag)
        {
            string type = obj.GetType().Name;
            obj = new Node(obj);
            string jsonObj = JsonConvert.SerializeObject(obj);
            string regexPattern = "\"([^\"]+)\":";

            string query = $"({tag}:{type} {Regex.Replace(jsonObj, regexPattern, "$1:")})";
            return query;
        }
    }
}
