namespace FrameworkTests.Utilities.Objects
{
    public class AppSettings
    {
        public ConnectionStringModel ConnectionStrings { get; set; }

        public UrlsModel Urls { get; set; }

        public FileLocationsModel FileLocations { get; set; }

        public ScenarioNameModel ScenarioName { get; set; }

        public BrowsersConfigModel BrowsersConfig { get; set; }

        public class ConnectionStringModel
        {

        }

        public class UrlsModel
        {
            public string BaseUrl { get; set; }

            public string LoginUrl { get; set; }

            public string BaseUrlOtherWindow { get; set; }
        }

        public class FileLocationsModel
        {
            public string OutputPath { get; set; }

            public string ScreenshotLocation { get; set; }

            public string ReportLocation { get; set; }

            public string DownloadPdfLocation { get; set; }

            public string ExtentFile { get; set; }

            public string DownloadImg { get; set; }
        }

        public class ScenarioNameModel
        {
            public string AddProductInBag { get; set; }

            public string StorefrontUpgradeBtn { get; set; }

            public string ViewStorefront { get; set; }

            public string PromoteDesign { get; set; }
        }

        public class BrowsersConfigModel
        {
            public string SelectedBrowser { get; set; }
        }
    }
}