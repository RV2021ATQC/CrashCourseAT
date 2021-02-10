using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace NUnitTestLogin
{
    class HomePage
    {
        private IWebDriver driver;
        const string url = "https://filmfreeway.com/deadCenter";            
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/nav/div/ul/li[4]/a")]
        public IWebElement chrome_dashboard_webElement;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/nav/div/ul/li[4]/a")]
        public IWebElement firefox_dashboard_webElement;
        public void goToPage()
        {
            driver.Navigate().GoToUrl(url);          
        }
        public void login(UserData user)
        {
            driver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/input[3]")).SendKeys(user.userName);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/input[4]")).SendKeys(user.userPassword);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/div[2]/button")).Click();
        }   
    }
}
