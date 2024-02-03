using Npgsql;
using UC12_AulaCRUD.Models;

namespace UC12_AulaCRUD.Database
{
    public class DbClient
    {
        public bool Add(Client client)
        {
            bool result = false;

            DatabaseAccess db = new DatabaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO clients " +
                        @"(name, phone, email) " +
                        @"VALUES (@name, @phone, @email);";

                    cmd.Parameters.AddWithValue("@name", client.name);
                    cmd.Parameters.AddWithValue("@phone", client.phone);
                    cmd.Parameters.AddWithValue("@email", client.email);

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex) { }

            return result;
        }
        public List<Client> GetAll()
        {
            List<Client> result = new List<Client>();
            DatabaseAccess db = new DatabaseAccess();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM clients;";
                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client Client = new Client();
                            Client.id = Convert.ToInt32(reader["id"]);
                            Client.name = reader["name"].ToString();
                            Client.phone = reader["phone"].ToString();
                            Client.email = reader["email"].ToString();

                            result.Add(Client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;

        }
        public bool Delete(int id)
        {
            DatabaseAccess db = new DatabaseAccess();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM clients WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }

                }

            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool Update(Client client)
        {
            DatabaseAccess db = new DatabaseAccess();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE clients SET name = @name, phone = @phone, email = @email WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", client.id);
                    cmd.Parameters.AddWithValue("@name", client.name);
                    cmd.Parameters.AddWithValue("@phone", client.phone);
                    cmd.Parameters.AddWithValue("@email", client.email);
                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }

                }

            }
            catch (Exception)
            {
                return false;

            }
        }
        public Client Get(int id)
        {
            DatabaseAccess db = new DatabaseAccess();
            Client client = new Client();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM clients WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            client.id = Convert.ToInt32(reader["id"]);
                            client.name = reader["name"].ToString();
                            client.phone = reader["phone"].ToString();
                            client.email = reader["email"].ToString();

                            return client;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return client;

        }
    }
}
