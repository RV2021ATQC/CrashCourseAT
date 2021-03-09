using NUnit.Framework;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class GetCartInfoAPI: TestRunner
    {      
        public static void GetInfo()
        {
            var client = new RestClient(TestRunner.INFO_API_URL+ TestRunner.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);          
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
