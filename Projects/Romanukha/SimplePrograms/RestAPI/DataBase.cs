using MySql.Data.MySqlClient;
using System;
//using System.Data.SqlClient;

namespace RestAPI
{
    public static class Database
    {

        private static readonly string _connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database= bitnami_opencart;";

        //public static void ExecuteQueryOld(string queryString, string message = "", bool isTenantsDB = false)
        //{

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();

        //        Console.WriteLine(message);
        //    }
        //} 


        public static string ExecuteQuery(string queryString)
        {
            try
            {
                // Open the database
                using var databaseConnection = new MySqlConnection(_connectionString);
                databaseConnection.Open();

                //      queryString = "SELECT `firstname` FROM `oc_customer` WHERE `customer_id` = 2";
                var command = new MySqlCommand(queryString, databaseConnection);

                // Execute the query
                var result = command.ExecuteScalar().ToString();
                Console.WriteLine($"Result = {result}");
                throw new Exception("Test exception");
                return result;
            }
            catch (Exception ex)
            {
                // Show any error message.
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public static string GetFirstnameById(string userId)
        {
            var queryString = $@"SELECT `firstname` FROM `oc_customer` WHERE `customer_id` = {userId}";
           // var queryString = "SELECT `firstname` FROM `oc_customer` WHERE `customer_id` = 2";

            return ExecuteQuery(queryString);
        }


        //public static string GetFirstnameById(string scholarId)
        //{
        //    var queryString = $@"SELECT `firstname` FROM `oc_customer` WHERE `customer_id` = {scholarId}";

        //    var value = "";

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = new SqlCommand(queryString, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            value = (string)reader["firstname"];
        //        }

        //        Console.WriteLine($"Read from MySQL = {value}");

        //        return value.ToString();
        //    }
        //}

        //public static int ReadIntValues(string query)
        //{
        //    var value = 0;
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = new SqlCommand(query, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            value = reader.GetInt32(0);
        //        }

        //        return value;
        //    }
        //}


        //public static void CleanContacts(string scholarID)
        //{
        //    var queryClearScholarContacts = $"DELETE FROM tblxScholarContact WHERE ScholarID ='{scholarID}';";
        //    ExecuteQuery(queryClearScholarContacts);

        //    var queryClearContacts = $"DELETE FROM tblContact WHERE Email = 'Tester@invalid.com';";
        //    ExecuteQuery(queryClearContacts, "tblContact is cleaned");
        //}


        //public static string GetStudentsTaskIdByTitle(string scholarID, string title)
        //{
        //    var queryString = $@" SELECT [TaskId] FROM [dbo].[tblTask]
        //                WHERE [ScholarID]= '{scholarID}' AND [Title] = '{title}'";
        //    var value = 0;

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = new SqlCommand(queryString, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            value = (int)reader["TaskId"];
        //        }

        //        Console.WriteLine($"TaskId = {value}");

        //        return value.ToString();
        //    }
        //}
    }
}