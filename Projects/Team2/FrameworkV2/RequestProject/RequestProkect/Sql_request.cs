using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace RequestProject
{
	class Sql_request
	{
		[Test]
		public static string ConnectionAndExecutionOfCommands(string _command)
		{
			string result;

			try
			{
				MySqlConnection connection = new MySqlConnection(Connection.connectionToDataBase("127.0.0.1", "root", "", "store"));
				connection.Open();

				MySqlCommand command = new MySqlCommand(_command, connection);

				result = Convert.ToString(command.ExecuteScalar().ToString());
				return result.ToString();


			}
			catch (MySqlException ex)
			{

				Console.WriteLine(ex.Message);
				throw ex;
				
			}
			catch(NullReferenceException )
			{
				return "null";
			}
			
		}
		public static string checkProduct(string productId)
		{

			string command = $@"SELECT `product_id` FROM `oc_cart` WHERE `product_id` = '{productId}'";

			return ConnectionAndExecutionOfCommands(command);

		}
		public static string getPructID(string apiToken)
		{
			string command = $@"SELECT cart_id FROM oc_cart WHERE session_id = '{apiToken}'";

			return ConnectionAndExecutionOfCommands(command);

		}



	}
}
