using UC12_AulaCRUD.Global;
using Npgsql;

namespace UC12_AulaCRUD.Database
{
    public class DatabaseAccess
    {
        public NpgsqlConnection OpenConnection()
        {
            string connetionString = String.Format(
                "Server = {0}; User Id = {1}; Database = {2}; Port = {3}; Password = {4};",
                Config.dbHost, Config.dbUser, Config.dbName, Config.dbPort, Config.dbPass);

            NpgsqlConnection connetion = new NpgsqlConnection(connetionString);

            connetion.Open();   

            return connetion;
        }
    }
}
