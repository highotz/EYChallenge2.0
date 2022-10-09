namespace EYChallenge2._0.Data.Configuration
{
    public interface IDatabaseConfig
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
