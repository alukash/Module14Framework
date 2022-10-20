using Module14Framework.Base;
using Module14Framework.Base.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Module14Framework.Pages
{
    internal class YopMailHomePage : BasePage
	{
		BaseElement generateRandomEmailLink = new BaseElement(By.CssSelector("a[href='email-generator']"));
		BaseElement randomEmailText = new BaseElement(By.CssSelector("#egen"));
		BaseElement checkEmailButton = new BaseElement(By.CssSelector(".nw button[onclick='egengo();']"));
		BaseElement emailInput = new BaseElement(By.CssSelector("input.ycptinput"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(generateRandomEmailLink);
		}

		public void ClickGenerateRandomEmailLink()
		{
			generateRandomEmailLink.Click();
		}

		public string getRandomEmailText()
		{
			return randomEmailText.GetText();
		}

		public void SwitchToYopMailTab()
		{
			string currentWindowHandle = Browser.GetDriver().CurrentWindowHandle;
			List<string> windowHandles = new List<string>(Browser.GetDriver().WindowHandles);
			windowHandles.Remove(currentWindowHandle);
			Browser.SwitchToWindow(windowHandles[0]);
		}

		public void ClickCheckEmailButton()
		{
			SwitchToYopMailTab();
			checkEmailButton.Click();
		}

		public string GetEmailInputText()
		{
			return emailInput.GetText();
		}
	}
}