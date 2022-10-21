using Module14Framework.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Module14Framework.Base
{
	public class BasePage
	{
		int _defaultTimeout = int.Parse(Configuration.Timeout);
		public IWebDriver driver = Browser.GetDriver();

		public void WaitPageLoaded(BaseElement element)
		{
			WaitPageLoaded(element, _defaultTimeout);
		}

		public void WaitPageLoaded(BaseElement element, int timeout)
		{
			element.WaitUntilDisplayed(timeout);
		}

		public void WaitPageLoaded(string title)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_defaultTimeout));
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			wait.Until(condition =>
			{
				return driver.Title.Equals(title);
			});
		}
	}
}