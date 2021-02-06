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
        }


        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
        [Test]
        public void FirstTest()
        {
            //Given
            string email = "den25051999@gmail.com";
            string password = "admin1234";
            string webSite = "https://vseosvita.ua/";
            string personalOffice = "https://vseosvita.ua/user/id1277827";
            string buttonText = "+ Додати матеріал";

            //When
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launching test page
            driver.Navigate().GoToUrl(webSite);

            Page page = new Page(driver, email, password);
            //Click on drop-down menu
            page.dropDownMenu.Click();


            //go to login page
            page.loginPageButton.Click();

            //e-mail
            page.email.SendKeys(email);

            //password
            page.password.SendKeys(password + Keys.Enter);
            Thread.Sleep(2000);

            //Checking for new(after login) functions
            driver.Navigate().GoToUrl(personalOffice);
            Thread.Sleep(2000);

            //Then
            Assert.AreEqual(page.check.Text, buttonText);
        }
    }
}
