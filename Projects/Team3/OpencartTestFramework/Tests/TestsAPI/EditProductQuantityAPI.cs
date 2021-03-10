using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
   public  class EditProductQuantityAPI: TestRunner
    {
        private static string Key = "key";
        private static string Quantity = "quantity";
        public static void EditQuantity(int cartId,int quantity)
        {
            logger.Info("Starting Edit Product Test");
            var client = new RestClient(TestRunner.EDIT_API_URL+ TestRunner.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //key=cart_Id
            request.AddParameter(Key, cartId);
            request.AddParameter(Quantity, quantity);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            logger.Info("Done");
        }     
        public static void CheckQuantiny()
        {
            try
            {                     
                var cartId = "75";
                var productQuantity = "2";              
                var command = DbContext.GetQuantityByCartId(cartId);

                Assert.AreEqual(command, productQuantity);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
