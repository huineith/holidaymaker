using Npgsql;

namespace app.Database
{
    // Denna klass hanterar databaskonfigurationen och anslutningen
    public class DatabaseConfig
    {
        private readonly string _host = "localhost";
        private readonly string _port = "5432";
        private readonly string _username = "postgres";
        private readonly string _password = "-";
        private readonly string _database = "makersofholiday";
        private NpgsqlDataSource _connection;

        // Konstruktor för att sätta upp anslutningskonfigurationen
        public DatabaseConfig()
        {
            _connection = NpgsqlDataSource.Create($"Host={_host};Port={_port};Username={_username};Password={_password};Database={_database}");

            // Kontroll för att säkerställa anslutningen
            using var conn = _connection.OpenConnection();
        }

        // Metod för att hämta anslutningen
        public NpgsqlDataSource Connection()
        {
            return _connection;
        }
    }
}