using Framework.Data.User;
using Framework.Tools;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Framework.Test
{
    [AllureNUnit]
	class AutorizationTest
	{
		private IWebDriver driver;
		[OneTimeSetUp]
		public void StartTest()
		{
			BrowserOption StartInDocker = new BrowserOption();
			driver = StartInDocker.OptionForSelenoid();
			
		}
		[OneTimeTearDown]
		public void EndTest()
		{
			driver.Quit();
		}
		[Test]
		public void AutorizationPageTest()
		{
			//Step
			AutorizationPage.AuthorizationPageTest(driver, User.GetUser());
			//Verefication
			Assert.AreEqual(driver.Url, AutorizationPage.loginPageVereficationUrl);
		}
	}
}
