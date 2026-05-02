namespace ChaChaClub.DataAccess
{
    public class DbSession
    {
        public string ConnectionString { get; }

        public DbSession(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}