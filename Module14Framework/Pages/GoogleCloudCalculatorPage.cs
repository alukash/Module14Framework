using Module14Framework.Base;
using Module14Framework.Base.Driver;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace Module14Framework.Pages
{
	internal class GoogleCloudCalculatorPage : BasePage
	{
		BaseElement frame1 = new BaseElement(By.CssSelector("#cloud-site iframe"));
		BaseElement frame2 = new BaseElement(By.CssSelector("#myFrame"));
		BaseElement addToEstimateButton = new BaseElement(By.CssSelector("div[ng-if='listingCtrl.showComputeEngine'] button.md-raised"));
		BaseElement emailEstimatesButton = new BaseElement(By.CssSelector("button#email_quote"));
		BaseElement emailInput = new BaseElement(By.CssSelector("input[ng-model='emailQuote.user.email']"));
		BaseElement sendEmailButton = new BaseElement(By.CssSelector("md-dialog-actions button:nth-child(2)"));
		BaseElement costText = new BaseElement(By.CssSelector(".md-title .ng-binding"));
		BaseElement instancesInput = new BaseElement(By.CssSelector("input[ng-model='listingCtrl.computeServer.quantity']"));
		BaseElement modelSelect = new BaseElement(By.CssSelector("md-select[ng-model='listingCtrl.computeServer.class']"));
		BaseElement locationSelect = new BaseElement(By.CssSelector("md-select[ng-model='listingCtrl.computeServer.location']"));
		string modelOptionLocator = "//md-option[contains(.,'{0}')]";
		string locationOptionLocator = "//div[contains(@class,'md-active')]//md-option[contains(.,'{0}')]";

		public void WaitPageLoaded()
		{
			WaitPageLoaded(frame1);
		}

		private void SwitchFrames()
		{
			Browser.SwitchToFrame(frame1.WaitUntilDisplayed());
			Browser.SwitchToFrame(frame2.WaitUntilDisplayed());
		}

		public string GetCost()
		{
			SwitchFrames();
			string cost = costText.GetText();
			Match match = Regex.Match(cost, "\\d{1,3}\\.\\d{2}");
			return match.Value;
		}

		public void EnterNumberOfInstances(int numberOfInstances)
		{
			SwitchFrames();
			instancesInput.SendKeys(numberOfInstances.ToString());
			Browser.SwitchToDefault();
		}

		internal void SelectModel(string model)
		{
			SwitchFrames();
			modelSelect.Click();
			modelOptionLocator = string.Format(modelOptionLocator, model);
			new BaseElement(By.XPath(modelOptionLocator)).Click();
			Browser.SwitchToDefault();
		}

		internal void SelectLocation(string location)
		{
			SwitchFrames();
			locationSelect.Click();
			locationOptionLocator = string.Format(locationOptionLocator, location);
			new BaseElement(By.XPath(locationOptionLocator)).Click();
			Browser.SwitchToDefault();
		}

		internal void ClickAddToEstimateButton()
		{
			SwitchFrames();
			addToEstimateButton.Click();
			Browser.SwitchToDefault();
		}

		internal void SendEmail(string email)
		{
			SwitchFrames();
			emailEstimatesButton.Click();
			emailInput.SendKeys(email);
			sendEmailButton.Click();
			Browser.SwitchToDefault();
		}
	}
}