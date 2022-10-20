using Module14Framework.Base.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Module14Framework.Base
{
	public class BaseTest
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		[SetUp]
		public static void Setup()
		{
			logger.Info($"{TestContext.CurrentContext.Test.Name} is starting");
			Browser.InitDriver();
		}

		[TearDown]
		public static void TearDown()
		{
			logger.Info($"{TestContext.CurrentContext.Test.Name} is finished");

			if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
			{
				TakeScreenshot();
			}
			Browser.Quit();
		}

		private static void TakeScreenshot()
		{
			var screenshot = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
			string timeStamp = DateTime.Now.ToString("_MM-dd_HH-mm-ss");
			string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
			string testName = TestContext.CurrentContext.Test.Name;
			string file = projectDirectory + "\\Screenshots\\" + testName + timeStamp + ".png";
			screenshot.SaveAsFile(file);
		}
	}
}
