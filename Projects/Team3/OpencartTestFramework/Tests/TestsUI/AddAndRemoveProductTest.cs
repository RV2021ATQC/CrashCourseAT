using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace OpencartTestFramework
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [AllureNUnit]
    public class AddAndRemoveProductTest <T> where T : IWebDriver, new()
    {
        public const string URL = "https://demo.opencart.com/";
        private IWebDriver driver;

        [SetUp]
        public void BeforeAllMethods()
        {
            driver = new T();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
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
            driver.Navigate().GoToUrl(URL);

            //When
            var Shoppingcart = new ShoppingCartPage(driver);
            Home.SeachProductInField();
            Shoppingcart.AddSearchProduct();

            //Then
            Home.GoBackToHome();
            Shoppingcart.CheckProductInShopingCart();
            Home.CheckAvailableProduct();

            //And
            Shoppingcart.DeleteProductFromShoppingCart();
            Shoppingcart.CheckDeletedProductFromCart();
        }
    }
}