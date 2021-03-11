using System;
using Microsoft.CSharp;
using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using NLog;
using System.Collections.Generic;
using RequestProject;

namespace RequestProject
{
	public class RestApiTest
	{
		public Logger log = LogManager.GetCurrentClassLogger();
		public string apiToken;

		//[Test, Order(1)]
		public void getToken()
		{
			log.Info("Start Get Token test");
			var client = new RestClient("http://localhost/opencart/index.php?route=api/login");
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("username", "Default");
			request.AddHeader("key", "4zbtL0scmCRT3vMynOkbxxfdURdlbAKrTOajMU7zpeDKRE32Pfnex9YQ8wLTg0eX643yBn9FmBX0ui1hfOO9Xw7gPVUkkw4wJT9ekeJmAn0ulo7zMK2nu7kPEa3KdBo9riSLgRf7OQ9HA5mokdGIeOw9OmdY1qKGLnZb9HWwaCsWyJg2GiyQNAZCMIy8ihAqL87t3S8l6wXarAX21PQFw9vmvuyxcy5R8QsJkDt7xlbsLw1ddvizeK3AQf2v8j0s");
			request.AddParameter("username", "Default");
			request.AddParameter("key", "4zbtL0scmCRT3vMynOkbxxfdURdlbAKrTOajMU7zpeDKRE32Pfnex9YQ8wLTg0eX643yBn9FmBX0ui1hfOO9Xw7gPVUkkw4wJT9ekeJmAn0ulo7zMK2nu7kPEa3KdBo9riSLgRf7OQ9HA5mokdGIeOw9OmdY1qKGLnZb9HWwaCsWyJg2GiyQNAZCMIy8ihAqL87t3S8l6wXarAX21PQFw9vmvuyxcy5R8QsJkDt7xlbsLw1ddvizeK3AQf2v8j0s");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			string content = response.Content;
			dynamic parsed = JsonConvert.DeserializeObject(content);
			apiToken = parsed.api_token;
			try
			{
				log.Info("Try write file to apiData.txt");
				string writePath = @"E:\apiData.txt";
				using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
				{
					log.Info("Writing to file is successful");
					sw.WriteLine(apiToken);
				}
			}
			catch (Exception e)
			{
				log.Error("Error writing to file. Kode(" +e.Message +")");
				Console.WriteLine(e.Message);
			}
			log.Info("End Get Token test");
			Console.WriteLine($"parsed  {apiToken}");

		}
		private void readToken()
		{
			log.Info("Read file from apiData.txt");
			string readPath = @"E:\apiData.txt";
			try
			{
				using (StreamReader sr = new StreamReader(readPath))
				{
					apiToken = sr.ReadLine();
					log.Info("File read, apiToken = "+apiToken);
				}
			}
			catch (Exception e)
			{
				log.Error("The file was not read. Kode("+ e.Message+")");
				Console.WriteLine(e.Message);
			}

		}
		//[Test,Order(2)]
		public void getCart()
		{
			log.Info("Start read cart test");
			readToken();
			var client = new RestClient("http://localhost/opencart/index.php?route=api/cart/products/&api_token=" + apiToken);
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			try
			{
				log.Info("Try read cart");
				request.AddHeader("api_token", apiToken);
				request.AddHeader("Cookie", "OCSESSID=4694d5e74bbdbca0950ab5d503; currency=USD; language=en-gb");
				IRestResponse response = client.Execute(request);
				Console.WriteLine(response.Content);
			}
			catch (Exception e)
			{
				log.Error("The cart was not read. Kode(" + e.Message + ")");
				Console.WriteLine(e.Message);
			}
			Assert.True(apiToken.Length == 26);
			log.Info("End read cart test");

		}
		//[Test, Order(3)]
		public void addProductToCart()
		{
			log.Info("Start add product test");
			readToken();
			var client = new RestClient($"http://localhost/opencart/index.php?route=api/cart/add&api_token=" + apiToken);
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			try
			{
				log.Info("Try add product to cart");
				request.AddHeader("api_token", apiToken);
				request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				request.AddHeader("Cookie", "OCSESSID=4694d5e74bbdbca0950ab5d503; currency=USD; language=en-gb");
				request.AddParameter("product_id", "18");
				request.AddParameter("quantuty", "1");
				IRestResponse response = client.Execute(request);
			}
			catch (Exception e)
			{
				log.Error("The product was not add. Kode(" + e.Message + ")");
				Console.WriteLine(e.Message);
			}
			log.Info("End add product test");
		}
        //[Test, Order(4)]
        public void removeProductFromCart()
        {
            log.Info("Start remove product test");
            readToken();
            var client = new RestClient("http://localhost/opencart/index.php?route=api/cart/remove&api_token=" + apiToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            string productID = Sql_request.getPructID(apiToken);
            try
            {
                request.AddHeader("Cookie", "OCSESSID=4694d5e74bbdbca0950ab5d503; currency=USD; language=en-gb");
                request.AddParameter("key", productID);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {
                log.Error("The product was not remove. Kode(" + e.Message + ")");
                Console.WriteLine(e.Message);
            }

            log.Info("End remove product test");
        }
        //[Test]
        public void checkProduct()
        {
            log.Info("Start check product test");
            readToken();
            // prepare
            string expertedResult = "18";

            // action 

            string result = Sql_request.checkProduct(expertedResult);

            //verefication
            Assert.AreEqual(result, expertedResult);

            log.Info("End check product test");

        }
        //[Test]
        public void checkRemoveProduct()
        {
            log.Info("Start check remove product test");
            // prepare
            string product = "18";
            string expertedResult = "null";

            // action 

            string result = Sql_request.checkProduct(product);

            //verefication
            Assert.AreEqual(result, expertedResult);
            log.Info("End check remove product test");
        }



    }
}
