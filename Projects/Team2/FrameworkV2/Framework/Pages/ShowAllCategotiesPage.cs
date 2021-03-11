using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Pages
{
	class ShowAllCategotiesPage : BasePage
	{
		public const string DesctopsCheckXpatch = "/html/body/div[2]/div/div/h2";
		public const string NotebookAndLapptopeTextCheck = "/html/body/div[2]/div/div/h2";

		public static string TextCheckRead(IWebDriver driver, string TextCheck)
		{
			return driver.FindElement(By.XPath(TextCheck)).Text;
			
		}
	}
}
