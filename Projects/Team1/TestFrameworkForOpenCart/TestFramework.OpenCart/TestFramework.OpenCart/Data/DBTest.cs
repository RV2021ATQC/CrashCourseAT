using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace TestFramework.OpenCart
{
    class DBTest
    {
        private static readonly string _connectionString = @"Data Source=127.0.0.1;port=3309;username=admin;password=admin;Initial Catalog=storedb;Integrated Security=True";
        public static void ExecuteQuery(string queryString)
        {
            try
            {
                using (var databaseConnection = new MySqlConnection(_connectionString))
                {
                    databaseConnection.Open();
                    using (var command = new MySqlCommand(queryString, databaseConnection))
                    {
                        command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw ex;
            }
        }
        public static string ExecuteSelectQuery(string queryString)
        {
            try
            {
                // Open the database
                using (var databaseConnection = new MySqlConnection(_connectionString))
                {
                    databaseConnection.Open();
                    using (var command = new MySqlCommand(queryString, databaseConnection)) 
                    {
                        // Execute the query
                        var result = command.ExecuteScalar().ToString();
                        Console.WriteLine($"Result = {result}");

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public static string CheckSession(string key)
        {
            var queryString = $@"SELECT `date_added` FROM `oc_api_session` WHERE `session_id` = '{key}'";
            return ExecuteSelectQuery(queryString);
        }
        public static string CheckAddingToCart(string key)
        {
            var queryString = $@"SELECT `product_id`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            var secondqueryString = $@"SELECT `quantity`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            return ExecuteSelectQuery(queryString) + ExecuteSelectQuery(secondqueryString);
        }
        public static string CheckCartOutput(string key)
        {
            var queryString = $@"SELECT `product_id`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            return ExecuteSelectQuery(queryString);
        }
        public static string CheckCartChange(string key)
        {
            var queryString = $@"SELECT `quantity`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            return ExecuteSelectQuery(queryString);
        }
        public static string CheckCartEmpty(string key)
        {
            try 
            {
                var queryString = $@"SELECT *  FROM `oc_cart` WHERE `session_id` = '{key}'";
                ExecuteSelectQuery(queryString);
            }
            catch(NullReferenceException)
            {
                return "Empty";
            }
            return "";
        }
        public static void DeleteCustomer(string firstName, string lastName, string email, string telephone)
        {
            var queryString = $@"DELETE FROM `oc_customer` WHERE `firstname` = '{firstName}' AND `lastname` = '{lastName}' AND `email` = '{email}' AND `telephone` = '{telephone}'";
            ExecuteQuery(queryString);
        }
    }
}
