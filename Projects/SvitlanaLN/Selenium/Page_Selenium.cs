using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;



namespace Selenium
{
    public class Page_Selenium
    {
        private string Url = "https://setevuha.ua";
        private IWebDriver driver;
        public string Mes;
        public string PIB;
        public Page_Selenium(IWebDriver z_driver)
        {
            this.driver = z_driver;
        }
        public void Login(string username, string password)
        {
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.CssSelector(".l-header-top__item .icon")).Click();
            driver.FindElement(By.Id("login-form-login")).SendKeys(username);
            driver.FindElement(By.Id("login-form-password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".form-footer:nth-child(7) > .c-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Mes = driver.FindElement(By.CssSelector(".gray")).Text;
                PIB = driver.FindElement(By.CssSelector(".l-header-top__item span")).Text;
            }
            catch
            {
                Mes = "Wrong message";
                PIB = "Wrong PIB";
            }
        }
    }
}
