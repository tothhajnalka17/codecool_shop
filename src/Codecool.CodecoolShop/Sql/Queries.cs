using Codecool.CodecoolShop.Services;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using Codecool.CodecoolShop.Models;
using NuGet.Protocol.Core.Types;

namespace Codecool.CodecoolShop.Sql
{
    public static class Queries
    {
        // Orders
        // ShoppingCarts

        // Users
        // Insert user
        public static void InsertUser(Registration registration)
        {
            SqlConnection connection = DbConnectionService.Singleton.Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("INSERT INTO users(name, email, password) VALUES(@name, @email, @password);", connection);

            command.Parameters.AddWithValue("@name", registration.Name);
            command.Parameters.AddWithValue("@email", registration.Email);
            command.Parameters.AddWithValue("@password", registration.Password);

            using SqlDataReader reader = command.ExecuteReader();

            connection.Close();
        }

        // Get user by email
        public static User GetUserByEmail(string email)
        {
            SqlConnection connection = DbConnectionService.Singleton.Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("SELECT * FROM users WHERE email=@email;", connection);
            command.Parameters.AddWithValue("@email", email);

            using SqlDataReader reader = command.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
                user = new User((string)reader["name"], (string)reader["email"], (string)reader["password"]);
                user.ID = (int)reader["id"];
            }
            reader.Close();
            connection.Close();

            return user;
        }

        // Check username
        public static bool CheckIfUsernameExists()
        {
            return false;
        }

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
        public static List<ProductCategory> GetAllCategories()
        {
            SqlConnection connection = DbConnectionService.Singleton.Connection;
            connection.Open();

            List<ProductCategory> categories = new List<ProductCategory>();

            using SqlCommand command = new SqlCommand("SELECT * FROM categories;", connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ProductCategory currentCategory = new ProductCategory();
                currentCategory.Id = (int)reader["id"];
                currentCategory.Name = (string)reader["name"];
                currentCategory.Department = (string)reader["department"];
                currentCategory.Description = (string)reader["description"];
                categories.Add(currentCategory);
            }
            connection.Close();
            return categories;
        }
    }
}
