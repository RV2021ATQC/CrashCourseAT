using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Framework.Tools
{
	class BrowserOption
	{
		private IWebDriver driver;
		public static ChromeOptions BrowserSettings()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("start-maximized");   
			options.AddArgument("disable-infobars");
			return options;
		}
		public IWebDriver OptionForSelenoid()
		{
			var driverOptions = new ChromeOptions();
			var runName = GetType().Assembly.GetName().Name;
			var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";
			driverOptions.AddArgument("start-maximized");
			driverOptions.AddAdditionalCapability("name", runName, true);
			driverOptions.AddAdditionalCapability("videoName", $"{runName}.{timestamp}.mp4", true);
			driverOptions.AddAdditionalCapability("logName", $"{runName}.{timestamp}.log", true);
			driverOptions.AddAdditionalCapability("enableVNC", true, true);
			driverOptions.AddAdditionalCapability("enableVideo", true, true);
			driverOptions.AddAdditionalCapability("enableLog", true, true);
			driverOptions.AddAdditionalCapability("screenResolution", "1920x1080x24", true);
			driver = new RemoteWebDriver(new Uri("http://127.0.0.1:8080/wd/hub"), driverOptions);
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
			return driver;
		}
	}
}
