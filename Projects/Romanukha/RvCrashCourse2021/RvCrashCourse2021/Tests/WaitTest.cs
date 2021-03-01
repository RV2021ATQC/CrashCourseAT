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
using crashCourse2021.Data.Application;
using crashCourse2021.Tools;
using crashCourse2021.Tools.Find;
//#pragma warning disable

namespace RvCrashCourse2021
{

    [TestFixture]
    public class WaitTest
    {
        private static int count = 0;

        //[Test]
        public void Wait1Implicit()
        {
            IWebDriver driver = new FirefoxDriver();
            //
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5)); //Now is deprecated
            //
            //driver.Manage().Timeouts().AsynchronousJavaScript.Add(TimeSpan.FromSeconds(30));
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            IWebElement searchElement = driver.FindElement(By.Name("q"));
            //searchElement.SendKeys("ictv.ua");
            searchElement.SendKeys("Selenium download");
            searchElement.Submit();
            //
            //Thread.Sleep(1000);
            Console.WriteLine("Title1= " + driver.Title);
            //
            //Thread.Sleep(1000);
            //driver.FindElement(By.LinkText("ICTV - офіційний сайт телеканалу ICTV")).Click();
            driver.FindElement(By.LinkText("Downloads - Selenium")).Click();
            Console.WriteLine("Title1= " + driver.Title);
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//a[@href='https://ictv.ua/ua/programs/']")).Click();
            //driver.Quit();
        }

        //[Test]
        public void Wait2Explicit()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //
            //IWebElement searchElement = driver.FindElement(By.Name("q"));
            IWebElement searchElement = wait.Until(drv => { return drv.FindElement(By.Name("q")); });

            Func<IWebDriver, IWebElement> waitForWebElement = new Func<IWebDriver, IWebElement>((IWebDriver drv) =>
            {
                Console.WriteLine("Waiting ...");
                count++;
                //IWebElement element = drv.FindElement(By.Name("q"));
                IWebElement element = null;
                if (count > 2)
                {
                    element = drv.FindElement(By.Name("q"));
                }
                else
                {
                    try
                    {
                        element = drv.FindElement(By.Name("q1"));
                    }
                    catch (Exception)
                    { }
                }
                Console.WriteLine("is exist element= " + (element != null));
                //if (element.GetAttribute("id").Contains("lst"))
                //{
                //    return element;
                //}
                //return null;
                return element;
            });

         //   IWebElement searchElement = wait.Until(waitForWebElement);
            searchElement.SendKeys("Selenium download");
            searchElement.Submit();
            //
            //Thread.Sleep(1000);
            //wait.Until((drv) => { return drv.Title.ToLower().StartsWith("selenium"); });
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver drv) =>
            {
                bool actual = drv.Title.ToLower().StartsWith("selenium");
                Console.WriteLine("drv.Title= " + drv.Title + "   actual= " + actual);
                return actual;
            });
            wait.Until(waitForElement);
            Console.WriteLine("Title1= " + driver.Title);
            //
            //Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Downloads - Selenium")).Click();
            Console.WriteLine("Title1= " + driver.Title);
            //Thread.Sleep(1000);
            //driver.Quit();
        }

        //[Test]
        public void ExpectedConditions1()
        {
            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new FirefoxDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Navigate().GoToUrl("https://datatables.net/examples/basic_init/alt_pagination.html");
            driver.Navigate().GoToUrl("https://devexpress.github.io/devextreme-reactive/react/grid/docs/guides/paging/");
            driver.Manage().Window.Maximize();
            //
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement tdLondonFirst = wait.Until((drv) => { return drv.FindElement(By.XPath("//td[text()='London']")); });
            //IWebElement tdLondonNameFirst = wait.Until((drv) => { return drv.FindElement(By.XPath("//td[text()='London']/preceding-sibling::td[2]")); });
            //
            //IWebElement tdLondonFirst = driver.FindElement(By.XPath("//td[text()='London']"));
            //IWebElement tdLondonNameFirst = driver.FindElement(By.XPath("//td[text()='London']/preceding-sibling::td[2]"));
            //Console.WriteLine("tdLondonNameFirst= " + tdLondonNameFirst.Text);
            //
            // Goto Position By JavaScript.
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)driver;
            IWebElement position = driver.FindElement(By.CssSelector("#using-paging-with-other-data-processing-plugins"));
            javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", position);
            //
            Thread.Sleep(2000);
            // $x("//iframe[contains(@style,'height: 426px')]")
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@style,'height: 426px')]")));
            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@style,'height: 442px')]")));
            //string temp = driver.FindElement(By.CssSelector("#grid-paging-remote-paging-demo")).Text;
            //Console.WriteLine("temp= " + temp);
            //
            IWebElement tdNevadaFirst = driver.FindElement(By.XPath("//td[text()='Nevada']"));
            IWebElement tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[2]"));
            Console.WriteLine("tdNevadaFirstData1= " + tdNevadaFirstData.Text);
            //
            //wait.Until((drv) => { return drv.FindElement(By.XPath("//a[text()='3']")); }).Click();
            //tdLondonNameFirst = wait.Until((drv) => { return drv.FindElement(By.XPath("//td[text()='London']/preceding-sibling::td[2]")); });
            //
            //driver.FindElement(By.LinkText("3")).Click();
            //tdLondonNameFirst = driver.FindElement(By.XPath("//td[text()='London']/preceding-sibling::td[2]"));
            //Console.WriteLine("tdLondonNameFirst= " + tdLondonNameFirst.Text);
            //
            driver.FindElement(By.XPath("//span[text()='2']")).Click();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.StalenessOf(tdNevadaFirstData));
            //wait.Until(StalenessOf(tdNevadaFirst));
            //wait.Until(InvisibilityOfElementLocated(By.XPath("//td[text()='2013/11/14']")));
            wait.Until(InvisibilityOfElementLocated(By.XPath("//td[text()='" + tdNevadaFirstData.Text + "']")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //
            ////Thread.Sleep(4000); // For Presentation
            //
            tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[2]"));
            Console.WriteLine("tdNevadaFirstData2= " + tdNevadaFirstData.Text);
            //
            //IWebElement searchElement = wait.Until<IWebElement>(ExpectedConditions.ElementExists(By.Name("q")));
            Thread.Sleep(2000);
            driver.Quit();
        }

        //[Test]
        public void ExpectedConditions2()
        {
            ////IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new FirefoxDriver();
            //
            ////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ////driver.Navigate().GoToUrl("https://devexpress.github.io/devextreme-reactive/react/grid/docs/guides/paging/");
            ////driver.Manage().Window.Maximize();
            //
            ApplicationSource applicationSource = new ApplicationSource(
                ApplicationSourceRepository.CHROME_TEMPORARY_MAXIMIZED_WHITH_UI,
                10L, 10L, "", "");
            Application.Get(applicationSource);
            Application.Get().Browser.OpenUrl("https://devexpress.github.io/devextreme-reactive/react/grid/docs/guides/paging/");
            ISearchStrategy search = Application.Get().Search;
            //search.SetExplicitStrategy();
            //
            //
            // Goto Position By JavaScript.
            ////IJavaScriptExecutor javaScript = (IJavaScriptExecutor)driver;
            ////IWebElement position = driver.FindElement(By.CssSelector("#using-paging-with-other-data-processing-plugins"));
            ////javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", position);
            //
            // TODO Add to class BrowserWrapper
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)Application.Get().Browser.Driver;
            IWebElement position = search.CssSelector("#using-paging-with-other-data-processing-plugins");
            javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", position);
            //
            Thread.Sleep(2000);
            //
            //
            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@style,'height: 426px')]")));
            //
            // TODO Add to class BrowserWrapper
            Application.Get().Browser.Driver.SwitchTo()
                .Frame(search.XPath("//iframe[contains(@style,'height: 426px')]"));
            //
            //
            ////IWebElement tdNevadaFirst = driver.FindElement(By.XPath("//td[text()='Nevada']"));
            ////IWebElement tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[2]"));
            ////Console.WriteLine("tdNevadaFirstData1= " + tdNevadaFirstData.Text);
            //
            IWebElement tdNevadaFirstData = search.XPath("//td[text()='Nevada']/preceding-sibling::td[2]");
            Console.WriteLine("tdNevadaFirstData1= " + tdNevadaFirstData.Text);
            //
            //
            //driver.FindElement(By.XPath("//span[text()='2']")).Click();
            //
            search.XPath("//span[text()='2']").Click();
            //
            //
            ////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            ////WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            ////wait.Until(InvisibilityOfElementLocated(By.XPath("//td[text()='" + tdNevadaFirstData.Text + "']")));
            ////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //
            search.SetExplicitStrategy();
            Console.WriteLine("tdNevadaFirstData2= " + search.InvisibilityOfWebElementLocated(By.XPath("//td[text()='" + tdNevadaFirstData.Text + "']")));
            search.SetImplicitStrategy();
            //
            //
            ////Thread.Sleep(4000); // For Presentation
            //
            ////tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[2]"));
            ////Console.WriteLine("tdNevadaFirstData2= " + tdNevadaFirstData.Text);
            //
            tdNevadaFirstData = search.XPath("//td[text()='Nevada']/preceding-sibling::td[2]");
            Console.WriteLine("tdNevadaFirstData2= " + tdNevadaFirstData.Text);
            //
            //
            Thread.Sleep(2000);
            //driver.Quit();
            //
            Application.Remove();
        }


        public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    Console.WriteLine("element == null || !element.Enabled || !element.Displayed " + (element == null || !element.Enabled || !element.Displayed));
                    // Calling any method forces a staleness check
                    return element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    Console.WriteLine("InvisibilityOfElementLocated ...");
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

    }
}
