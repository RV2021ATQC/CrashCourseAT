using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace ParallelSeleniunTest
{
    public class Tests
    {
        public IWebDriver chromedriver;
        public IWebDriver firefoxdriver;
       
        public string url = "https://ilearn.org.ua/login";

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            chromedriver.Quit();
            firefoxdriver.Quit();
        }
        [Test]
        [Parallelizable(ParallelScope.All)]
        public void LoginChrome()
        {
            chromedriver = new ChromeDriver();
            LoginPage.GoToSite(chromedriver, url);
            LoginPage.Login(chromedriver);
            LoginPage.ChekText(chromedriver);
        }

        [Test]
        [Parallelizable(ParallelScope.All)]
        public void LoginFirefox()
        {
            firefoxdriver = new FirefoxDriver();
            LoginPage.GoToSite(firefoxdriver, url);
            LoginPage.Login(firefoxdriver);
            LoginPage.ChekText(firefoxdriver);
        }
    }
}