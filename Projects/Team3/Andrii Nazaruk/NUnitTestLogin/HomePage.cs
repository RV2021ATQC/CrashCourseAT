using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace NUnitTestLogin
{
    class HomePage
    {
        private IWebDriver crome_driver;
        private IWebDriver firefox_driver;
        private string url = "https://darknets.ru/";

        public HomePage(IWebDriver _chrome_driver, IWebDriver _firefox_driver)
        {
            this.crome_driver = _chrome_driver;
            this.firefox_driver = _firefox_driver;
        }
        public void goToPage()
        {
            crome_driver.Navigate().GoToUrl(url);
            firefox_driver.Navigate().GoToUrl(url);
            Thread.Sleep(500);
        }
        public void login()
        {
            firefox_driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[2]/form/table/tbody/tr[1]/td[2]/input")).SendKeys("Chadoboy");
            firefox_driver.FindElement(By.CssSelector("#navbar_password")).SendKeys("g5FVajAy");
            firefox_driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[2]/form/table/tbody/tr[2]/td[3]/input")).Click();

            crome_driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[2]/form/table/tbody/tr[1]/td[2]/input")).SendKeys("Chadoboy");
            crome_driver.FindElement(By.CssSelector("#navbar_password")).SendKeys("g5FVajAy");
            crome_driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[2]/form/table/tbody/tr[2]/td[3]/input")).Click();
            Thread.Sleep(3000);
        }
        public void CheckValue()
        {
            Thread.Sleep(1000);
            IWebElement chrome_webElement1 = crome_driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[1]/div/strong"));
            IWebElement chrome_webElement2 = crome_driver.FindElement(By.CssSelector("#f254 > div:nth-child(1) > a > strong > b"));

            IWebElement firefox_webElement1 = firefox_driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td[1]/div/strong"));
            IWebElement firefox_webElement2 = firefox_driver.FindElement(By.CssSelector("#f254 > div:nth-child(1) > a > strong > b"));

            Assert.True(chrome_webElement1.Text.Contains("DarkNets.Ru - Ethical Hacking - Cyber Security - Penetration Testing"));
            Assert.True(chrome_webElement2.Text.Contains("International Zone"));
            Assert.True(firefox_webElement1.Text.Contains("DarkNets.Ru - Ethical Hacking - Cyber Security - Penetration Testing"));
            Assert.True(firefox_webElement2.Text.Contains("International Zone"));
        }
    }
}
