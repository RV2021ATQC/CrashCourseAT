using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;


namespace Selenium
{
    [TestFixture]
    public class Test_Selenium
    {
        private IWebDriver driver;
        public enum BrowserType { Chrome, FireFox }

        [TearDown]
        public void AfterAllMethods()
        {
            driver.Quit();

        }
        [Test]
        [Parallelizable]
        [TestCase("sv_lugan@ukr.net", "!Qwerty123", BrowserType.Chrome)]      // must be true   
        [TestCase("sv_lugan@ukr.net", "Wrong_password", BrowserType.Chrome)]  // must be false
        [TestCase("sv_lugan@ukr.net", "!Qwerty123", BrowserType.FireFox)]      // must be true   
        [TestCase("sv_lugan@ukr.net", "Wrong_password", BrowserType.FireFox)]  // must be false
        public void Test_method(string usrn, string passw, BrowserType brow)
        {
            if (brow == BrowserType.Chrome) driver = new ChromeDriver();
            else driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Page_Selenium obj = new Page_Selenium (driver);
            obj.Login(usrn, passw);
            Assert.AreEqual("Здравствуйте, Qwerty Qwerty", obj.Mes);
            Assert.AreEqual("Qwerty Qwerty", obj.PIB);
        }
    }
}
