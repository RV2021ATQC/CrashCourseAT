using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using Pages;
using System.Threading;
using Data;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace Framework.Test
{
	[AllureNUnit]
	class CheckPageItemsTest
	{

		public IWebDriver driver;
		[OneTimeSetUp]
		public void StartTest()
		{
			driver = new ChromeDriver(BrowserOption.BrowserSettings());
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			BasePage.goToSite(driver);
		}
		[OneTimeTearDown]
		public void EndTest()
		{
			driver.Quit();
		}
		[Test]
		public void CheckDesktops()
		{
			//Step	
			BasePage.MouseHover(driver, BasePage.Desctops);
			BasePage.ClickButton(driver, "xpatch", BasePage.DesctopsShowAllDesktops);
			//Verefication
			Assert.AreEqual("Desktops", ShowAllCategotiesPage.TextCheckRead(driver, ShowAllCategotiesPage.DesctopsCheckXpatch));
			

		}
		[Test]
		public void CheckNotebook()
		{
			//step
			BasePage.MouseHover(driver, BasePage.LaptopsAndNotebooks);
			BasePage.ClickButton(driver, "xpatch", BasePage.LaptopsAndNotebooksShowAll);
			//Verefication
			Assert.AreEqual("Laptops & Notebooks", ShowAllCategotiesPage.TextCheckRead(driver, ShowAllCategotiesPage.NotebookAndLapptopeTextCheck));
		}
	}
}
