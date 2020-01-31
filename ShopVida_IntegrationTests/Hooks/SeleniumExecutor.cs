namespace FrameworkTests.Hooks
{
	using AventStack.ExtentReports;
	using AventStack.ExtentReports.Gherkin.Model;
	using AventStack.ExtentReports.Reporter;
	using AventStack.ExtentReports.Reporter.Configuration;
    using BoDi;
    using FrameworkTests.Configuration;
	using FrameworkTests.Utilities.Enums;
	using FrameworkTests.Utilities.Helpers;
	using FrameworkTests.Utilities.Objects;
	using NUnit.Framework;
	using OpenQA.Selenium.Chrome;
	using OpenQA.Selenium.Edge;
	using OpenQA.Selenium.Firefox;
	using OpenQA.Selenium.IE;
	using OpenQA.Selenium.Support.UI;
    using ShopVidaTests.Utilities.Helpers;
    using System;
	using System.Collections.Generic;
	using System.IO;
    using System.Linq;
    using TechTalk.SpecFlow;

	[Binding]
	public class SeleniumExecutor : SeleniumReporter
	{
        private SharedStorage sharedStorage;

        private static ExtentTest featureName;

		private static ExtentTest scenario;

		public static ExtentHtmlReporter htmlReporter;

		private static ExtentReports extent;

		private readonly IObjectContainer objectContainer;

		private static new readonly AppSettings _appSettings = TestConfiguration.GetAppSettings();

		private ScenarioContext scenarioContext;

		private FeatureContext featureContext;


        public SeleniumExecutor(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
			: base(_appSettings)
		{
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }

		[BeforeTestRun]
		public static ExtentReports InitializeReport()
		{
			if (extent == null)
			{
				extent = new ExtentReports();
				var reporters = new List<IExtentReporter> { GetHtmlReporter() };
				extent.AttachReporter(reporters.ToArray());
				extent.AddSystemInfo("Host Name", "Rangoli Sharan");
				extent.AddSystemInfo("Project Info", "Vida Design Studio");
				extent.AddSystemInfo("User Name", "Shubham Joshi");
			}

			return extent;
		}

		private static ExtentHtmlReporter GetHtmlReporter()
		{
			string fileName = $"{DateTime.UtcNow:yyyy_MM_dd_HH-mm-ss}.html";
			string reportLocation = Path.GetFullPath(Path.Combine(_appSettings.FileLocations.OutputPath, _appSettings.FileLocations.ReportLocation));
            if (!Directory.Exists(reportLocation))
			{
				Directory.CreateDirectory(reportLocation);
			}
			htmlReporter = new ExtentHtmlReporter(Path.Combine(reportLocation, "ShopVida_" + fileName))
			{
				AppendExisting = true
			};
			var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _appSettings.FileLocations.ExtentFile);
            Assert.That(new FileInfo(configFile), Does.Exist, "Configuration file does not exists.");
            htmlReporter.LoadConfig(configFile);
			htmlReporter.Configuration().Theme = Theme.Dark;
			htmlReporter.Configuration().ReportName = "Shop Vida Regression Test Report";
			htmlReporter.Configuration().ChartVisibilityOnOpen = true;
			htmlReporter.Configuration().ChartLocation = ChartLocation.Bottom;		
            
			return htmlReporter;
		}

		[AfterTestRun]
		public static void ClearScenarioContext()
		{
			ScenarioContext.Current.Clear();
		}

		[AfterStep]
		public void InsertReportingSteps()
		{
			var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
			if (scenarioContext.TestError == null)
			{
				if (stepType == "Given")
				{
					scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
				}
				else if (stepType == "When")
				{
					scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
				}
				else if (stepType == "Then")
				{
					scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
				}
			}
			if (scenarioContext.TestError != null)
			{
				if (stepType == "Given")
				{
					scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
				}
				else if (stepType == "When")
				{
					scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
				}
				else if (stepType == "Then")
				{
					scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
				}
			}
		}

		[BeforeScenario]
		public void Initialize()
		{
			featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
			scenarioContext["Email"] = null;
			SelectBrowser((BrowserType)Enum.Parse(typeof(BrowserType), _appSettings.BrowsersConfig.SelectedBrowser, true));
			RegisterDependencies();
			scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
			DictionaryProperties.Details["ScenarioName"] = scenarioContext.ScenarioInfo.Title;
		}

		[AfterScenario(Order = 1)]
		public void TakeScreenshot()
		{
			if (scenarioContext.TestError != null)
			{
				TakeScreenshot(TestContext.CurrentContext.Test.Name);
			}
		}

        [AfterScenario(Order = 2)]
		public static void GenerateReport()
		{
			extent.Flush();
		}

		[AfterScenario(Order = 3)]
		public void CloseDriver()
		{
			Driver.Close();
			Driver.Quit();
			Driver.Dispose();
		}

		[AfterScenario(Order = 4)]
		public void ClearDictionary()
		{
			DictionaryProperties.Details.Clear();
		}

		private void RegisterDependencies()
		{
			objectContainer.RegisterInstanceAs(_appSettings);
		}
		private void SelectBrowser(BrowserType browserType)
		{
			var downloadFilepath = Path.GetFullPath(Path.Combine(_appSettings.FileLocations.OutputPath, _appSettings.FileLocations.DownloadPdfLocation));
			string filePath = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
			switch (browserType)
			{
				case BrowserType.Chrome:
					ChromeOptions chromeProfile = new ChromeOptions();
					//ChromeOption.AddArguments("--headless");
					chromeProfile.AddArgument("no-sandbox");
					chromeProfile.AddUserProfilePreference("download.default_directory", downloadFilepath);
					Driver = new ChromeDriver(filePath, chromeProfile, new TimeSpan(0, 0, 60));
					objectContainer.RegisterInstanceAs(Driver);

					break;

				case BrowserType.Firefox:
					FirefoxOptions firefoxProfile = new FirefoxOptions();
					firefoxProfile.SetPreference("browser.download.folderList", 2);
					firefoxProfile.SetPreference("browser.download.dir", downloadFilepath);
					Driver = new FirefoxDriver(filePath, firefoxProfile, new TimeSpan(0, 0, 60));
					objectContainer.RegisterInstanceAs(Driver);

					break;

				case BrowserType.InternetExplorer:
					InternetExplorerOptions IEProfile = new InternetExplorerOptions();
					IEProfile.AddAdditionalCapability("browser.download.folderList", 2);
					IEProfile.AddAdditionalCapability("browser.download.dir", downloadFilepath);
					Driver = new InternetExplorerDriver(filePath, IEProfile, new TimeSpan(0, 0, 60));
					objectContainer.RegisterInstanceAs(Driver);

					break;

				case BrowserType.Edge:
					EdgeOptions edgeProfile = new EdgeOptions();
					edgeProfile.AddAdditionalCapability("browser.download.dir", downloadFilepath);
					edgeProfile.AddAdditionalCapability("browser.download.folderList", 2);
					Driver = new EdgeDriver(filePath, edgeProfile, new TimeSpan(0, 0, 60));
					objectContainer.RegisterInstanceAs(Driver);

					break;

				default:
					break;
			}
		}

		public static WebDriverWait WaitDriver(TimeSpan? customTimeout = null)
		{
			var waitTimeout = customTimeout ?? TimeSpan.FromSeconds(TestConfigurationSection.SectionDetails.WaitTimeout);
			return new WebDriverWait(Driver, waitTimeout);
		}
    }
}