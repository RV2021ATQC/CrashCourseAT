using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace taqc2018
{
    //[TestFixture]
    //[Parallelizable(ParallelScope.All)]
    class SeleniumFirst2
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        //[Test]
        public void FirstTest2()
        {
            Console.WriteLine("FirstTest2() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            //
            //IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Id("lst-ib")).Click();
            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("selenium ide" + Keys.Enter);
            Thread.Sleep(2000);
            //
            //driver.FindElement(By.Id("mKlEF")).Click();
            driver.FindElement(By.LinkText("Selenium IDE")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Download")).Click();
            Thread.Sleep(2000);
            //
            Assert.AreEqual("Selenium IDE is a Chrome and Firefox plugin which records and plays back user interactions with the browser. Use this to either create simple scripts or assist in exploratory testing.",
                driver.FindElement(By.CssSelector("a[name=\"selenium_ide\"] > p")).Text);
            //
            //driver.Quit();
        }
    }
}
