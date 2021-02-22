using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SeleniumTests
{
    class DBWork
    {
        private static readonly string _connectionString = @"Data Source=127.0.0.1;port=3309;username=admin;password=admin;Initial Catalog=storedb;Integrated Security=True";

        public static void ExecuteQuery(string queryString)
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
                        command.ExecuteScalar();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Show any error message.
                Console.WriteLine(ex.Message);
                //throw ex;
            }
        }
        public static void DeleteCustomer(string firstName, string lastName, string email, string telephone)
        {
            var queryString = $@"DELETE FROM `oc_customer` WHERE `firstname` = '{firstName}' AND `lastname` = '{lastName}' AND `email` = '{email}' AND `telephone` = '{telephone}'";
            ExecuteQuery(queryString);
        }
    }
}
