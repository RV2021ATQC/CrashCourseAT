using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ParallelSeleniunTest
{
    public class LoginPage
    {
        private IWebDriver driver;

        public static void GoToSite(IWebDriver driver, string site)
        {
            driver.Navigate().GoToUrl(site);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }
        public static void Login(IWebDriver driver)
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[1]/input")).SendKeys("tania2002mosiy@gmail.com");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[2]/input")).SendKeys("sm6ozi802" + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }
        
        public static void ChekText(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            IWebElement searchelement = driver.FindElement(By.XPath("/html/body/footer/div/div/div[2]/div[1]/div[2]/div"));
            Assert.True(searchelement.Text.Contains("Партнер проекту"));
        }
    }
}