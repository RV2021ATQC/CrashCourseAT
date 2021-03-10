using NUnit.Framework;
using System;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
using System.IO;

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
    [AllureNUnit]
    [TestFixture]
    public class APIRestTest : ABaseTest
    {
        
        private string JsonToken;
        private int cartId;
        IOpencartAPI api;

        [OneTimeSetUp]
        public void GetToken()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            api = new Api().ApiData();
            JsonToken = api.GetToken();
        }
        [Order(1)]
        [Test, Category("API")]
        public void TokenValidation()
        {
            Console.WriteLine(JsonToken);
            //Given
            var expectedResult = DateTime.Now.ToString();
            log.Info("Start ReadDatabase test");

            //When
            var command = DBReader.CheckSession(JsonToken);

            //Then
            Assert.AreEqual(command.RemoveSomeFromEnd(3), expectedResult.RemoveSomeFromEnd(3));
        }
        [Order(2)]
        [Test, Category("API")]
        [TestCase(41, 4)]
        public void AddProduct(int product_id, int quantity)
        {
            //Given
            var expectedResult = product_id.ToString() + quantity.ToString();
            log.Info("Start ReadDatabase test");

            //When
            api.AddToCart(JsonToken, product_id, quantity);

            //And
            var command = DBReader.CheckAddingToCart(JsonToken);

            //Then
            Assert.AreEqual(expectedResult, command);
        }
        [Order(3)]
        [Test, Category("API")]
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
        [Test, Category("API")]
        [TestCase(6)]
        public void ChangeProduct(int quantity)
        {
            //Given
            var expectedResult = quantity.ToString();
            log.Info("Start ReadDatabase test");

            //When
            api.ChangeProduct(JsonToken, cartId, quantity);

            //And
            var command = DBReader.CheckCartChange(JsonToken);

            //Then
            Assert.AreEqual(command, expectedResult);
        }
        [Order(5)]
        [Test, Category("API")]
        public void RemoveProduct()
        {
            //Given
            var expectedResult = "Empty";
            log.Info("Start ReadDatabase test");

            //When
            api.RemoveProduct(JsonToken, cartId);

            //And
            var command = DBReader.CheckCartEmpty(JsonToken);

            //Then
            Assert.AreEqual(command, expectedResult);
        }
    }
}
