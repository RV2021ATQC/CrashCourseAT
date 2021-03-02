using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace TestFramework.OpenCart
{
    [Parallelizable]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    class SeleniumFirst<T> where T : IWebDriver, new()
    {
        [ThreadStatic]
        private IWebDriver driver;
        [SetUp]
        public void BeforeAllMethods()
        {
            driver = new T();
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
            //Given
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            emailText = driver.GetType().ToString() + emailText;

            //When
            var main = new MainPage(driver);
            main.StartRegistration();
            Thread.Sleep(1000);//ChromeFail

            //Then
            var registration = new RegistrationPage(driver);
            registration.Registration(firstNameText, lastNameText, emailText, telephoneText, passwordText);

            //And
            if (registration.SuccessfulyRegistration())
            {
                DBTest.DeleteCustomer(firstNameText, lastNameText, emailText, telephoneText);
            }
            Assert.Pass();
        }
        [Test]
        [TestCase("seth@aegr.arg", "qwerty")]
        public void Logout(string emailText, string passwordText)
        {
            //Given
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //When
            Login(emailText, passwordText);

            //Then
            var main = new MainPage(driver);
            main.Logout();

            //And
            Assert.IsTrue(main.SuccessfulyLogout());
        }
        [Test]
        [TestCase("qwerty@qwer.ru", "qwerty")]
        public void Login(string emailText, string passwordText)
        {
            //Given
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //When
            var main = new MainPage(driver);


            //Then
            main.StartLogin();
            Thread.Sleep(1000);//ChromeFail


            var login = new LoginPage(driver);
            login.Login(emailText, passwordText);

            //And
            Assert.IsTrue(login.SuccessfulyLogin());
        }
    }
}
