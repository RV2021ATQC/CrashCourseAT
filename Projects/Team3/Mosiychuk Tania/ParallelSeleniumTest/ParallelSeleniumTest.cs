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
        public string login = "tania2002mosiy@gmail.com";
        public string password = "sm6ozi802";

        [Test]
        [Parallelizable(ParallelScope.All)]
        public void LoginChrome()
        {
            LoginPage chromepage = new LoginPage { driver = new ChromeDriver() };
            chromepage.GoToSite(url);
            chromepage.Login(login, password);
            chromepage.ChekText();
            chromepage.driver.Quit();
        }

        [Test]
        [Parallelizable(ParallelScope.All)]
        public void LoginFirefox()
        {
            LoginPage firefoxpage = new LoginPage { driver = new FirefoxDriver() };
            firefoxpage.GoToSite(url);
            firefoxpage.Login(login, password);
            firefoxpage.ChekText();
            firefoxpage.driver.Quit();
        }
    }
}