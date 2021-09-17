using System;
using MySql.Data.MySqlClient;
using NLog;
using System.Collections.Generic;

namespace API
{
    public class Code_Database
    {

        private string conn_string;
        public Code_Database(string conn_string)
        {
            this.conn_string = conn_string;
        }

        public string ExecuteScalar(string queryString)
            {
            try
            {
                using (var databaseConnection = new MySqlConnection(conn_string))
                {
                    databaseConnection.Open();
                    using (var command = new MySqlCommand(queryString, databaseConnection))
                    {
                        return command.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "null";
            }
        }
        
        public bool Cart_id_Exists(int cart_id)
        {
                var queryString = $@"SELECT * FROM `oc_cart` WHERE `cart_id` = {cart_id}";
                if (ExecuteScalar(queryString) == "null") return false;
                else return true;
        }

        public List<(int, int)> ExecuteSat(string queryString)
        {
            try
            {
                using var databaseConnection = new MySqlConnection(conn_string);
                {
                    databaseConnection.Open();
                    var command = new MySqlCommand(queryString, databaseConnection);
                    var reader = command.ExecuteReader();
                    List<(int, int)> tupleList = new List<(int, int)>();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("The list: ");
                        while (reader.Read())
                        {
                            tupleList.Add((Convert.ToInt32(reader["cart_id"]),Convert.ToInt32(reader["quantity"])));
                            Console.WriteLine(reader["cart_id"] + "          " + reader["quantity"]);
                        }                  
                    }
                    else
                    {
                        Console.WriteLine("No rows found with such product_id.");
                    }
                    databaseConnection.Close();
                    return tupleList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public List<(int, int)> Get_All_cart_id_By_product_id(int product_id)
        {
            var queryString = $@"SELECT `cart_id`, `quantity` FROM `oc_cart` WHERE `product_id` = {product_id} ORDER BY `cart_id`";
            return ExecuteSat(queryString);
        }

        public int Compare_Two_Lists(List<(int cart_id_before, int quantity_before)> result1_list, List<(int cart_id_after, int quantity_after)> result2_list)
        {
            int cart_id_remove = -1;
            try
            {
                Console.WriteLine("------Start Test_Database_Add-------");
                if (result1_list.Count < result2_list.Count)
                {
                    Console.WriteLine($@"result1_list.Count={result1_list.Count} less then result2_list.Count={result2_list.Count}");
                    cart_id_remove = result2_list[result2_list.Count - 1].cart_id_after;
                }
                else if (result1_list.Count == result2_list.Count)
                {
                    for (int i = 0; i < result1_list.Count; i++)
                    {
                        if ((result1_list[i].cart_id_before == result2_list[i].cart_id_after) && (result1_list[i].quantity_before < result2_list[i].quantity_after))
                        {
                            Console.WriteLine($@"cart_id={result1_list[i].cart_id_before}, quantity_before = {result1_list[i].quantity_before} less then quantity_after = {result2_list[i].quantity_after}");
                            cart_id_remove = result2_list[i].cart_id_after;
                        }
                    }
                }
                if (cart_id_remove==-1)
                {
                    Console.WriteLine("Test_Database_Add is false because there are 2 identical lists before and after test.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cart_id_remove;
        }













    }
}
