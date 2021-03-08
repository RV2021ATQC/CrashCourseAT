using Newtonsoft.Json;
using NLog;
using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework
{
    [TestFixture]
    public class RestTests
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        private string JsonToken;

        [OneTimeSetUp]
        public void Login()
        {
            UserData user = new UserData();
            logger.Info("Starting...");
            var client = new RestClient("http://127.0.0.1/opencart/index.php?route=api/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("username", user.userName);
            request.AddParameter("key", user.apiToken);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);
            JsonToken = data.api_token;
            Console.WriteLine("Great , login test is passed!");
            Console.WriteLine($"Api token is  : {data.api_token}");
        }
    }
}
