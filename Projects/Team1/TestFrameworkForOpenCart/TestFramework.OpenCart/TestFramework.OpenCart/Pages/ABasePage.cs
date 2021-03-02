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
    public abstract class ABasePage
    {
        
        protected readonly IWebDriver driver;

        protected ABasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        abstract protected void VerifyWebElements();
        //public void Wait()
        //{
        //    using (var driver = new FirefoxDriver())
        //    {
        //        var foo = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
        //                        .Until(drv => drv.FindElement(By.Name("q")));
        //        Debug.Assert(foo.Text.Equals("Hello from JavaScript!"));
        //    }
        //}
    }
}
