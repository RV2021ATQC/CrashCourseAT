using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Firefox;

namespace OpencartTestFramework
{
    //[Parallelizable(ParallelScope.All)]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class SecondTest<T> where T : IWebDriver, new()
    {
        public const string URL = "https://demo.opencart.com/";
        private IWebDriver driver;

        [SetUp]
        public void BeforeAllMethods()
        {
            driver = new T();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
        [Test]
        public void AddAndRemoveProduct()
        {
            //Given
            var Home = new HomePage(driver);
            driver.Navigate().GoToUrl(URL); //for "demo.opencart" session
            Home.Waiter();

            //When
            var Shoppingcart = new ShoppingCartPage(driver);
            Home.SeachProductInField();
            Shoppingcart.AddSearchProduct();
            Shoppingcart.Waiter();

            //Then
            Home.GoBackToHome();
            Shoppingcart.CheckProductInShopingCart();
            Home.CheckTextInTheEnd();
            Home.Waiter();

            //And
            Shoppingcart.DeleteProductFromShoppingCart();
            Shoppingcart.CheckDeletedProductFromCart();
        }
    }
}