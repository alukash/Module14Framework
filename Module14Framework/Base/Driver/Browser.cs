using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;

namespace Module14Framework.Base.Driver
{
	internal class Browser
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		
		static IWebDriver _driver;

		public static IWebDriver InitDriver()
		{
			_driver = null;
			return GetDriver();
		}

		public static IWebDriver GetDriver()
		{
			_driver = _driver ?? new CustomDriver(DriverFactory.InitDriver());
			return _driver;
		}

		internal static void Quit()
		{
			if(_driver != null)
			{
				_driver.Quit();
			}
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

		public static void TakeScreenshot()
		{
			try
			{
				var screenshot = ((ITakesScreenshot)((CustomDriver)_driver).GetWrappedDriver()).GetScreenshot();
				string timeStamp = DateTime.Now.ToString("_MM-dd_HH-mm-ss");
				string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
				string testName = TestContext.CurrentContext.Test.Name;
				string file = projectDirectory + "\\Screenshots\\" + testName + timeStamp + ".png";
				screenshot.SaveAsFile(file);
			}
			catch(Exception e)
			{
				logger.Error("Failed to take screenshot: " + e.Message);
			}
		}
	}
}