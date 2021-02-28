using OpenQA.Selenium;
using System;
using NUnit.Framework;

namespace UI_Tests
{
    public class HomePage : BasePage
    {
        public const string URLSITE = "http://127.0.0.1:81/opencart/";
        public HomePage(IWebDriver driver) : base(driver) { }
        public IWebElement ComponentsDropDown => driver.FindElement(By.XPath("/html/body/div[1]/nav/div[2]/ul/li[3]/a"));
        public IWebElement MonitorsButton => driver.FindElement(By.XPath("/html/body/div[1]/nav/div[2]/ul/li[3]/div/div/ul/li[2]/a"));
        public IWebElement ProductName => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div[2]/div/div[2]/div[1]/h4/a"));
        public IWebElement SearchField => driver.FindElement(By.XPath("/html/body/header/div/div/div[2]/div/input"));
        public IWebElement SearchElement => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[2]/a"));
        public IWebElement BackToHome => driver.FindElement(By.XPath("/html/body/header/div/div/div[1]/div/h1/a"));
        public void Waiter()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        public void GoToSite()
        {
            driver.Navigate().GoToUrl(URLSITE);
        }

        public void OpenTheMonitors()
        {
            ComponentsDropDown.Click();
            MonitorsButton.Click();
        }

        public void WantedProduct()
        {
            ProductName.Click();
        }

        public void GoBackToHome()
        {
            BackToHome.Click();
        }

        public void CheckTextInTheEnd()
        {
            Assert.True(SearchElement.Text.Contains("Samsung SyncMaster 941BW"));
        }

        public void SeachProductInField()
        {
            SearchField.Click();
            SearchField.Clear();
            SearchField.SendKeys("Samsung SyncMaster 941BW" + Keys.Enter);
        }
    }
}