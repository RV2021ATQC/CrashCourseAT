using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class RemovePruductAPI:LogIn
    {
        private static string Key = "key";
        public static void RemoveCart(int cartId)
        {
            var client = new RestClient(LogIn.REMOVE_API_URL+LogIn.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);         
            request.AlwaysMultipartFormData = true;
            //key=cart_id
            request.AddParameter(Key, cartId);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }      
        public static void CheckRemoveCartByCartId()
        {
            try
            {               
                var cartId = "51";                              
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
