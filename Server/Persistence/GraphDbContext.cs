using Neo4j.Driver;
using System;

namespace Server.Persistence
{
    public class GraphDbContext : IDisposable
    {
        private readonly IDriver _driver;

        public GraphDbContext(IGraphDbSettings settings)
        {
            _driver = GraphDatabase.Driver(settings.ConnectionString, AuthTokens.Basic(settings.User, settings.Password));
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
