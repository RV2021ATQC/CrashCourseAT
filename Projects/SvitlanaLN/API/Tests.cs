using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NLog;

namespace API
{
    [TestFixture]
    public class Tests
    {
        [ThreadStatic]

        public Code_API api_obj;
        public Code_Database data_obj;
        private int JsonToken_Length;
        public Logger log;
        private int cart_id_remove=0;
        const string obj_route_login = "api/login";
        const string obj_route_products = "api/cart/products";
        const string obj_route_add = "api/cart/add";
        const string obj_route_remove = "api/cart/remove";
        const string base_url = "http://127.0.0.1/opencart/index.php";
        const string conn_string = "DataSource=127.0.0.1;Port=3306;Username=root;Password=;Database=opencart;sslmode=none;";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            log = LogManager.GetCurrentClassLogger();
            log.Info("---------Setup----------");
            string obj_username = "Default";
            string obj_key = "1e1FX4GbJIgc9IiumM0WLDHYvlpShMQCBIZTtLfcrSMxGwcY565U8EwDNvw3gbwmavszjwt4wn9HvfgqI6Y1VFZKYgDaxT05oq3L0iUv12LWoV82fy5C01zhvzb9Br2YBBy9VS5v95MRphUAWHdugKQFilCQhQ1rZRca8zmV07LP6Py5YudnWfbWcp9KwOcALpMLq4eBABFjG7XiEKdXJ6ctPHAMrNIK9f5R70tg3Gk784QtrT89YOD8m81q82Dw";
            api_obj = new Code_API(base_url);
            JsonToken_Length = api_obj.GetToken_Length(obj_route_login, obj_username, obj_key);
            data_obj = new Code_Database(conn_string);
        }

               
        [Test, Order(1),Category("Api")]
                public void Test_GetToken()
                {
                    log.Info("---------Start Test_GetToken----------");
                    Assert.AreEqual(JsonToken_Length, 26);
                }

        [Test, Order(2),Category("Api")]
                public void Test_CartProducts()
                {
                    string content = api_obj.CartProducts(obj_route_products);
                    log.Info("--------Start Test_CartProducts--------");
                    Assert.True(content.Contains("products"));
                    log.Info("content: " + content);
                }
          
        [Test, Order(3),Category("Api")]
            //    [Retry(2)]
                [TestCase(40, 1)]
                [TestCase(41, 1)]
                public void Test_CartProducts_Add(int obj_product_id, int obj_quantity)
                {
                    log.Info("------Start Test_CartProducts_Add---------");
                    (int cart_id_before, int quantity_before)= api_obj.Cart_id_Find(obj_route_products, obj_product_id);
                    api_obj.CartProducts_Edit(obj_route_add, ("product_id", obj_product_id), ("quantuty", obj_quantity));
                    (int cart_id_after, int quantity_after) = api_obj.Cart_id_Find(obj_route_products, obj_product_id);
                    log.Info("product_id = " + obj_product_id + ", cart_id_before = " + cart_id_before + ", cart_id_after = " + cart_id_after + ", quantity = " + quantity_after);
                    cart_id_remove = cart_id_after;
                    Assert.True((cart_id_before < cart_id_after) || ((cart_id_before == cart_id_after) && (quantity_before < quantity_after)));
        }
          
        [Test, Order(4), Category("Api")]
                [Retry(2)]
                public void Test_CartProducts_Remove()
                {
                    log.Info("------Start Test_CartProducts_Remove---------");
                    log.Info("cart_id_remove = " + cart_id_remove);
                    api_obj.CartProducts_Edit(obj_route_remove, ("key", cart_id_remove));
                    Assert.False(api_obj.Cart_id_Exists(obj_route_products, cart_id_remove));
        }

        [Test, Order(5), Category("Database")]
      //  [TestCase(40, 1)]
        [TestCase(40, 1)]
        public void Test_Database_Add(int obj_product_id, int obj_quantity)
        {
            try
            {
                log.Info("------Start Test_Database_Add-------");
                List<(int , int)> result1_list = data_obj.Get_All_cart_id_By_product_id(obj_product_id);
                api_obj.CartProducts_Edit(obj_route_add, ("product_id", obj_product_id), ("quantuty", obj_quantity));
                List<(int , int )> result2_list = data_obj.Get_All_cart_id_By_product_id(obj_product_id);
                cart_id_remove = data_obj.Compare_Two_Lists(result1_list, result2_list);          
                Assert.True(cart_id_remove>-1);
            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
            }
        }

        [Test, Order(6), Category("Database")]
        [Retry(2)]
        public void Test_Database_Remove()
        {
            log.Info("------Start Test_Database_Remove---------");
            log.Info("cart_id_remove = " + cart_id_remove);
            api_obj.CartProducts_Edit(obj_route_remove, ("key", cart_id_remove));
            Assert.False(data_obj.Cart_id_Exists(cart_id_remove));
            log.Info("Test_Database_Remove was successful.");
        }

    }
}