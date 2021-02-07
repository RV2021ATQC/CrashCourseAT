using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FirstTest
{
   // [Parallelizable/*(ParallelScope.All)*/]
    [TestFixture]
    public class Tests : TestBase
    {
        [Test, Parallelizable(ParallelScope.Children)]
        [TestCase(BrowserType.Chrome, "hhaarrlleeyy.qquuiiinn@gmail.com", "WrongPassword", ExpectedResult = true)]
        [TestCase(BrowserType.FireFox, "hhaarrlleeyy.qquuiiinn@gmail.com", "WrongPassword", ExpectedResult = true)]
        public bool Test1(BrowserType browser, string username, string password)
        {
            SetDriver(browser);
            var page = new LoginPage(driver);
            page.PerformLogin(username, password);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //Thread.Sleep(1000);
            var result = page.WrongPassMsg.Exists();
            driver.Quit();
            return result;
        }

        //[Test, Parallelizable(ParallelScope.Children)]
        [TestCase(BrowserType.Chrome, "hhaarrlleeyy.qquuiiinn@gmail.com", "CorrectPassword", ExpectedResult = true)]
        [TestCase(BrowserType.FireFox, "hhaarrlleeyy.qquuiiinn@gmail.com", "CorrectPassword", ExpectedResult = true)]
        public bool Test2(BrowserType browser, string username, string password)
        {
            SetDriver(browser);
            var page = new LoginPage(driver);
            page.PerformLogin(username, password);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Thread.Sleep(10000);
            var result = page.CorrectPassMsg.Exists();
            driver.Quit();
            return result;
        }
    }
}
