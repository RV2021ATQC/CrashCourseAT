using MySql.Data.MySqlClient;
using System;

namespace OpencartTestFramework.Data
{
    public static class DbContext

    {
        private static readonly string _connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bitnami_opencart;";
        public static string ExecuteQuery(string queryString)
        {
            try
            {
                using var databaseConnection = new MySqlConnection(_connectionString);
                databaseConnection.Open();

                var command = new MySqlCommand(queryString, databaseConnection);

                var result = command.ExecuteScalar().ToString();
                Console.WriteLine($"Result = {result}");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public static string GetPruductById(string productId)
        {
            var queryString = $@"SELECT `product_id` FROM `oc_cart` WHERE `product_id` = {productId}";
            return ExecuteQuery(queryString);
        }

        public static string GetQuantityByCartId(string cartId)
        {
            var queryString = $@"SELECT `quantity` FROM `oc_cart` WHERE `cart_id`={cartId}";
            return ExecuteQuery(queryString);
        }
        public static string GetCartByCartId(string cartId)
        {
            var queryString = $@"SELECT `cart_id` from `oc_cart` WHERE `cart_id`={cartId}";
            return ExecuteQuery(queryString);
        }
    }
}

