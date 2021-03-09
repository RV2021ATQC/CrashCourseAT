using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestFramework.OpenCart
{
    public class LoginPage : ABasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { VerifyWebElements(); }
        public IWebElement email => driver.FindElement(By.Id("input-email"));
        public IWebElement password => driver.FindElement(By.Id("input-password"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//input[@class='btn btn-primary']"));
        public IWebElement successfulyLogin => driver.FindElement(By.XPath("//ul[@class='breadcrumb']/li[2]/a[contains(text(), 'Account')]"));
        public void InputEmail(string emailText)
        {
            email.SendKeys(emailText);
        }
        public void InputPassword(string passwordText)
        {
            password.SendKeys(passwordText);
        }
        public void Login(string emailText, string passwordText)
        {
            InputEmail(emailText);
            InputPassword(passwordText);
            loginButton.Click();
        }
        public bool SuccessfulyLogin()
        {
            return successfulyLogin.Displayed;
        }
        protected override void VerifyWebElements()
        {
            IWebElement temp = email;
            temp = password;
            temp = loginButton;
        }
    }
}
