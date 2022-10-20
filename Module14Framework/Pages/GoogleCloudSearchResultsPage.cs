using Module14Framework.Base;
using OpenQA.Selenium;

namespace Module14Framework.Pages
{
	internal class GoogleCloudSearchResultsPage : BasePage
	{
		BaseElement searchResultsList = new BaseElement(By.CssSelector("div.gsc-results"));
		By searchResultLocator = By.CssSelector("a.gs-title");
		string searchResulByStringLocator = "//a[@class='gs-title'][contains(.,'{0}')]";

		public void WaitPageLoaded()
		{
			WaitPageLoaded(searchResultsList);
		}

		public void ClickSearchResult(string searchTerm)
		{
			searchResulByStringLocator = string.Format(searchResulByStringLocator, searchTerm);
			new BaseElement(By.XPath(searchResulByStringLocator)).Click();
		}

		public string GetFirstSearchResult()
		{
			return searchResultsList.FindElements(searchResultLocator)[0].Text;
		}
	}
}