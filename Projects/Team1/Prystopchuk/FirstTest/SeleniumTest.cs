using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FirstTest
{
   
    [Parallelizable]
    public class TestChrome : TestBase
    {
        public TestChrome() : base(BrowserType.Chrome) { }

        [Test, Parallelizable]
        [TestCase("hhaarrlleeyy.qquuiiinn@gmail.com", "WrongPassword", ExpectedResult = true)]
        [TestCase("hhaarrlleeyy.qquuiiinn@gmail.com", "CorrectPassword", ExpectedResult = false)]
        public bool Test1(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.cultbeauty.co.uk/customer/account/login/");
            new LoginPage(driver).PerformLogin(username, password);

            //Thread.Sleep(20000);
            return driver.FindElementSafe(By.XPath("/html/body/div[1]/div[1]/div[7]/div/div/div[2]/div[1]/div/form/div")).Exists();
        }

        [TestFixture]
        [Parallelizable]
        public class TestFox : TestBase
        {
            public TestFox() : base(BrowserType.FireFox) { }
            [Test, Parallelizable]
            [TestCase("hhaarrlleeyy.qquuiiinn@gmail.com", "WrongPassword", ExpectedResult = true)]
            [TestCase("hhaarrlleeyy.qquuiiinn@gmail.com", "CorrectPassword", ExpectedResult = false)]
            public bool Test2(string username, string password)
            {
                driver.Navigate().GoToUrl("https://www.cultbeauty.co.uk/customer/account/login/");
                new LoginPage(driver).PerformLogin(username, password);
                return driver.FindElementSafe(By.XPath("/html/body/div[1]/div[1]/div[7]/div/div/div[2]/div[1]/div/form/div")).Exists();
            }
        }
    }
}
