using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;


namespace Selenium
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class Test_Selenium<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [ThreadStatic]
        private IWebDriver driver;  
        [SetUp]
        public void BeforeAllMethods()
        {
            driver = new TWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        [TearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        [TestCase("sv_lugan@ukr.net", "!Qwerty123")]      // must be true   
        [TestCase("sv_lugan@ukr.net", "Wrong_password")]  // must be false
        public void Test_method(string usrn, string passw)
        {
            Page_Selenium obj = new Page_Selenium (driver);
            obj.Login(usrn, passw);
            Assert.AreEqual("Здравствуйте, Qwerty Qwerty", obj.Mes);
            Assert.AreEqual("Qwerty Qwerty", obj.PIB);
        }
    }
}
