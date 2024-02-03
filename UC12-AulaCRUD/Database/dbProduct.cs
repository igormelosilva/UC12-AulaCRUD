using UC12_AulaCRUD.Models;
using Npgsql;

namespace UC12_AulaCRUD.Database
{
    public class dbProduct
    {
        public bool Add(Product product)
        {
            bool result = false;

            DatabaseAccess db = new DatabaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO products " +
                        @"(name, qtd, value) " +
                        @"VALUES (@name, @qtd, @value);";

                    cmd.Parameters.AddWithValue("@name", product.name);
                    cmd.Parameters.AddWithValue("@qtd", product.qtd);
                    cmd.Parameters.AddWithValue("@value", product.value);

                    using(cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex) { }

            return result;
        }
        public List<Product> GetAll() { 
            List<Product> result = new List<Product>();
            DatabaseAccess db = new DatabaseAccess();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM products;";
                    using(cmd.Connection = db.OpenConnection())
                    using(NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.id = Convert.ToInt32(reader["id"]);
                            product.name = reader["name"].ToString();
                            product.qtd = Convert.ToInt32(reader["qtd"]);
                            product.value = float.Parse(reader["value"].ToString());

                            result.Add(product);
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
        public Product Get(int id)
        {
            DatabaseAccess db = new DatabaseAccess();
            Product product = new Product();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM products WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            product.id = Convert.ToInt32(reader["id"]);
                            product.name = reader["name"].ToString();
                            product.qtd = Convert.ToInt32(reader["qtd"]);
                            product.value = float.Parse(reader["value"].ToString());

                            return product;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return product;

        }
        public bool Delete(int id)
        {
            DatabaseAccess db = new DatabaseAccess();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM products WHERE id = @id;";
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
        public bool Update(Product product)
        {
            DatabaseAccess db = new DatabaseAccess();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE products SET name = @name, qtd = @qtd,value = @value WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", product.id);
                    cmd.Parameters.AddWithValue("@name", product.name);
                    cmd.Parameters.AddWithValue("@qtd", product.qtd);
                    cmd.Parameters.AddWithValue("@value", product.value);
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
    }
}
