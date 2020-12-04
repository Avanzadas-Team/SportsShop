namespace Server.Persistence
{
    public interface IGraphDbSettings
    {
        string ConnectionString { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
    public class GraphDbSettings : IGraphDbSettings
    {
        public string ConnectionString { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
