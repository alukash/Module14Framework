using Module14Framework.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using Module14Framework.Base.Driver;

namespace Module14Framework.Steps
{
	internal class YopMailSteps
	{
		static YopMailHomePage homePage;
		static YopMailBoxPage mailBoxPage;

		public static void OpenHomePage()
		{
			Browser.GetDriver().Navigate().GoToUrl("https://yopmail.com/");
			homePage = new YopMailHomePage();
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
			homePage = new YopMailHomePage();
			homePage.ClickGenerateRandomEmailLink();
			return homePage.getRandomEmailText();
		}

		public static void ClickCheckEmailButton()
		{
			homePage = new YopMailHomePage();
			homePage.ClickCheckEmailButton();
		}

		public static void WaitForEmailReceived(string subject)
		{
			mailBoxPage = new YopMailBoxPage();
			mailBoxPage.WaitPageLoaded();
			mailBoxPage.WaitForEmailWithSubject(subject);
		}

		internal static string GetCost()
		{
			mailBoxPage = new YopMailBoxPage();
			return mailBoxPage.GetCost();
		}

		internal static string GetEmailInputText()
		{
			homePage = new YopMailHomePage();
			return homePage.GetEmailInputText();
		}
	}
}
