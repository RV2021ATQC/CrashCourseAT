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
        public string url = "https://ilearn.org.ua/login";

        [Test]
        [Parallelizable(ParallelScope.All)]
        public void LoginChrome()
        {
            LoginPage chromepage = new LoginPage { driver = new ChromeDriver() };
            chromepage.GoToSite(url);
            chromepage.Login();
            chromepage.ChekText();
            chromepage.driver.Quit();
        }

        [Test]
        [Parallelizable(ParallelScope.All)]
        public void LoginFirefox()
        {
            LoginPage firefoxpage = new LoginPage { driver = new FirefoxDriver() };
            firefoxpage.GoToSite(url);
            firefoxpage.Login();
            firefoxpage.ChekText();
            firefoxpage.driver.Quit();
        }
    }
}