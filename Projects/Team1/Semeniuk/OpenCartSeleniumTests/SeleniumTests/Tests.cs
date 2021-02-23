using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    [Parallelizable]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    class SeleniumFirst<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [ThreadStatic]
        private IWebDriver driver;
        [SetUp]
        public void BeforeAllMethods()
        {
            driver = new TWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        [TestCase("qwerty", "qwerty", "qwertys@qwerty.qw", "12345678", "qwerty")]
        public void Registration(string firstNameText, string lastNameText, string emailText, string telephoneText, string passwordText)
        {

            //When
            var main = new MainPage(driver);
            var registration = new RegistrationPage(driver);
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            emailText = driver.GetType().ToString() + emailText;

            //Then
            main.GoToMain();
            Thread.Sleep(1000);
            main.StartRegistration();
            Thread.Sleep(1000);
            registration.Registration(firstNameText, lastNameText, emailText, telephoneText, passwordText);
            Thread.Sleep(1000);

            //And
            if (registration.successfulyRegistration.Displayed)
            {
                DBWork.DeleteCustomer(firstNameText, lastNameText, emailText, telephoneText);
            }
            Assert.Pass();
        }
        [Test]
        [TestCase("seth@aegr.arg", "qwerty")]
        public void Logout(string emailText, string passwordText)
        {
            //Given
            Login(emailText, passwordText);

            //When
            var main = new MainPage(driver);
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            main.GoToMain();
            Thread.Sleep(1000);
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //Then
            main.Logout();
            Thread.Sleep(1000);

            //And
            Assert.IsTrue(main.successfulyLogout.Displayed);
        }
        [Test]
        [TestCase("qwerty@qwer.ru", "qwerty")]
        public void Login(string emailText, string passwordText)
        {
            //Given
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(1);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);

            //When
            var main = new MainPage(driver);
            var login = new LoginPage(driver);
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //Then
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
            main.GoToMain();
            Thread.Sleep(1000);
            //IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//a/h3")));
            main.StartLogin();
            Thread.Sleep(1000);
            login.Login(emailText, passwordText);
            Thread.Sleep(1000);

            //And
            Assert.IsTrue(login.successfulyLogin.Displayed);
        }
    }
}
