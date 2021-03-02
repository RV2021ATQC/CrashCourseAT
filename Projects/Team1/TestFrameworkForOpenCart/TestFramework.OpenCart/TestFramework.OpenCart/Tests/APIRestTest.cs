using Newtonsoft.Json;
using NLog;
using NUnit.Framework;
using RestSharp;
using System;


namespace TestFramework.OpenCart
{
    public static class StringHelper
    {   
        public static string RemoveSomeFromEnd(this string str, int count)
        {
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - count);
            }
            else
                Console.WriteLine("Not enough symbols");
            return str;
        }
    }
    [TestFixture]
    public class APIRestTest
    {
        public RestClient NewClient(string path)
        {
            var client = new RestClient(path);
            return client;
        }
        public RestRequest NewRequest(Method method)
        {
            var newMethod = new RestRequest(method);
            return newMethod;
        }
        public void ClienExecution()
        {

        }
        public Logger log = LogManager.GetCurrentClassLogger();
        private string JsonToken;
        private int cartId;
        private readonly string host = "127.0.0.1/OpencartStore";
        private readonly string file = "index.php";
        
        [OneTimeSetUp]
        public void GetToken()
        {
            //When
            log.Info("Start");
            var client = NewClient($"http://{host}/index.php?route=api/login");
            client.Timeout = -1;
            var request = NewRequest(Method.POST);
            request.AddParameter("username", "Default");
            request.AddParameter("key", "w5VWX4p5lex9kU7Nj2abyBHAV1fnaD1zTr58wN8eNXedhs1RbWaK7yx6QrMLk7RimooeWKS33OcuWpJ4ODVQXp1rHkS88o1pau1MHeNE1aSai4EVTqLPTK6kWoJ39Ybs8xl9VZ2WBKpW517fNczKFzUuvk12o4v8WreBLVSpWe50ES8omiM0UnwWKZqIWx9RtYSZ8k9PsvGOQpDpyjjCcQfdCh5KlTm5gGtxTOkIFBP5CA7KTHYZlrCvhwN6hbKl");

            //Then
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);

            //And
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
            Assert.AreEqual(command.RemoveSomeFromEnd(3), expectedResult.RemoveSomeFromEnd(3));
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
            var client = NewClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = NewRequest(Method.POST);
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
            var client = NewClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = NewRequest(Method.GET);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);

            //Then
            try
            { if (data.products[0].cart_id != null) 
                { cartId = Convert.ToInt32(data.products[0].cart_id);
                    Console.WriteLine($"Id= {data.products[0].cart_id}");
                }; }
            catch { Console.WriteLine("Cart is empty()"); }
            finally { Console.WriteLine(response.Content); }

            //And
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
            var client = NewClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = NewRequest(Method.POST);
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
            var client = NewClient($"http://{host}/{file}?{firstQuery}{path}&{secondQuery}{JsonToken}");
            client.Timeout = -1;
            var request = NewRequest(Method.POST);
            request.AddParameter("key", cartId);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            //Then
            var command = DBTest.CheckCartEmpty(JsonToken);

            //And
            Assert.AreEqual(command, expectedResult);
        }
    }
}
