using OpenQA.Selenium;
using System.Diagnostics;

namespace Module14Framework.Base.Driver
{
	internal class Browser
	{
		static IWebDriver _driver;

		public static IWebDriver InitDriver()
		{
			_driver = null;
			return GetDriver();
		}

		public static IWebDriver GetDriver()
		{
			_driver = _driver ?? new CustomDriver(DriverFactory.GetDriver());
			return _driver;
		}

		internal static void Quit()
		{
			_driver.Quit();
		}

		public static void SwitchToDefault()
		{
			_driver.SwitchTo().DefaultContent();
		}

		public static void SwitchToFrame(IWebElement element)
		{
			_driver.SwitchTo().Frame(element);
		}

		public static void SwitchToWindow(string window)
		{
			_driver.SwitchTo().Window(window);
		}
	}
}