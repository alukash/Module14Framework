using Module14Framework.Base;
using Module14Framework.Base.Driver;
using OpenQA.Selenium;
using Polly;
using System;
using System.Text.RegularExpressions;

namespace Module14Framework.Pages
{
	internal class YopMailBoxPage : BasePage
	{
		BaseElement refreshButton = new BaseElement(By.CssSelector("#refresh"));
		BaseElement costText = new BaseElement(By.XPath("//table//td[h3[.='Total Estimated Monthly Cost']]/following-sibling::td/h3"));
		BaseElement frame = new BaseElement(By.CssSelector("#ifmail"));
		string emailSubjectLocator = "//div[.='{0}']";

		public void WaitPageLoaded()
		{
			WaitPageLoaded(refreshButton);
		}

		internal void WaitForEmailWithSubject(string subject)
		{
			emailSubjectLocator = string.Format(emailSubjectLocator, subject);
			BaseElement subjectElement = new BaseElement(By.XPath(emailSubjectLocator));

			Policy
				.Handle<ApplicationException>()
				.WaitAndRetry(retryCount: 10, sleepDuration => TimeSpan.FromSeconds(5))
				.Execute(() =>
				{
					Browser.SwitchToFrame(frame.WaitUntilDisplayed());
					if (!subjectElement.IsDisplayed())
					{
						Browser.SwitchToDefault();
						refreshButton.Click();
						throw new ApplicationException("No email with {subject} subject received");
					}
				});
			Browser.SwitchToDefault();
		}

		public string GetCost()
		{
			Browser.SwitchToFrame(frame.WaitUntilDisplayed());
			string costString = costText.GetText();
			Match match = Regex.Match(costString, "\\d{1,3}\\.\\d{2}");
			Browser.SwitchToDefault();
			return match.Value;
		}
	}
}