using Module14Framework.Base;
using Module14Framework.Steps;
using NUnit.Framework;

namespace Module14Framework.Tests
{
	public class AllTests : BaseTest
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		[Test]
		[Category("Regression")]
		public void GetMachimeCostByEmail()
		{
			string searchTerm = "Google Cloud Platform Pricing Calculator";
			int numberOfInstances = 4;
			string model = "Regular";
			string location = "Frankfurt (europe-west3)";
			const string emailSubject = "Google Cloud Price Estimate";

			GoogleCloudSteps.OpenHomePage();
			GoogleCloudSteps.MakeSearch(searchTerm);
			GoogleCloudSteps.OpenSearchResult(searchTerm);
			string costCalculator = GoogleCloudSteps.CalculateCost(numberOfInstances, model, location);
			logger.Debug("costCalculator=" + costCalculator);

			YopMailSteps.OpenHomePageInNewTab();
			string emailAddress = YopMailSteps.GetEmailAddress();
			logger.Debug("emailAddress=" + emailAddress);

			GoogleCloudSteps.SendEmail(emailAddress);

			YopMailSteps.ClickCheckEmailButton();
			YopMailSteps.WaitForEmailReceived(emailSubject);
			string costFromEmail = YopMailSteps.GetCost();
			logger.Debug("costFromEmail=" + costFromEmail);
			Assert.AreEqual(costCalculator, costFromEmail, "Costs are not equal");
		}

		[Test]
		[Category("Smoke")]
		[Category("Regression")]
		public void FirstSearchResultCorrespondToSearchTerm()
		{
			string searchTerm = "Google Cloud Pricing Calculator";

			GoogleCloudSteps.OpenHomePage();
			GoogleCloudSteps.MakeSearch(searchTerm);
			string searchResult = GoogleCloudSteps.GetFirstSearchResult();
			Assert.AreEqual(searchTerm, searchResult, "Search result is not correct");
		}

		[Test]
		[Category("Smoke")]
		[Category("Regression")]
		public void EmailAddressInputIsEmpty()
		{
			YopMailSteps.OpenHomePage();
			string email = YopMailSteps.GetEmailInputText();
			Assert.IsTrue(email.Length == 0, "Email input is not empty: " + email);
		}

		[Test]
		[Category("Smoke")]
		[Category("Fail")]
		public void FailTest()
		{
			Assert.Fail("Test that should failed");
		}
	}
}