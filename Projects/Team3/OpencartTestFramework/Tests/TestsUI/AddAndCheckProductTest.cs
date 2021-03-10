using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace OpencartTestFramework
{
    //[Parallelizable(ParallelScope.All)]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [AllureNUnit]
    public class AddAndCheckProductTest<T> where T : IWebDriver, new()
    {
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
        public void AddAndCheckProduct()
        {
            //Given
            var Home = new HomePage(driver);
            Home.GoToSite();
            Home.Waiter();
            Home.OpenTheMonitors();

            //When
            var Shoppingcart = new ShoppingCartPage(driver);
            Home.WantedProduct();
            Shoppingcart.AddProductToCart();
            Shoppingcart.Waiter();

            //Then
            Home.GoBackToHome();
            Shoppingcart.CheckProductInShopingCart();
            Shoppingcart.Waiter();

            //And
            Home.CheckTextInTheEnd();
        }
    }
}