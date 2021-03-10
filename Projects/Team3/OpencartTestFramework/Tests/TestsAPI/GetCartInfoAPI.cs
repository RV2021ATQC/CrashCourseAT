using NUnit.Framework;
using RestSharp;
using System;

namespace OpencartTestFramework.Tests.TestsAPI
{
    public class GetCartInfoAPI: TestRunner
    {      
        public static void GetInfo()
        {
            logger.Info("Starting Get Info Test");
            var client = new RestClient(TestRunner.INFO_API_URL+ TestRunner.JsonToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);          
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            logger.Info("Done");
        }
    }
}
