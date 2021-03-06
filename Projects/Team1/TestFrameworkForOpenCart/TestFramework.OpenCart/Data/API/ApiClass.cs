﻿using Newtonsoft.Json;
using NLog;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.OpenCart
{
    public interface IHost
    {
        ISetFile SetHost(string host);
    }

    public interface ISetFile
    {
        ISetKey SetFile(string file);
    }

    public interface ISetKey
    {
        ISetUsername SetKey(string key);
    }

    public interface ISetUsername
    {
        ISetUsername SetUsername(string username);
        IOpencartAPI Build();
    }
    public interface IOpencartAPI
    {
        string GetHost();
        string GetFile();
        string GetKey();
        string GetUsername();
        string GetToken();
        void AddToCart(string JsonToken, int product_id, int quantity);
        dynamic GetProducts(string JsonToken);
        void ChangeProduct(string JsonToken, int cartId, int quantity);
        void RemoveProduct(string JsonToken, int cartId);
    }
    class Api : IHost, ISetFile, ISetKey,
        ISetUsername, IOpencartAPI
    {
        private string FULL_PATH_TO_FILE = "C:\\Users\\Den25\\Documents\\GitHub\\CrashCourseAT\\Projects\\Team1\\TestFrameworkForOpenCart\\TestFramework.OpenCart\\Data\\Api.csv";
        private Method method;
        private IRestClient client;
        private string host;
        private string file;
        private string key;
        private string username;

        public IOpencartAPI Build()
        {
            return this;
        }
        public static IHost Get()
        {
            return new Api();
        }

        public ISetFile SetHost(string host)
        {
            this.host = host;
            return this;
        }

        public ISetKey SetFile(string file)
        {
            this.file = file;
            return this;
        }
        public ISetUsername SetKey(string key)
        {
            this.key = key;
            return this;
        }
        public ISetUsername SetUsername(string username)
        {
            this.username = username;
            return this;
        }

        public string GetHost()
        {
            return host;
        }

        public string GetFile()
        {
            return file;
        }
        public string GetKey()
        {
            return key;
        }

        public string GetUsername()
        {
            return username;
        }
        public IOpencartAPI ApiData()
        {
            var apiCollection = new Reader(FULL_PATH_TO_FILE).ReadApis();
            return Api.Get()
                .SetHost(apiCollection[0].Host)
                .SetFile(apiCollection[0].File)
                .SetKey(apiCollection[0].Key)
                .SetUsername(apiCollection[0].Username)
                .Build();
        }
        public string GetToken()
        {
            var client = new RestClient($"{host}/index.php?route=api/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("key", key);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);
            Console.WriteLine(data.api_token);
            return data.api_token;
        }
        public void AddToCart(string JsonToken, int product_id, int quantity)
        {
            var client = new RestClient($"{host}/{file}?route=api/cart/add&api_token={JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("product_id", product_id);
            request.AddParameter("quantity", quantity);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public dynamic GetProducts(string JsonToken)
        {
            var client = new RestClient($"{host}/{file}?route=api/cart/products&api_token={JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            string source = response.Content;
            dynamic data = JsonConvert.DeserializeObject(source);
            return data;
        }
        public void ChangeProduct(string JsonToken, int cartId, int quantity)
        {
            var client = new RestClient($"{host}/{file}?route=api/cart/edit&api_token={JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("key", cartId);
            request.AddParameter("quantity", quantity);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public void RemoveProduct(string JsonToken, int cartId)
        {
            var client = new RestClient($"{host}/{file}?route=api/cart/remove&api_token={JsonToken}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("key", cartId);
            request.AddHeader("Cookie", "currency=USD; language=en-gb");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}

