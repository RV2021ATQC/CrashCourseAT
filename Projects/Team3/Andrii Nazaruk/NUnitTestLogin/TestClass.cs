using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace NUnitTestLogin
{

    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        private IWebDriver chrome_driver;
        private IWebDriver firefox_driver;

        [SetUp]
        public void SetUp()
        {
            chrome_driver = new ChromeDriver();
            firefox_driver = new FirefoxDriver();
            chrome_driver.Manage().Window.Maximize();
            firefox_driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login()
        {
            HomePage driver = new HomePage(chrome_driver, firefox_driver);

            driver.goToPage();
            driver.login();
            driver.CheckValue();
        }
        public void CheckText()
        {
            HomePage driver = new HomePage(chrome_driver, firefox_driver);
            driver.CheckValue();
        }

        [TearDown]
        public void TearDown()
        {
            chrome_driver.Quit();
            firefox_driver.Quit();
        }
    }
}