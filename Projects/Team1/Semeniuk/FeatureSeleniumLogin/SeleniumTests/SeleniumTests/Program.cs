using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class Program
    {
        public static async Task Main(string[] args) => Console.ReadKey();
    }
    [Parallelizable]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    class SeleniumFirst<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [ThreadStatic]
        private IWebDriver driver;
        [SetUp]
        public void BeforeAllMethods()
        {
            driver = new TWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        [TearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        [TestCase("den25051999@gmail.com", "admin1234", "https://vseosvita.ua/", "https://vseosvita.ua/user/id1277827", "+ Додати матеріал")]
        public void FirstTest(string email, string password, string webSite, string personalOffice, string buttonText)
        {
            //Given
            Page page = new Page(driver, email, password);

            //When
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //Launching test page
            driver.Navigate().GoToUrl(webSite);


            //Click on drop-down menu if it exists(depends on screen size)
            if (page.dropDownMenu.Displayed)
                page.dropDownMenu.Click();


            //go to login page
            page.loginPageButton.Click();
            //Thread.Sleep(2000);

            //e-mail
            page.email.SendKeys(email);

            //password
            page.password.SendKeys(password);

            //login
            page.cofirmLogin.Click();

            //Checking for new(after login) functions
            driver.Navigate().GoToUrl(personalOffice);
            //Thread.Sleep(2000);

            //Then
            Assert.AreEqual(page.check.Text, buttonText);
        }
    }
}
