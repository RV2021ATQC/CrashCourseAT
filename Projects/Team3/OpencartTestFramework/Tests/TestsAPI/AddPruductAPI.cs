using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class AddProductAPI : RestTests
    {
        [Test,Order(1)]
        public static void AddProduct()
        {
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/cart/add&api_token=ff7e87b179375856d3c691872a");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);      
            request.AlwaysMultipartFormData = true;
            request.AddParameter("product_id", "43");
            request.AddParameter("quantuty", "1");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }
        [Test,Order(2)]
        public static void CheckAddProductByProductId()
        {
            try
            {               
                var expectedId = "44";
                var productId = "44";              
                var command = DbContext.GetPruductById(productId);

                Assert.AreEqual(command, expectedId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
