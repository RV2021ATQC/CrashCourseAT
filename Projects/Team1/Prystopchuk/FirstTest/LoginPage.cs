using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace FirstTest
{
    public class LoginPage
    {
        private IWebDriver driver;
        //private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            //this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.driver = driver;
            driver.Navigate().GoToUrl("https://www.cultbeauty.co.uk/customer/account/login/");
        }
        public IWebElement UserName => driver.FindElement(By.Name("username"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[7]/div/div/div[2]/div[1]/div/form/button"));
        public IWebElement WrongPassMsg => driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[7]/div/div/div[2]/div[1]/div/form/div"));
        public IWebElement CorrectPassMsg => driver.FindElementSafe(By.XPath("/html/body/div[1]/div[1]/div[4]/div/header/div[2]/div[1]/div/div[1]/ul/li[2]/a/span"));

        public void PerformLogin(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            LoginBtn.Click();
        } 
    }
}
