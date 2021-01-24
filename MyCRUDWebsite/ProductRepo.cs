using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using NathansCRUDWebsite.Models;
using MySql.Data.MySqlClient;

namespace NathansCRUDWebsite
{
    public class ProductRepo
    {
        public static string connectionString;

        public List<Product> GetProducts()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID, Name, Price, CategoryID, OnSale, StockLevel FROM products;";

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product row = new Product();
                    row.ProductID = reader.GetInt32("ProductID");
                    row.Name = reader.GetString("Name");
                    

                    if (reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        row.Price = null;
                    }
                    else
                    {
                        row.Price = reader.GetDouble("Price");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("CategoryID")))
                    {
                        row.CategoryID = null;
                    }
                    else
                    {
                        row.CategoryID = reader.GetInt32("CategoryID");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("OnSale")))
                    {
                        row.OnSale = null;
                    }
                    else
                    {
                        row.OnSale = reader.GetInt32("OnSale");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("StockLevel")))
                    {
                        row.StockLevel = null;
                    }
                    else
                    {
                        row.StockLevel = reader.GetInt32("StockLevel");
                    }

                    products.Add(row);
                }
                return products;
            }
        }

        public void CreateProducts(Product p)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products(Name, Price, CategoryID, OnSale, StockLevel) VALUES(@name, @price, @catid, @sale, @stock);";
                cmd.Parameters.AddWithValue("name", p.Name);
                cmd.Parameters.AddWithValue("price", p.Price);
                cmd.Parameters.AddWithValue("catid", p.CategoryID);
                cmd.Parameters.AddWithValue("sale", p.OnSale);
                cmd.Parameters.AddWithValue("stock", p.StockLevel);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product p)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE products SET Name=@name, Price=@price, CategoryID=@catid, StockLevel=@stock, OnSale=@sale" +
                    " WHERE ProductID=@id;";
                cmd.Parameters.AddWithValue("name", p.Name);
                cmd.Parameters.AddWithValue("price", p.Price);
                cmd.Parameters.AddWithValue("catid", p.CategoryID);
                cmd.Parameters.AddWithValue("stock", p.StockLevel);
                cmd.Parameters.AddWithValue("sale", p.OnSale);
                cmd.Parameters.AddWithValue("id", p.ProductID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID=@id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
