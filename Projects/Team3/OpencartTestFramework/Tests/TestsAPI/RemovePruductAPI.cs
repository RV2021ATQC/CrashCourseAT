using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class RemovePruductAPI: TestRunner
    {
        private static string Key = "key";
        public static void RemoveCart(int cartId)
        {
            logger.Info("Starting Remove Product Test");
            var client = new RestClient(TestRunner.REMOVE_API_URL+ TestRunner.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);         
            request.AlwaysMultipartFormData = true;
            //key=cart_id
            request.AddParameter(Key, cartId);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            logger.Info("Done");
        }      
        public static void CheckRemoveCartByCartId()
        {
            try
            {               
                var cartId = "75";                              
                var command = DbContext.GetCartByCartId(cartId);
                Assert.IsNull(command);              
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
