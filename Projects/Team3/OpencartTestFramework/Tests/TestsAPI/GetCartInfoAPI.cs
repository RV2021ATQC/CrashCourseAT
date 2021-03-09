using NUnit.Framework;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class GetCartInfoAPI:LogIn
    {
        [Test]
        public static void GetInfo()
        {
            var client = new RestClient(LogIn.INFO_API_URL+LogIn.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);          
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
