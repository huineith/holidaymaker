// using System;
// using System.Data.SqlClient;
//
// namespace app.Classes
// {
//     public class Query
//     {
//         private SqlConnection _connection;
//
//         // Konstruktor för Query som accepterar en anslutningssträng
//         public Query(string connectionString)
//         {
//             _connection = new SqlConnection(connectionString);
//         }
//
//         // Metod för att öppna anslutningen
//         public void OpenConnection()
//         {
//             _connection.Open();
//         }
//
//         // Metod för att stänga anslutningen
//         public void CloseConnection()
//         {
//             _connection.Close();
//         }
//
//         // Exempel på en metod för att hämta data
//         public SqlDataReader ExecuteQuery(string query)
//         {
//             SqlCommand command = new SqlCommand(query, _connection);
//             return command.ExecuteReader();
//         }
//     }
// }