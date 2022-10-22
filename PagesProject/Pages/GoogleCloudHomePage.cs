using Module14Framework.Base;
using OpenQA.Selenium;

namespace Module14Framework.Pages
{
	public class GoogleCloudHomePage : BasePage
	{
		BaseElement searchButton = new BaseElement(By.CssSelector(".devsite-search-query"));
		BaseElement searchInput = new BaseElement(By.CssSelector(".devsite-search-field"));

		public void WaitPageLoaded()
		{
			WaitPageLoaded(searchButton);
		}

		public void ClickSearchButton()
		{
			searchButton.Click();
		}

		public void EnterSearchTerm(string searchTerm)
		{
			searchInput.SendKeys(searchTerm);
			searchInput.SendKeys(Keys.Enter);
		}
	}
}