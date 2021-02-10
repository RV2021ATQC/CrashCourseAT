using OpenQA.Selenium;

namespace NUnitTestLogin
{
    class HomePage
    {
        private IWebDriver driver;
        const string url = "https://filmfreeway.com/deadCenter";

        private UserData user = new UserData("celef64828@tigasu.com", "Property12345");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void goToPage()
        {
            driver.Navigate().GoToUrl(url);
        }
        public void login()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/input[3]")).SendKeys(user.userName);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/input[4]")).SendKeys(user.userPassword);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/div[2]/button")).Click();
        }
    }
}
