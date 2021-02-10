using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ParallelSeleniunTest
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage() { }
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToSite(string site)
        {
            driver.Navigate().GoToUrl(site);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }
        public void Login()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[1]/input")).SendKeys("tania2002mosiy@gmail.com");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/form/div[2]/input")).SendKeys("sm6ozi802" + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }
        
        public void ChekText()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            IWebElement searchelement = driver.FindElement(By.XPath("/html/body/footer/div/div/div[2]/div[1]/div[2]/div"));
            Assert.True(searchelement.Text.Contains("Партнер проекту"));
        }
    }
}