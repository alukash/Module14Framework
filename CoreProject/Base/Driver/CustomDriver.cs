using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Module14Framework.Base.Driver
{
	internal class CustomDriver : IWebDriver
	{
		IWebDriver _driver;

		public CustomDriver(IWebDriver driver)
		{
			_driver = driver;
		}

		public string Url { get => _driver.Url; set => _driver.Url = value; }

		public string Title => _driver.Title;

		public string PageSource => _driver.PageSource;

		public string CurrentWindowHandle => _driver.CurrentWindowHandle;

		public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

		public void Close()
		{
			_driver.Close();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IWebElement FindElement(By by)
		{
			return _driver.FindElement(by);
		}

		public ReadOnlyCollection<IWebElement> FindElements(By by)
		{
			return _driver.FindElements(by);
		}

		public IOptions Manage()
		{
			return _driver.Manage();
		}

		public INavigation Navigate()
		{
			return _driver.Navigate();
		}

		public void Quit()
		{
			_driver.Quit();
		}

		public ITargetLocator SwitchTo()
		{
			return _driver.SwitchTo();
		}

		public IWebDriver GetWrappedDriver()
		{
			return _driver;
		}
	}
}
