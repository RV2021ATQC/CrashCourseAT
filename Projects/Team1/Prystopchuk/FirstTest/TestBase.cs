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

        //[SetUp]
        protected void SetDriver(BrowserType type)
        {
            if (type == BrowserType.Chrome)  driver = new ChromeDriver();
            if (type == BrowserType.FireFox) driver = new FirefoxDriver();
        }

        //[OneTimeTearDown]
        //public void Quitdriver()
        //{
        //    driver.Quit();
        //}
    }
}
