using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace FirstTest {
    public enum BrowserType
    { Chrome, FireFox }


    public class TestBase
    {
        [ThreadStatic]
        protected IWebDriver driver;
        //public TestBase(BrowserType browser)
        //{
        //    SetDriver(browser);
        //}

        protected void SetDriver(BrowserType type)
        {
            if (type == BrowserType.Chrome)  driver = new ChromeDriver();
            if (type == BrowserType.FireFox) driver = new FirefoxDriver();
        }

        [TearDown]
        public void Quitdriver()
        {
            driver.Quit();
        }
    }
}
