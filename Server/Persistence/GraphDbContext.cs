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
        private readonly static string regexPattern = "\"([^\"]+)\":";

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
        /// Updates a relation between nodeFrom and nodeTo in Neo4j.
        /// </summary>
        /// <param name="nodeFrom">Node From</param>
        /// <param name="relation">Type of the Edge</param>
        /// <param name="nodeTo">Node To</param>
        /// <returns></returns>
        public INode UpdateRelation(INode nodeFrom, IRelation relation, INode nodeTo)
        {
            string tagFrom = nodeFrom.GetType().Name.ToLower();
            string tagTo = nodeTo.GetType().Name.ToLower();
            string jsonObj = JsonConvert.SerializeObject(relation);
            string relationJson = Regex.Replace(jsonObj, regexPattern, "$1:");

            _client.Cypher.Match(toNode(nodeFrom))
                .Match(toNode(nodeTo))
                .Match($"({tagFrom})-[r:{relation.GetType().Name}]->({tagTo})")
                .Set($"r = {relationJson}").ExecuteWithoutResultsAsync();
            return nodeTo;
        }
        /// <summary>
        /// Get all Relations ot type relationType for node nodeFrom. (nodeFrom) -[T]-> (result)
        /// </summary>
        /// <param name="nodeFrom"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public IEnumerable<RelatedItem<T>> GetRelatives<T>(INode nodeFrom) where T : IRelation
        {
            string tag = nodeFrom.GetType().Name.ToLower();
            var results = _client.Cypher.Match(toNode(nodeFrom)).Match($"({tag})-[r:{typeof(T).Name}]->(n)").Return((r, n) =>
            new RelatedItem<T>{ Relation = r.As<T>(), Node = n.As<Node>()}).ResultsAsync.Result;

            return results;
        }
        /// <summary>
        /// Get all Relations ot type relationType for node nodeTo. (nodeTo) <-[T]- (result)
        /// </summary>
        /// <param name="nodeTo"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public IEnumerable<RelatedItem<T>> GetRelativesInverse<T>(INode nodeTo) where T : IRelation
        {
            string tag = nodeTo.GetType().Name.ToLower();
            var query = _client.Cypher.Match(toNode(nodeTo)).Match($"({tag})<-[r:{typeof(T).Name}]-(n)").Return((r, n) =>
            new RelatedItem<T> { Relation = r.As<T>(), Node = n.As<Node>() });
            Console.WriteLine(query.Query.QueryText);
            var results = query.ResultsAsync.Result;

            return results;
        }
        /// <summary>
        /// Check if a relation of tipe relation between nodeFrom and nodeTo
        /// </summary>
        /// <param name="nodeFrom">Node From</param>
        /// <param name="T">Type of the Edge</param>
        /// <param name="nodeTo">Node To</param>
        /// <returns>Relations between the Nodes of type relationType</returns>
        public IEnumerable<T> GetRelations<T> (INode nodeFrom, INode nodeTo) where T : IRelation
        {
            string tagFrom = nodeFrom.GetType().Name.ToLower();
            string tagTo = nodeTo.GetType().Name.ToLower();
            var results = _client.Cypher.Match(toNode(nodeFrom)).Merge(toNode(nodeTo)).Merge($"({tagFrom})-[r:{typeof(T).Name}]->({tagTo})").Return(r => r.As<T>()).ResultsAsync.Result;

            return results;
        }

        private string toRelation(IRelation obj)
        {
            return this.toRelation(obj, tag: obj.GetType().Name.ToLower());
        }

        private string toRelation(IRelation obj, string tag)
        {
            string type = obj.GetType().Name;
            string jsonObj = JsonConvert.SerializeObject(obj);

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

            string query = $"({tag}:{type} {Regex.Replace(jsonObj, regexPattern, "$1:")})";
            return query;
        }
    }
}
