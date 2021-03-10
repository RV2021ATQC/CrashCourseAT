using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class AddProductAPI: TestRunner
    {
        private static string ProductId = "product_id";
        private static string Quantity = "quantity";
        public static void AddProduct(int productId,int quantity)
        {
            logger.Info("Starting Add product Test");
            var client = new RestClient(TestRunner.ADD_API_URL+ TestRunner.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);      
            request.AlwaysMultipartFormData = true;
            request.AddParameter(ProductId, productId);
            request.AddParameter(Quantity, quantity);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            logger.Info("Done");
        }   
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
