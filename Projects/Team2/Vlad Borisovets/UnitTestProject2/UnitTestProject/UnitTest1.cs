using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject
{
	public class UnitTest1
	{
		public IWebDriver driverChrome;
		public IWebDriver driverFirefox;
		
		[OneTimeTearDown]
		public void EndTest()
		{
			driverChrome.Quit();
			driverFirefox.Quit();
		}
		
		[Test]
		[Parallelizable]
		public void LoginChrome()
		{
			driverChrome = new ChromeDriver();
			// prepare
			AuthorizationPage.goToSite(driverChrome, "https://naurok.ua/");


			// action
			AuthorizationPage account = new AuthorizationPage("vladb707@gmail.com", "test_worked");
			AuthorizationPage.Logout(driverChrome, account);


			// verification      
			string url = "https://naurok.ua/student/dashboard";
			Assert.AreEqual(url, driverChrome.Url);
		}
		
		[Test]
		[Parallelizable]
		public void LoginFirefox()
		{
			driverFirefox = new FirefoxDriver();
			// prepare
			AuthorizationPage.goToSite(driverFirefox, "https://naurok.ua/");


			// action
			AuthorizationPage account = new AuthorizationPage("vladb707@gmail.com", "test_worked");
			AuthorizationPage.Logout(driverFirefox, account);


			// verification      
			string url = "https://naurok.ua/student/dashboard";
			Assert.AreEqual(url, driverFirefox.Url);
		}


	}
}
