using Module14Framework.Base.Driver;
using Module14Framework.Pages;
using System.Collections.Generic;

namespace Module14Framework.Steps
{
	internal class GoogleCloudSteps
	{
		static GoogleCloudHomePage homePage = new GoogleCloudHomePage();
		static GoogleCloudCalculatorPage calcPage = new GoogleCloudCalculatorPage();
		static GoogleCloudSearchResultsPage searchResultsPage = new GoogleCloudSearchResultsPage();

		public static void OpenHomePage()
		{
			Browser.GetDriver().Navigate().GoToUrl("https://cloud.google.com/");
			homePage.WaitPageLoaded();
		}

		public static void MakeSearch(string searchTerm)
		{
			homePage.ClickSearchButton();
			homePage.EnterSearchTerm(searchTerm);
			searchResultsPage.WaitPageLoaded();
		}

		public static void OpenSearchResult(string searchTerm)
		{
			searchResultsPage.ClickSearchResult(searchTerm);
		}

		public static string GetFirstSearchResult()
		{
			return searchResultsPage.GetFirstSearchResult();
		}

		public static string CalculateCost(int numberOfInstances, string model, string location)
		{
			calcPage.EnterNumberOfInstances(numberOfInstances);
			calcPage.SelectModel(model);
			calcPage.SelectLocation(location);
			calcPage.ClickAddToEstimateButton();
			return calcPage.GetCost();
		}

		public static void SwitchToCalculatorTab()
		{
			string currentWindowHandle = Browser.GetDriver().CurrentWindowHandle;
			List<string> windowHandles = new List<string>(Browser.GetDriver().WindowHandles);
			windowHandles.Remove(currentWindowHandle);
			Browser.SwitchToWindow(windowHandles[0]);
		}

		internal static void SendEmail(string email)
		{
			SwitchToCalculatorTab();
			calcPage.WaitPageLoaded();
			calcPage.SendEmail(email);
		}
	}
}
