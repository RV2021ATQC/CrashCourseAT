using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;

namespace API
{
    public class Code_API
    {
        private string JsonToken;
        readonly string base_url;

        public Code_API(string url)
        {   
            this.base_url = url;
        }

        public int GetToken_Length(string route, string username, string key)
        {
            string url = base_url + "?route=" + route;
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("key", key);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            dynamic data = JsonConvert.DeserializeObject(content);
            JsonToken = data.api_token;
            return (JsonToken.Length);
        }

        public string CartProducts(string route)
        {
            string url = base_url + "?route=" + route + "&api_token=" + JsonToken;
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            return (content);
        }

        public (int,int) Cart_id_Find(string route, int product_id)
        {
            string content = CartProducts(route);
            dynamic data = JsonConvert.DeserializeObject(content);
            bool find = false;
            int i=0;
            (int, int) tuple = (-1,-1);
            try
            {
                while ((find == false) && (data.products[i].cart_id != null))
                {
                    if (product_id == Convert.ToInt32(data.products[i].product_id)) 
                    {
                        tuple = (data.products[i].cart_id, data.products[i].quantity);
                        find = true;
                    }
                    else { i = i + 1; }
                }
            }
            catch
            {
                Console.WriteLine($@"There is not such product_id {product_id}." );
            }
            return tuple;
        }

        public bool Cart_id_Exists(string route, int cart_id)
        {
            string content = CartProducts(route);
            dynamic data = JsonConvert.DeserializeObject(content);
            bool find = false;
            int i = 0;
            try
            {
                while ((find == false) && (data.products[i].cart_id != null))
                {
                    if (cart_id == data.products[i].cart_id)
                    {
                        find = true;
                    }
                    else { i = i + 1; }
                }
            }
            catch 
            {
                Console.WriteLine($@"There is not such cart_id {cart_id}.");
            }
            return (find);
        }

        public void CartProducts_Edit(string route, params (string param_name, int param_value) [] param)
        {
            var url = base_url + "?route=" + route + "&api_token=" + JsonToken;
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            for (int i = 0; i < param.Length; i++)
                request.AddParameter(param[i].param_name, param[i].param_value);
            IRestResponse response = client.Execute(request);
        }
    }
}
