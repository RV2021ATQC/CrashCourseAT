using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests 
{
    public class RegistrationPage : ABasePage
    {
        
        public IWebElement firstName => driver.FindElement(By.Id("input-firstname"));
        public IWebElement lastName => driver.FindElement(By.Id("input-lastname"));
        public IWebElement email => driver.FindElement(By.Id("input-email"));
        public IWebElement telephone => driver.FindElement(By.Id("input-telephone"));
        public IWebElement password => driver.FindElement(By.Id("input-password"));
        public IWebElement passwordConfirm => driver.FindElement(By.Id("input-confirm"));
        public IWebElement privacyPolicyCheck => driver.FindElement(By.XPath("//input[@name='agree']"));
        public IWebElement submitRegistrationButton => driver.FindElement(By.XPath("//input[@type='submit']"));
        public IWebElement successfulyRegistration => driver.FindElement(By.XPath("//ul[@class='breadcrumb']/li[3]/a[contains(text(), 'Success')]"));

        public RegistrationPage(IWebDriver driver):base(driver)
        {
            VerifyWebElements();
        }
        public void InputFirstName(string firstNameText) => firstName.SendKeys(firstNameText);
        public void InputLastName(string lastNameText) => lastName.SendKeys(lastNameText);
        public void InputEMail(string emailText) => email.SendKeys(emailText);
        public void InputTelephone(string telephoneText) => telephone.SendKeys(telephoneText);
        public void InputPassword(string passwordText) => password.SendKeys(passwordText);
        public void InputPasswordConfirm(string passwordText) => passwordConfirm.SendKeys(passwordText);
        public void Registration(string firstNameText, string lastNameText, string emailText, string telephoneText, string passwordText)
        {
            InputFirstName(firstNameText);
            InputLastName(lastNameText);
            InputEMail(emailText);
            InputTelephone(telephoneText);
            InputPassword(passwordText);
            InputPasswordConfirm(passwordText);
            privacyPolicyCheck.Click();
            submitRegistrationButton.Click();
        }
        private void VerifyWebElements()
        {
            IWebElement temp = firstName;
            temp = lastName;
            temp = email;
            temp = telephone;
            temp = password;
            temp = passwordConfirm;
            temp = privacyPolicyCheck;
            temp = submitRegistrationButton;
        }
        public bool SuccessfulyRegistration()
        {
            return successfulyRegistration.Displayed;
        }
    }
}
