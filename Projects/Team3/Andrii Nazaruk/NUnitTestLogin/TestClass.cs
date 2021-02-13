using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestLogin
{
    
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        private IWebDriver driver;
        public UserData user = new UserData("celef64828@tigasu.com", "Property12345");
        public void Setup(string browserName)
        {
            if (browserName.Contains("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (browserName.Contains("chrome"))
            {
                driver = new ChromeDriver();
            }
            driver.Manage().Window.Maximize();
        }
       
        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(BrowserTypes), "BrowserToRunWith")]
        public void Login(string browserName)
        {           
            Setup(browserName);
            HomePage homePage = new HomePage(driver);
            homePage.goToPage();
            homePage.login(user);
        }
        [Test]
        [TestCaseSource(typeof(BrowserTypes), "BrowserToRunWith")]
        [Parallelizable]
        
        public void CheckValue(string browserName)
        {
            Setup(browserName);
            HomePage homePage = new HomePage(driver);
            homePage.goToPage();
            homePage.login(user);
          
            Assert.True(homePage.dashboard_webElement.Text.Contains("Submissions"));           
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}