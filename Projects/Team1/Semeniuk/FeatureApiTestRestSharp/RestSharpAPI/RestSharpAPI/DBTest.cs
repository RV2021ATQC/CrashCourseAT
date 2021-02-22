using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace RestSharpAPI
{
    class DBTest
    {
        //private static readonly string _connectionString = @"Data Source=127.0.0.1;port=3309;username=admin;password=admin;database=storedb;";
        private static readonly string _connectionString = @"Data Source=127.0.0.1;port=3309;username=admin;password=admin;Initial Catalog=storedb;Integrated Security=True";

        public static string ExecuteQuery(string queryString)
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
                // Show any error message.
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public static string CheckSession(string key)
        {
            var queryString = $@"SELECT `date_added` FROM `oc_api_session` WHERE `session_id` = '{key}'";
            return ExecuteQuery(queryString);
        }
        public static string CheckAddingToCart(string key)
        {
            var queryString = $@"SELECT `product_id`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            var secondqueryString = $@"SELECT `quantity`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            return  ExecuteQuery(queryString) + ExecuteQuery(secondqueryString);
        }
        public static string CheckCartOutput(string key)
        {
            var queryString = $@"SELECT `product_id`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            return ExecuteQuery(queryString);
        }
        public static string CheckCartChange(string key)
        {
            var queryString = $@"SELECT `quantity`  FROM `oc_cart` WHERE `session_id` = '{key}'";
            return ExecuteQuery(queryString);
        }
        public static string CheckCartEmpty(string key)
        {
            try 
            {
                var queryString = $@"SELECT *  FROM `oc_cart` WHERE `session_id` = '{key}'";
                ExecuteQuery(queryString);
            }
            catch(NullReferenceException)
            {
                return "Empty";
            }
            return "";
        }
    }
}
