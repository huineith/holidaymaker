namespace app;
using Npgsql;


public class Queries
{
    protected string _queri; 
    protected NpgsqlDataSource _database;
    public Queries(NpgsqlDataSource database)
    {
        _database = database;
    }
}