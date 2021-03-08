using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class RemovePruductAPI:RestTests
    {
        [Test,Order(1)]
        public void RemoveCart()
        {
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/cart/remove&api_token=ff7e87b179375856d3c691872a");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);         
            request.AlwaysMultipartFormData = true;
            //key=cart_id
            request.AddParameter("key", "33");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [Test,Order(2)]
        public void CheckRemoveCartByCartId()
        {
            try
            {               
                var cartId = "33";                              
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
