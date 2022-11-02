using Codecool.CodecoolShop.Services;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Sql
{
    public static class Queries
    {
        // Products
        public static List<Product> GetAllProducts()
        {
            SqlConnection connection = DbConnectionService.Singleton.Connection;
            connection.Open();

            var products = new List<Product>();

            using SqlCommand command = new SqlCommand("SELECT * FROM products;", connection);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product currentProduct = new Product();
                currentProduct.Id = (int)reader["id"];
                currentProduct.Name = (string)reader["name"];
                currentProduct.Description = (string)reader["description"];
                currentProduct.Currency = (string)reader["currency"];
                currentProduct.DefaultPrice = (decimal)reader["defaultprice"];
                currentProduct.Category_id = (int)reader["category_id"];
                currentProduct.Supplier_id = (int)reader["supplier_id"];
                products.Add(currentProduct);
            }
            return products;
        }
        // Categories

        // Suppliers
        // Orders
        // ShoppingCarts
        // Users
    }
}
