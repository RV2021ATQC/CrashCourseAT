using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumTest
{
    class Program
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void StartUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [OneTimeTearDown]
        public void TestEnd()
        {
            driver.Quit();
        }
        [Test]
        public void TestPubg()
        {
            string link = "https://lite.pubg.com/ru/news/";
            driver.Navigate().GoToUrl("https://lite.pubg.com/ru/download/");
            driver.Navigate().GoToUrl("https://lite.pubg.com/ru/news/");
            Assert.AreEqual(link, driver.Url);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[2]/header/div/div[2]/aside/ul/li[1]/a")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#loginForm > div.column > app-email-input > div > input")).Click();
            driver.FindElement(By.CssSelector("#loginForm > div.column > app-email-input > div > input")).SendKeys("derback2015@ukr.net");
            Thread.Sleep(1000); 
            driver.FindElement(By.CssSelector("#loginForm > div.column > app-password-input > div > input")).Click();
            driver.FindElement(By.CssSelector("#loginForm > div.column > app-password-input > div > input")).SendKeys("GoodParol100%");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/form/div[2]/app-form-button/div/button")).Click();
        }

        static void Main(string[] args)
        {

        }
    }
}
