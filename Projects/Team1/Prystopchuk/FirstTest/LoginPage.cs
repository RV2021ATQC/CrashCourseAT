using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace FirstTest
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement UserName => driver.FindElement(By.Name("username"));
        public IWebElement Password => driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[7]/div/div/div[2]/div[1]/div/form/button"));

        public void PerformLogin(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            LoginBtn.Click();
        } 
    }
}
