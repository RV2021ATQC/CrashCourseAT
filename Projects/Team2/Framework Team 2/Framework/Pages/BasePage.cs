using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Pages
{
    public class BasePage
    {
        public static string DesctopsText = "Show All Desktops";
		public static string LaptopsAndNotebooksText = "Show All Laptops & Notebooks";
        public static string ComponentsText = "Show All Components";
        public static string MP3PlayersText = "Show All MP3 Players";
        public const string BasePageAdress = "https://demo.opencart.com/index.php?route=common/home";
        public static string URLDesctops = "https://demo.opencart.com/index.php?route=product/category&amp;path=20";
		public const string Desctops = "/html/body/div[1]/nav/div[2]/ul/li[1]/a";///html/body/div[1]/nav/div[2]/ul/li[1]/a
		public const string DesctopsShowAllDesktops = "/html/body/div[1]/nav/div[2]/ul/li[1]/div/a";
		public static string desctopsPc = "https://demo.opencart.com/index.php?route=product/category&amp;path=20_26";
        public static string desctopsMac = "https://demo.opencart.com/index.php?route=product/category&amp;path=20_27";
        public static string URLLaptopsAndNotebooks = "https://demo.opencart.com/index.php?route=product/category&amp;path=18";
        public static string LaptopsAndNotebooks = "/html/body/div[1]/nav/div[2]/ul/li[2]/a";
        public static string LaptopsAndNotebooksShowAll = "/html/body/div[1]/nav/div[2]/ul/li[2]/div/a";
        public static string LaptopsAndNotebookMacs = "https://demo.opencart.com/index.php?route=product/category&amp;path=18_46";
        public static string LaptopsAndNotebookWindows = "https://demo.opencart.com/index.php?route=product/category&amp;path=18_45";
        public static string URLComponents = "https://demo.opencart.com/index.php?route=product/category&amp;path=25";
        public static string Components = "/html/body/div[1]/nav/div[2]/ul/li[3]/div/a";
        public static string ComponentsMiceAndTrackballs = "https://demo.opencart.com/index.php?route=product/category&amp;path=25_29";
        public static string ComponentsMonitors = "https://demo.opencart.com/index.php?route=product/category&amp;path=25_28";
        public static string ComponentsPrinters = "https://demo.opencart.com/index.php?route=product/category&amp;path=25_30";
        public static string ComponentsScanners = "https://demo.opencart.com/index.php?route=product/category&amp;path=25_31";
        public static string ComponentsWebCameras = "https://demo.opencart.com/index.php?route=product/category&amp;path=25_32";
        public static string URLTablets = "https://demo.opencart.com/index.php?route=product/category&amp;path=57";
        public static string Software = "https://demo.opencart.com/index.php?route=product/category&amp;path=17";
        public static string PhonesAndPDAs = "https://demo.opencart.com/index.php?route=product/category&amp;path=24";
        public static string Cameras = "https://demo.opencart.com/index.php?route=product/category&amp;path=33";
        public static string UrlMP3Players = "https://demo.opencart.com/index.php?route=product/category&amp;path=34";
        public static string MP3Players = "/html/body/div[1]/nav/div[2]/ul/li[8]/div/a";

		public static void MouseHover(IWebDriver driver, string Element)
		{
			IWebElement element = driver.FindElement(By.XPath(Element));
			Actions actions = new Actions(driver);
			actions.MoveToElement(element).Build().Perform();
		}
		public static void ClickButton(IWebDriver driver, string type, string button)
		{
			switch (type)
			{
				case "text":
					driver.FindElement(By.Name(button)).Click();
					break;
				case "xpatch":
					driver.FindElement(By.XPath(button)).Click();
					break;
			}	
		}
		public static void goToSite(IWebDriver driver, string site = BasePageAdress)
		{
			driver.Navigate().GoToUrl(site);
		}



		//public static void ShowAllDesctops(IWebDriver driver, string site)
		//{
		//	XPathClickElement(driver, Desctops);
		//	ByTextClickElement(driver, DesctopsText);
		//}

		//public static void ShowAllLaptopsAndNotebooks(IWebDriver driver, string site)
		//{
		//	XPathClickElement(driver, LaptopsAndNotebooks);
		//	ByTextClickElement(driver, LaptopsAndNotebooksText);
		//}

		//public static void ShowAllComponents(IWebDriver driver, string site)
		//{
		//	XPathClickElement(driver, Components);
		//	ByTextClickElement(driver, ComponentsText);
		//}

		//public static void ShowAllMP3Players(IWebDriver driver, string site)
		//{
		//	XPathClickElement(driver, MP3Players);
		//	ByTextClickElement(driver, MP3PlayersText);
		//}


	}
}
