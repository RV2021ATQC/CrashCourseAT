using NUnit.Framework;
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
    public class APIRestTest : ABaseTest
    {
        
        private string JsonToken;
        private int cartId;
        IOpencartAPI api;

        [OneTimeSetUp]
        public void GetToken()
        {
            api = new Api().ApiData();
            JsonToken = api.GetToken();
        }
        [Test]
        [Order(1)]
        public void TokenValidation()
        {
            Console.WriteLine(JsonToken);
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
        [TestCase(41, 4)]
        public void AddProduct(int product_id, int quantity)
        {
            //Given
            var expectedResult = product_id.ToString() + quantity.ToString();
            log.Info("Start ReadDatabase test");

            //When
            api.AddToCart(JsonToken, product_id, quantity);

            //And
            var command = DBTest.CheckAddingToCart(JsonToken);

            //Then
            Assert.AreEqual(expectedResult, command);
        }
        [Order(3)]
        [Test]
        public void GetProducts()
        {
            //When
            var data = api.GetProducts(JsonToken);

            //Then
            try
            {
                if (data.products[0].cart_id != null)
                {
                    cartId = Convert.ToInt32(data.products[0].cart_id);
                    Console.WriteLine($"Id= {data.products[0].cart_id}");
                };
            }
            catch { Console.WriteLine("Cart is empty()"); }

            //And
            Assert.Pass();
        }
        [Order(4)]
        [Test]
        [TestCase(6)]
        public void ChangeProduct(int quantity)
        {
            //Given
            var expectedResult = quantity.ToString();
            log.Info("Start ReadDatabase test");

            //When
            api.ChangeProduct(JsonToken, cartId, quantity);

            //And
            var command = DBTest.CheckCartChange(JsonToken);

            //Then
            Assert.AreEqual(command, expectedResult);
        }
        [Order(5)]
        [Test]
        public void RemoveProduct()
        {
            //Given
            var expectedResult = "Empty";
            log.Info("Start ReadDatabase test");

            //When
            api.RemoveProduct(JsonToken, cartId);

            //And
            var command = DBTest.CheckCartEmpty(JsonToken);

            //Then
            Assert.AreEqual(command, expectedResult);
        }
    }
}
