using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SeleniumTests
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Wait()
        {
            using (var driver = new FirefoxDriver())
            {
                var foo = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                .Until(drv => drv.FindElement(By.Name("q")));
                Debug.Assert(foo.Text.Equals("Hello from JavaScript!"));
            }
        }
    }
}
