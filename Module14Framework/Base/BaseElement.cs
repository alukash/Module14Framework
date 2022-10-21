using Module14Framework.Base.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Module14Framework.Base
{
	internal class BaseElement : IWebElement
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		IWebDriver _driver = Browser.GetDriver();
		int _defaultTimeout = int.Parse(Configuration.Timeout);
		By _locator;

		public BaseElement(By locator)
		{
			_locator = locator;
		}

		public IWebElement WaitUntilDisplayed()
		{
			return WaitUntilDisplayed(_defaultTimeout);
		}

		public IWebElement WaitUntilDisplayed(int timeout)
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
			wait.Until(condition =>
			{
				return _driver.FindElement(_locator).Displayed;
			});
			return _driver.FindElement(_locator);
		}

		public void WaitUntilNotDisplayed()
		{
			int timeout = 5;
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
			wait.Until(condition =>
			{
				try
				{
					return !_driver.FindElement(_locator).Displayed;
				}
				catch (Exception e)
				{
					return true;
				}
			});
		}

		public bool IsDisplayed()
		{
			IList<IWebElement> elements = _driver.FindElements(_locator);
			if (elements.Count == 0)
			{
				return false;
			}
			else
			{
				return elements[0].Displayed;
			}
		}

		public string GetText()
		{
			return WaitUntilDisplayed().Text;
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void Click()
		{
			logger.Debug("Click element: " + _locator);
			WaitUntilDisplayed().Click();
		}

		public IWebElement FindElement(By by)
		{

			return _driver.FindElement(by);
		}

		public ReadOnlyCollection<IWebElement> FindElements(By by)
		{
			return _driver.FindElements(by); ;
		}

		public string GetAttribute(string attributeName)
		{
			throw new NotImplementedException();
		}

		public string GetCssValue(string propertyName)
		{
			throw new NotImplementedException();
		}

		public string GetProperty(string propertyName)
		{
			throw new NotImplementedException();
		}

		public void SendKeys(string text)
		{
			WaitUntilDisplayed().SendKeys(text);
		}

		public void Submit()
		{
			throw new NotImplementedException();
		}

		public string TagName { get; }

		public string Text { get; }

		public bool Enabled { get; }

		public bool Selected { get; }

		public Point Location { get; }

		public Size Size { get; }

		public bool Displayed { get; }
	}
}
