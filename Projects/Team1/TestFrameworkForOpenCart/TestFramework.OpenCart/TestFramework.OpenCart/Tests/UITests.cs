using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace TestFramework.OpenCart
{
    [AllureNUnit]
    [Parallelizable]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    class SeleniumFirst<T> : ABaseTest 
        where T : IWebDriver, new()
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
        public void Registration()
        {
            //Given
            IUser ValidUser = new Users().Valid();
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            string emailText = driver.GetType().ToString() + ValidUser.GetEmail();

            //When
            var main = new MainPage(driver);
            main.StartRegistration();
            Thread.Sleep(1000);//ChromeFail

            //And
            var registration = new RegistrationPage(driver);
            registration.Registration(ValidUser.GetFirstname(), ValidUser.GetLastname(), emailText, ValidUser.GetPhone(), ValidUser.GetPassword());

            //Then
            if (registration.SuccessfulyRegistration())
            {
                DBReader.DeleteCustomer(ValidUser.GetFirstname(), ValidUser.GetLastname(), emailText, ValidUser.GetPhone());
            }
            Assert.Pass();
        }
        [Test]
        public void Logout()
        {
            //Given
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //When
            Login();

            //And
            var main = new MainPage(driver);
            main.Logout();

            //Then
            Assert.IsTrue(main.SuccessfulyLogout());
        }
        [Test]
        public void Login()
        {
            //Given
            IUser ValidUser = new Users().ValidForLoginV1();
            Console.WriteLine("FirstTest1() ThreadID= " + Thread.CurrentThread.ManagedThreadId);

            //When
            var main = new MainPage(driver);


            
            main.StartLogin();
            Thread.Sleep(1000);//ChromeFail

            //And
            var login = new LoginPage(driver);
            login.Login(ValidUser.GetEmail(), ValidUser.GetPassword());

            //Then
            Assert.IsTrue(login.SuccessfulyLogin());
        }
    }
}
