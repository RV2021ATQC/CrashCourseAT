using OpenQA.Selenium;
using System;

namespace FirstTest
{
    public static class MyMethods{
        public static IWebElement FindElementSafe(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is NullReferenceException)
                    return null;
                else throw;
            }
        }
        
        public static bool Exists(this IWebElement element)
        {
            return element != null;
        }
    }
}

