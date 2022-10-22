using Module14Framework.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Module14Framework.Base
{
	public class BasePage
	{
		int _defaultTimeout = int.Parse(Configuration.Timeout);
		IWebDriver Driver { get => Browser.GetDriver(); }

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
			var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(_defaultTimeout));
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			wait.Until(condition =>
			{
				return Driver.Title.Equals(title);
			});
		}
	}
}