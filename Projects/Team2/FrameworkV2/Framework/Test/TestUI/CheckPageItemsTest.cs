using Framework.Tools;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Framework.Test
{
    [AllureNUnit]
	class CheckPageItemsTest
	{

		private IWebDriver driver;
		[OneTimeSetUp]
		public void StartTest()
		{
			BrowserOption StartInDocker = new BrowserOption();
			driver = StartInDocker.OptionForSelenoid();
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
