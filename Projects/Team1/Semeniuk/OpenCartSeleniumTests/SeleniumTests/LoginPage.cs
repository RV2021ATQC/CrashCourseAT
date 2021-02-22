using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public IWebElement email => driver.FindElement(By.Id("input-email"));
        public IWebElement password => driver.FindElement(By.Id("input-password"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//input[@class='btn btn-primary']"));
        public IWebElement successfulyLogin => driver.FindElement(By.XPath("//ul[@class='breadcrumb']/li[2]/a[contains(text(), 'Account')]"));
        public void Login(string emailText, string passwordText)
        {
            email.SendKeys(emailText);
            password.SendKeys(passwordText);
            loginButton.Click();
        }
        //public void Waiter(By waitUntil)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(waitUntil));
        //}
    }
}
