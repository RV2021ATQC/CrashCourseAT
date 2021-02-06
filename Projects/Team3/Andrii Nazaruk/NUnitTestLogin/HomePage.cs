using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace NUnitTestLogin
{
    class HomePage
    {
        private IWebDriver driver;
        private string url = "https://darknets.ru/";
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;            
        }      
        public void goToPage()
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(500);
        } 
        public void login()
        {
            driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[2]/form/table/tbody/tr[1]/td[2]/input")).SendKeys("Chadoboy");
            driver.FindElement(By.CssSelector("#navbar_password")).SendKeys("g5FVajAy");
            driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[2]/form/table/tbody/tr[2]/td[3]/input")).Click();
            Thread.Sleep(2000);
        }
        public void CheckValue()
        {
            Thread.Sleep(500);
            IWebElement webElement1 = driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[1]/div/strong"));
            IWebElement webElement2 = driver.FindElement(By.CssSelector("#f254 > div:nth-child(1) > a > strong > b"));


            Assert.True(webElement1.Text.Contains("DarkNets.Ru - Ethical Hacking - Cyber Security - Penetration Testing"));
            Assert.True(webElement2.Text.Contains("International Zone"));
        }
    }
}
