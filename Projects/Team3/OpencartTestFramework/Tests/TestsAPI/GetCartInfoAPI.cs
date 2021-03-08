using NUnit.Framework;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class GetCartInfoAPI:RestTests
    {
        [Test]
        public void GetInfo()
        {
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/cart/products/&api_token=ff7e87b179375856d3c691872a");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);          
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
