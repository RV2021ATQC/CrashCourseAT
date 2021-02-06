using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace MyFirstNUnitTest
{
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
        
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
       

        [Test]
        public void FirstTest()
        {
                   
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://demo.opencart.ua/");
                  
            driver.FindElement(By.XPath("/html/body/div[1]/nav/div[2]/ul/li[7]/a")).Click();

                      
            Thread.Sleep(100);

            IWebElement element1 = driver.FindElement(By.XPath("/html/body/div[2]/div/aside/div[1]/a[5]"));
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/div[2]/div/aside/div[1]/a[4]"));
            IWebElement element3 = driver.FindElement(By.XPath("/html/body/div[2]/div/aside/div[1]/a[6]"));
            

            Assert.True(element1.Text.Contains("Софт (0)"));
            Assert.True(element2.Text.Contains("Планешти (1)"));
            Assert.True(element3.Text.Contains("Мобільні телефони (3)"));

            driver.Quit();
        }
        
    }
}