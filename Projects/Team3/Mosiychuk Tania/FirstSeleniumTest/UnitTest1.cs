using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace FirstSeleniumTest
{
    public class Test
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void FirstTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://ilearn.org.ua/login");
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[1]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[1]/input")).SendKeys("tania2002mosiy@gmail.com");

            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[2]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[2]/input")).SendKeys("sm6ozi802" + Keys.Enter);

            Thread.Sleep(2000);
            IWebElement searchelement = driver.FindElement(By.XPath("/html/body/footer/div/div/div[2]/div[1]/div[2]/div"));
            Assert.True(searchelement.Text.Contains("Партнер проекту"));
        }


    }
}