using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver){}
        public void GoToMain() => driver.Navigate().GoToUrl("http://localhost/OpencartStore/index.php?route=common/home");
        public IWebElement registrationDropdownMenu => driver.FindElement(By.XPath("//a[@class='dropdown-toggle']/span[@class='caret']"));
        public IWebElement registrationPageButton => driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']/li[1]/a"));
        public IWebElement loginPageButton => driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']/li[2]/a"));
        public IWebElement logo => driver.FindElement(By.XPath("//div[@id='logo']/h1/a"));
        public IWebElement logoutButton => driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']/li[5]/a"));
        public IWebElement successfulyLogout => driver.FindElement(By.XPath("//ul[@class='breadcrumb']/li[3]/a[contains(text(), 'Logout')]"));
        public MainPage StartRegistration()
        {
            registrationDropdownMenu.Click();
            registrationPageButton.Click();
            return this;
        }
        public void StartLogin()
        {
            registrationDropdownMenu.Click();
            loginPageButton.Click();
        }
        public void Logout()
        {

            registrationDropdownMenu.Click();
            logoutButton.Click();
        }
        public void GoToMainPage()
        {
            logo.Click();
        }
    }
}
