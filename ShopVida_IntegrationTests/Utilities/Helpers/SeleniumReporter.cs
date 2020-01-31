namespace FrameworkTests.Utilities.Helpers
{
	using FrameworkTests.Configuration;
	using FrameworkTests.Pages;
	using FrameworkTests.Utilities.Objects;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Interactions;
	using OpenQA.Selenium.Remote;
	using System;
	using System.IO;

	public abstract class SeleniumReporter : CommonPageLocators
	{
		private static readonly AppSettings _appSetting = TestConfiguration.GetAppSettings();

		public static IJavaScriptExecutor JavaScriptExecutor => Driver as IJavaScriptExecutor;

		public static Actions Actions => new Actions(Driver);

        protected readonly AppSettings _appSettings;

        public static RemoteWebDriver Driver;

		public SeleniumReporter(AppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public static string TakeScreenshot(string testName)
		{
			string screenShotLocation = null;
			try
			{
				ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
				Screenshot screenshot = screenshotDriver.GetScreenshot();
				string screenShotName = $"{DateTime.UtcNow:yyyy_MM_dd_HH-mm-ss}.png";
				screenShotLocation = Path.GetFullPath(Path.Combine(_appSetting.FileLocations.OutputPath, _appSetting.FileLocations.ScreenshotLocation));
				var screenShotFile = Path.Combine(screenShotLocation, screenShotName);
				if (!Directory.Exists(screenShotLocation))
				{
					Directory.CreateDirectory(screenShotLocation);
				}
				DeleteScreenshotIfExist(screenShotName);
				screenshot.SaveAsFile(screenShotFile, ScreenshotImageFormat.Gif);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			return screenShotLocation;
		}

		public static void DeleteScreenshotIfExist(string pathWithFileName)
		{
			try
			{
				if (File.Exists(pathWithFileName))
				{
					File.Delete(pathWithFileName);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public static string GetScreenshotFullPath(string name)
		{
			return Path.Combine(TestConfigurationSection.SectionDetails.ScreenshotDirectory, $"{name}.png");
		}
	}
}