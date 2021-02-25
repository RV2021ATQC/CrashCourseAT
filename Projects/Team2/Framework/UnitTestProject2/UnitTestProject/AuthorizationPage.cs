using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject
{
	public class AuthorizationPage
	{
		public string Login;
		public string Password;
		private static string OpenLoginFormCss = "#w1 > li:nth-child(2) > a";
		private static string LoginFiledId = "studentloginform-login";
		private static string PasswordFiledId = "studentloginform-password";
 NlogAndFramework


 main
		public static void goToSite(IWebDriver driver, string site)
		{
			driver.Navigate().GoToUrl(site);
		}
		public static void Autorization(IWebDriver driver, AuthorizationPage account)
		{
			driver.FindElement(By.CssSelector(OpenLoginFormCss)).Click();
			driver.FindElement(By.Id(LoginFiledId)).SendKeys(account.Login);
			driver.FindElement(By.Id(PasswordFiledId)).SendKeys(account.Password + Keys.Enter);
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
			wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[1]/ul/li")));
		}
		public AuthorizationPage(string Login, string Password)
		{
			this.Login = Login;
			this.Password = Password;
		}
 NlogAndFramework



 main
	}
}
