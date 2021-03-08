using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
   public  class EditProductQuantityAPI:RestTests
       
    {
        [Test,Order(1)]
        public static void EditQuantity()
        {
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/cart/edit&api_token=ff7e87b179375856d3c691872a");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //key=cart_Id
            request.AddParameter("key", "34");
            request.AddParameter("quantity", "2");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [Test,Order(2)]
        public static void CheckQuantiny()
        {
            try
            {                     
                var cartId = "34";
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
