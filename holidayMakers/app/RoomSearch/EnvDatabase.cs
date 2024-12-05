namespace app.RoomSearch;
using Npgsql; 
using DotNetEnv;

// Version of database With .env File was determined to solution without .env Files. 
// 
public class EnvDatabase
{


   private string _host;//= "localhost";
   private  string _port;// = "5432"; 
   private  string _username;// = "postgres";
   private string _password; //
   private readonly string _database;// = "makersofholidays";
   private NpgsqlDataSource _connection;

   public NpgsqlDataSource Connection()
   {
      
 
      return _connection; 
   }

   public EnvDatabase()
   {
      Env.TraversePath().Load();
      _host = Env.GetString("db_host");
      _port = Env.GetString("port"); 
      _username =Env.GetString("username");
      _password=Env.GetString("password"); //
      _database = Env.GetString("database");
      
      
      _connection = NpgsqlDataSource.Create(
            $"Host={_host};Port={_port};Username={_username};Password={_password};Database={_database}");
      
      using var conn = _connection.OpenConnection(); // Kontrollerar att vi har lyckats kopplat upp oss till databasen.
   }


}