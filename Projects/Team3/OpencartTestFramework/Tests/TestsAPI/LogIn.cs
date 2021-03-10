using Newtonsoft.Json;
using NLog;
using NUnit.Framework;
using OpencartTestFramework.Data;
using RestSharp;
using System;

namespace OpencartTestFramework
{
    [TestFixture]
    public class TestRunner
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static  string JsonToken;

        public const string REMOVE_API_URL = "http://127.0.0.1/opencart/index.php?route=api/cart/remove&api_token=";
        public const string ADD_API_URL = "http://127.0.0.1/opencart/index.php?route=api/cart/add&api_token=";
        public const string EDIT_API_URL = "http://127.0.0.1/opencart/index.php?route=api/cart/edit&api_token=";
        public const string INFO_API_URL = "http://127.0.0.1/opencart/index.php?route=api/cart/products/&api_token=";
        public const string LOGIN_API_URL = "http://127.0.0.1/opencart/index.php?route=api/login";

        private static string userName = "username";
        private static string key = "key";

        [OneTimeSetUp]      
        public static void Login()
        {
            UserData user = new UserData();
            logger.Info("Starting...");
            var client = new RestClient(LOGIN_API_URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter(userName, user.userName);
            request.AddParameter(key, user.apiToken);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);
            JsonToken = data.api_token;         
            Console.WriteLine($"Api token is  : {data.api_token}");
        }
    }
}
