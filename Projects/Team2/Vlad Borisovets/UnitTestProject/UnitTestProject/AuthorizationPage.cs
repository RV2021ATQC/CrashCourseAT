using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject
{
	public class AuthorizationPage
	{
		public string Login;
		public string Password;
		private static string OpenLoginForm = "#w1 > li:nth-child(2) > a";
		private static string LoginFiled = "studentloginform-login";
		private static string PasswordFiled = "studentloginform-password";
		public static void goToSite(IWebDriver driver, string site)
		{
			driver.Navigate().GoToUrl(site);
			Thread.Sleep(1000);
		}
		public static void Logout(IWebDriver driver, AuthorizationPage account)
		{
			driver.FindElement(By.CssSelector(OpenLoginForm)).Click();
			driver.FindElement(By.Id(LoginFiled)).SendKeys(account.Login);
			driver.FindElement(By.Id(PasswordFiled)).SendKeys(account.Password + Keys.Enter);
			Thread.Sleep(2000);
		}
		public AuthorizationPage(string Login, string Password)
		{
			this.Login = Login;
			this.Password = Password;
		}


	}
}
