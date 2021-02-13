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
        public IWebElement dashboard_webElement;
        public IWebElement login_button => driver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[3]/a"));
        public IWebElement user_email_input_field => driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/input[3]"));
        public IWebElement user_password_input_field => driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/input[4]"));
        public IWebElement secondary_login_button => driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/div/div/form/div[2]/button"));
        public void goToPage()
        {
            driver.Navigate().GoToUrl(url);          
        }
        public void login(UserData user)
        {
            login_button.Click();
            user_email_input_field.SendKeys(user.userEmail);
            user_password_input_field.SendKeys(user.userPassword);
            secondary_login_button.Click();
        }   
    }
}
