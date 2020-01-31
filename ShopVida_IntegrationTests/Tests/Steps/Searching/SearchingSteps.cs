namespace ShopVidaTests.Tests.Steps.Searching
{
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class SearchingSteps : SeleniumReporter
    {
        public SearchingSteps(RemoteWebDriver driver, AppSettings appSettings)
            : base(appSettings)
        {
            Driver = driver;
        }

        [When(@"I click on search button on home page")]
        public void WhenIClickOnSearchButtonOnHomePage()
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.ClickHomePageSearchButton();
        }

        [When(@"Input the search data as ""(.*)""")]
        public void WhenInputTheSearchDataAs(string inputData)
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.SetSearchData(inputData);
        }

        [Then(@"Verify all search result details have ""(.*)""")]
        public void ThenVerifyAllSearchResultDetailsHave(string value)
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.IsSearchedDetailsVerified(value);
        }


        [When(@"I Select ""(.*)"" and ""(.*)"" from search details")]
        public void WhenISelectAndFromSearchDetails(string artwork, string product)
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.SelectProductFromSearchDetails(artwork, product);
        }

        [Then(@"Verify display ""(.*)"" and ""(.*)"" name should be correct")]
        public void ThenVerifyDisplayAndNameShouldBeCorrect(string artwork, string product)
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.VerifyDeailsOnProductModal(artwork, product);
        }

        [When(@"I Set the quantity as ""(.*)""")]
        public void WhenISetTheQuantityAs(string quantity)
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.SetTheQuantity(quantity);
        }

        [When(@"Preview the images for ProductModal slider")]
        public void WhenPreviewTheImagesForProductModalSlider()
        {
            SearchingPage searching = new SearchingPage(Driver, _appSettings);
            searching.PreviewProductModalImages();
        }
    }
}