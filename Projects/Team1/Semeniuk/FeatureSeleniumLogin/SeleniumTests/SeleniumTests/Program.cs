using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace SeleniumTests
{
    class SeleniumFirst
    {
        public static async Task Main(string[] args) { Console.ReadKey(); }
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Manage().Timeouts().PageLoad();
        }


        [OneTimeTearDown]
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launching test page
            driver.Navigate().GoToUrl(webSite);

            
            //Click on drop-down menu
            page.dropDownMenu.Click();


            //go to login page
            page.loginPageButton.Click();

            //e-mail
            page.email.SendKeys(email);

            //password
            page.password.SendKeys(password + Keys.Enter);
            //Thread.Sleep(2000);

            //Checking for new(after login) functions
            driver.Navigate().GoToUrl(personalOffice);
            //Thread.Sleep(2000);

            //Then
            Assert.AreEqual(page.check.Text, buttonText);
        }
    }
}
