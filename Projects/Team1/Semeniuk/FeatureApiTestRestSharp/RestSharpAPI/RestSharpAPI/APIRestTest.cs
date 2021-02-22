using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using NUnit.Framework;
using NLog;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace RestSharpAPI
{
    [TestFixture]
    public class APIRestTest
    {
        public Logger log = LogManager.GetCurrentClassLogger();
        private string JsonToken;
        private int cartId;
        private readonly string host = "127.0.0.1/OpencartStore";
        private readonly string file = "index.php";
        public static string RemoveSomeFromEnd(int count, string str)
        {
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - count);
            }
            else
                Console.WriteLine("Not enough symbols");
            return str;
        }
        [OneTimeSetUp]
        public void GetToken()
        {
            log.Info("Start");
            var client = new RestClient("http://127.0.0.1/OpencartStore/index.php?route=api/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("username", "Default");
            //request.AddHeader("key", "w5VWX4p5lex9kU7Nj2abyBHAV1fnaD1zTr58wN8eNXedhs1RbWaK7yx6QrMLk7RimooeWKS33OcuWpJ4ODVQXp1rHkS88o1pau1MHeNE1aSai4EVTqLPTK6kWoJ39Ybs8xl9VZ2WBKpW517fNczKFzUuvk12o4v8WreBLVSpWe50ES8omiM0UnwWKZqIWx9RtYSZ8k9PsvGOQpDpyjjCcQfdCh5KlTm5gGtxTOkIFBP5CA7KTHYZlrCvhwN6hbKl");
            request.AddParameter("username", "Default");
            request.AddParameter("key", "w5VWX4p5lex9kU7Nj2abyBHAV1fnaD1zTr58wN8eNXedhs1RbWaK7yx6QrMLk7RimooeWKS33OcuWpJ4ODVQXp1rHkS88o1pau1MHeNE1aSai4EVTqLPTK6kWoJ39Ybs8xl9VZ2WBKpW517fNczKFzUuvk12o4v8WreBLVSpWe50ES8omiM0UnwWKZqIWx9RtYSZ8k9PsvGOQpDpyjjCcQfdCh5KlTm5gGtxTOkIFBP5CA7KTHYZlrCvhwN6hbKl");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);

            JsonToken = data.api_token;
            Console.WriteLine(data.api_token);
        }
        [Test]
        [Order(1)]
        public void TokenValidation()
        {
            //Given
            var expectedResult = DateTime.Now.ToString();
            log.Info("Start ReadDatabase test");

            //When
            var command = DBTest.CheckSession(JsonToken);

            //Then
            Assert.AreEqual(RemoveSomeFromEnd(3, command), RemoveSomeFromEnd(3, expectedResult));
        }
        [Test]
        [Order(2)]
        [TestCase("api/cart/add", "route=", "api_token=", 41, 4)]
        public void AddProduct(string path, string firstQuery, string secondQuery, int product_id, int quantity)
        {
            //Given
            var expectedResult = product_id.ToString() + quantity.ToString();
            log.Info("Start ReadDatabase test");

            //When
            var client = new RestClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("product_id", product_id);
            request.AddParameter("quantity", quantity);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);


            //Then
            var command = DBTest.CheckAddingToCart(JsonToken);

            //And
            Assert.AreEqual(expectedResult, command);
        }
        [Order(3)]
        [Test]
        [TestCase("api/cart/products", "route=", "api_token=")]
        public void GetProducts(string path, string firstQuery, string secondQuery)
        {
            //When
            var client = new RestClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);
            try { if (data.products[0].cart_id != null) 
                { cartId = Convert.ToInt32(data.products[0].cart_id);
                    Console.WriteLine($"Id= {data.products[0].cart_id}");
                }; }
            catch { Console.WriteLine("Cart is empty()"); }
            finally { Console.WriteLine(response.Content); }

            //Then
            Assert.Pass();
        }
        [Order(4)]
        [Test]
        [TestCase("api/cart/edit", "route=", "api_token=", 6)]
        public void ChangeProduct(string path, string firstQuery, string secondQuery, int quantity)
        {
            //Given
            var expectedResult = quantity.ToString();
            log.Info("Start ReadDatabase test");

            //When
            var client = new RestClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("key", cartId);
            request.AddParameter("quantity", quantity);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            //Then
            var command = DBTest.CheckCartChange(JsonToken);

            //And
            Assert.AreEqual(command, expectedResult);
        }
        [Order(5)]
        [Test]
        [TestCase("api/cart/remove", "route=", "api_token=")]
        public void RemoveProduct( string path, string firstQuery, string secondQuery)
        {
            //Given
            var expectedResult = "Empty";
            log.Info("Start ReadDatabase test");

            //When
            var client = new RestClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("key", cartId);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            GetProducts("api/cart/products", "route=", "api_token=");

            //Then
            var command = DBTest.CheckCartEmpty(JsonToken);

            //And
            Assert.AreEqual(command, expectedResult);
        }
    }
}
