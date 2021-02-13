using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;


namespace SeleniumTests
{
    public class Page
    {
        private string _email;
        private string _password;
        private IWebDriver driver;
        public IWebElement email => driver.FindElement(By.Id("login-email"));
        public IWebElement password => driver.FindElement(By.Id("login-password"));
        public IWebElement loginPageButton => driver.FindElement(By.CssSelector("body > header > div > div > div.v-hide-on-mobile.vr-hide-on-mobile-new > div > div.n-row-menu.n-row-top-menu > div.n-menu-col.n-menu-col-kabinet > div.a-registration > a:nth-child(2)"));
        public IWebElement mainPage;
        public IWebElement dropDownMenu => driver.FindElement(By.XPath("//a[@class='v-toggle-button vr-toggle-button-new']"));
        public IWebElement personalOffice;
        public IWebElement check => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/center/div/a"));
        public IWebElement cofirmLogin => driver.FindElement(By.CssSelector(".btn"));


        public Page(IWebDriver driver, string email, string password)
        {
            this.driver = driver;
            _email = email;
            _password = password;
        }
        public void Login()
        {
            email.SendKeys(_email);
            password.SendKeys(_password);
        }
    }
}
