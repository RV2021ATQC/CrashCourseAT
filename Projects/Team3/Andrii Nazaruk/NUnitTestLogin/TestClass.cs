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
            HomePage chrome_page = new HomePage(chrome_driver);
            HomePage firefox_page = new HomePage(firefox_driver);
            chrome_page.goToPage();
            chrome_page.login();
            chrome_page.CheckValue();

            firefox_page.goToPage();
            firefox_page.login();
            firefox_page.CheckValue();
        }
        public void CheckText()
        {
            HomePage chrome_page = new HomePage(chrome_driver);
            HomePage firefox_page = new HomePage(firefox_driver);
            chrome_page.CheckValue();
            firefox_page.CheckValue();
        }

        [TearDown]
        public void TearDown()
        {
            chrome_driver.Quit();
            firefox_driver.Quit();
        }            
    }
}