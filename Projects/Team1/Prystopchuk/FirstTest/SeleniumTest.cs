using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FirstTest
{
    [Parallelizable(ParallelScope.Children)]
    [TestFixture]
    public class NegativeTest : TestBase
    {
        [TestCase(BrowserType.Chrome, "hhaarrlleeyy.qquuiiinn@gmail.com", "WrongPassword", ExpectedResult = true)]
        [TestCase(BrowserType.FireFox, "hhaarrlleeyy.qquuiiinn@gmail.com", "WrongPassword", ExpectedResult = true)]
        public bool Negative(BrowserType browser, string username, string password)
        {
            SetDriver(browser);
            var page = new LoginPage(driver);
            page.PerformLogin(username, password);
            return page.WrongPassMsg.Exists();
           // driver.Quit();
        }       
       
    }

    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class PositiveTest : TestBase
    {
        [TestCase(BrowserType.Chrome, "hhaarrlleeyy.qquuiiinn@gmail.com", "CorrectPassword", ExpectedResult = true)]
        [TestCase(BrowserType.FireFox, "hhaarrlleeyy.qquuiiinn@gmail.com", "CorrectPassword", ExpectedResult = true)]
        public bool Positive(BrowserType browser, string username, string password)
        {
            SetDriver(browser);
            var page = new LoginPage(driver);
            page.PerformLogin(username, password);
            return page.CorrectPassMsg.Exists();
            //driver.Quit();
        }
    }
}
