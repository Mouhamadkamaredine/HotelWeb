namespace Hotel.sql
{
    public class DbConnection
    {
        public DbConnection(string connection)
        {
            this.Connection = connection;
        }
        public string Connection { get; set; }
    }
}
