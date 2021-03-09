using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class AddProductAPI:LogIn
    {
        private static string ProductId = "product_id";
        private static string Quantity = "quantity";
        public static void AddProduct(int productId,int quantity)
        {
            var client = new RestClient(LogIn.ADD_API_URL+LogIn.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);      
            request.AlwaysMultipartFormData = true;
            request.AddParameter(ProductId, productId);
            request.AddParameter(Quantity, quantity);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);            
        }   
        public static void CheckAddProductByProductId()
        {
            try
            {               
                var expectedId = "41";
                var productId = "41";              
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
