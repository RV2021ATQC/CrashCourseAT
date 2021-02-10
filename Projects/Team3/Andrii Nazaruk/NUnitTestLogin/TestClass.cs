using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestLogin
{
    [Parallelizable(scope: ParallelScope.All)]
    public class Tests
    {
        private IWebDriver driver;
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
            homePage.login();
        }

        [Test]
        [TestCaseSource(typeof(BrowserTypes), "BrowserToRunWith")]
        [Parallelizable]
        public void CheckValue(string browserName)
        {
            Setup(browserName);
            HomePage homePage = new HomePage(driver);
            homePage.goToPage();
            homePage.login();

            IWebElement chrome_dashboard_webElement = driver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[4]/a"));
            IWebElement firefox_dashboard_webElement = driver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[4]/a"));

            Assert.True(chrome_dashboard_webElement.Text.Contains("Submissions"));
            Assert.True(firefox_dashboard_webElement.Text.Contains("Submissions"));
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}