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
            connection.Close();
            return products;
        }
        
        // Categories
        public static List<Supplier> GetAllSuppliers()
        {
            SqlConnection connection = DbConnectionService.Singleton.Connection;
            connection.Open();

            List<Supplier> suppliers = new List<Supplier>();
            
            using SqlCommand command = new SqlCommand("SELECT * FROM suppliers;", connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Supplier currentSupplier = new Supplier();
                currentSupplier.Id = (int)reader["id"];
                currentSupplier.Name = (string)reader["name"];
                currentSupplier.Description = (string)reader["description"];
                suppliers.Add(currentSupplier);
            }
            connection.Close();
            return suppliers;
        }

        // Suppliers
        // Orders
        // ShoppingCarts
        // Users
    }
}
