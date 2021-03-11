using OpenQA.Selenium;
using System;
using NUnit.Framework;

namespace OpencartTestFramework
{
    public class HomePage : BasePage
    {
        public const string URLSITE = "http://127.0.0.1:81/opencart/";
        public const string NAMEOFPRODUCT = "Samsung SyncMaster 941BW";
        public HomePage(IWebDriver driver) : base(driver) { }
        public IWebElement ComponentsDropDown => driver.FindElement(By.XPath("/html/body/div[1]/nav/div[2]/ul/li[3]/a"));
        public IWebElement MonitorsButton => driver.FindElement(By.XPath("/html/body/div[1]/nav/div[2]/ul/li[3]/div/div/ul/li[2]/a"));
        public IWebElement ProductName => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div[2]/div/div[2]/div[1]/h4/a"));
        public IWebElement SearchField => driver.FindElement(By.XPath("/html/body/header/div/div/div[2]/div/input"));
        public IWebElement SearchElement => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[2]/a"));
        public IWebElement BackToHome => driver.FindElement(By.XPath("/html/body/header/div/div/div[1]/div/h1/a"));
        
        public void GoToOpencartPage()
        {
            driver.Navigate().GoToUrl(URLSITE);
        }

        public void OpenTheMonitors()
        {
            ComponentsDropDown.Click();
            MonitorsButton.Click();
        }

        public void ChooseWantedProduct()
        {
            ProductName.Click();
        }

        public void GoBackToHome()
        {
            BackToHome.Click();
        }

        public void CheckAvailableProduct()
        {
            Assert.True(SearchElement.Text.Contains(NAMEOFPRODUCT));
        }

        public void SeachProductInField()
        {
            SearchField.Click();
            SearchField.Clear();
            SearchField.SendKeys("Samsung SyncMaster 941BW" + Keys.Enter);
        }
    }
}