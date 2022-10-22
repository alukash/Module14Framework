using Module14Framework.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using Module14Framework.Base.Driver;

namespace Module14Framework.Steps
{
	internal class YopMailSteps
	{
		static YopMailHomePage homePage = new YopMailHomePage();
		static YopMailBoxPage mailBoxPage = new YopMailBoxPage();

		public static void OpenHomePage()
		{
			Browser.GetDriver().Navigate().GoToUrl("https://yopmail.com/");
			homePage.WaitPageLoaded();
		}

		public static void OpenHomePageInNewTab()
		{
			Browser.ExecuteScript("window.open()");
			string currentWindowHandle = Browser.GetDriver().CurrentWindowHandle;
			List<string> windowHandles = new List<string>(Browser.GetDriver().WindowHandles);
			windowHandles.Remove(currentWindowHandle);
			Browser.SwitchToWindow(windowHandles[0]);
			OpenHomePage();
		}

		public static string GetEmailAddress()
		{
			homePage.ClickGenerateRandomEmailLink();
			return homePage.getRandomEmailText();
		}

		public static void ClickCheckEmailButton()
		{
			homePage.ClickCheckEmailButton();
			mailBoxPage.WaitPageLoaded();
		}

		public static void WaitForEmailReceived(string subject)
		{
			mailBoxPage.WaitForEmailWithSubject(subject);
		}

		internal static string GetCost()
		{
			return mailBoxPage.GetCost();
		}

		internal static string GetEmailInputText()
		{
			return homePage.GetEmailInputText();
		}
	}
}
