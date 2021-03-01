using System;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace RvCrashCourse2021
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

       
        public static void ExecuteQuery(string queryString, string message = "", bool isTenantsDB = false)
        {

            MySqlConnection databaseConnection = new MySqlConnection(_connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(queryString, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Do something with every received database ROW
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }
        public static void GetFirstnameById(string userId)
        {
            var queryString = $@"SELECT `firstname` FROM `oc_customer` WHERE `customer_id` = {userId}";

            ExecuteQuery(queryString, "SurveyTemplate was added");
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