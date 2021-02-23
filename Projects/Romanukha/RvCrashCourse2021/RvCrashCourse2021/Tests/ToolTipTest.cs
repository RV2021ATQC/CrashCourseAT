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
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace taqc2018
{
    [TestFixture]
    public class ToolTipTest
    {
        //[Test]
        public void ExpectedConditions1()
        {
            IWebDriver driver = new ChromeDriver();
            //
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            //IWebElement searchElement = wait.Until<IWebElement>(ExpectedConditions.InvisibilityOfElementLocated(By.Name("q")));
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void ToolTipTestSkype()
        {

            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.skype.com/en/");
            //
            IWebElement blogsElement = driver.FindElement(By.PartialLinkText("Blogs"));
            string blogsText = blogsElement.Text;
            Console.WriteLine("blogsText=" + blogsText + "=end");
            Thread.Sleep(2000);
            //
            Actions action = new Actions(driver);
            action.ClickAndHold().MoveToElement(blogsElement).Build().Perform();
            //action.MoveToElement(blogsElement).Build().Perform();
            Thread.Sleep(4000);
            //
            string toolTipText = driver.FindElement(By.CssSelector("a[href='https://blogs.skype.com']")).Text;
            Console.WriteLine("blogsElement=" + toolTipText + "=end");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void CheckToolTip()
        {

            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("file:///D:/tooltip.html");
            //
            IWebElement element = driver.FindElement(By.Id("info-google"));
            //
            Actions action = new Actions(driver);
            action.ClickAndHold().MoveToElement(element).Build().Perform();
            //action.MoveToElement(blogsElement).Build().Perform();
            Thread.Sleep(4000);
            //
            Console.WriteLine("Text= " + element.Text + " =end");
            Console.WriteLine("ToolTip= " + element.GetAttribute("title") + " =end");
            //
            Assert.AreEqual("info-google", element.GetAttribute("title"));
            //
            driver.Quit();
        }

    }
}
