using Module14Framework.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Module14Framework.Base.Driver
{
	internal class DriverFactory
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		internal static IWebDriver InitDriver()
		{
			IWebDriver driver;
			string browserType = TestContext.Parameters.Get("Browser", "Chrome");
			string args = JsonReader.Read(browserType);
			args = args ?? "--start-maximized";

			switch (browserType)
			{
				case "Chrome":
					{
						ChromeOptions opts = new ChromeOptions();
						opts.AddArgument(args);
						driver = new ChromeDriver(opts);
						logger.Info("Chrome has been started");
						return driver;
					}
				case "Firefox":
					{
						FirefoxOptions opts = new FirefoxOptions();
						opts.AddArgument(args);
						driver =  new FirefoxDriver(opts);
						logger.Info("Firefox has been started");
						return driver;
					}
				default:
					{
						string errorMessage = "Unknown type of browser: " + browserType;
						logger.Error(errorMessage);
						throw new ArgumentException(errorMessage);
					}
			}
		}
	}
}