// using Npgsql;
//
// namespace Holidaymaker.Classes
// {
//     // Klass som representerar en databasanslutning till PostgreSQL
//     public class DatabaseConnection
//     {
//         private readonly string _connectionString;
//
//         public DatabaseConnection(string connectionString)
//         {
//             _connectionString = connectionString;
//         }
//
//         // Öppnar en anslutning till databasen och returnerar NpgsqlConnection objektet
//         public NpgsqlConnection OpenConnection()
//         {
//             var connection = new NpgsqlConnection(_connectionString);
//             connection.Open();
//             return connection;
//         }
//     }
// }