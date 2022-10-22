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
			string browserType = TestContext.Parameters.Get("Browser", "Chrome");
			logger.Info(browserType + " browser is about to start");

			string args = JsonReader.Read(browserType);
			args = args ?? "--start-maximized";

			switch (browserType)
			{
				case "Chrome":
					{
						ChromeOptions opts = new ChromeOptions();
						opts.AddArgument(args);
						return new ChromeDriver(opts);
					}
				case "Firefox":
					{
						FirefoxOptions opts = new FirefoxOptions();
						opts.AddArgument(args);
						return new FirefoxDriver(opts);
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