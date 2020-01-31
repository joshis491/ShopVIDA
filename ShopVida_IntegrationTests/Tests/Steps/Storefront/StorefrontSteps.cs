namespace ShopVidaTests.Tests.Steps.Storefront
{
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Pages;
    using ShopVidaTests.Utilities.Enums;
    using ShopVidaTests.Utilities.Helpers;
    using ShopVidaTests.Utilities.Objects;
    using TechTalk.SpecFlow;

    [Binding]
    public class StorefrontSteps : SeleniumReporter
    {
        private SharedStorage sharedStorage;

        public StorefrontSteps(RemoteWebDriver driver, AppSettings appSettings, SharedStorage sharedStorage)
              : base(appSettings)
        {
            Driver = driver;
            this.sharedStorage = sharedStorage;
        }

        [When(@"I click ""(.*)"" link")]
        public void WhenIClickLink(string link)
        {
            StorefrontPage storefront = new StorefrontPage(Driver, _appSettings);
            storefront.ClickLink(link);
        }

        [When(@"I select ""(.*)"" purchase amount")]
        public void WhenISelectPurchaseAmount(string amount)
        {
            StorefrontPage storefront = new StorefrontPage(Driver, _appSettings);
            storefront.SelectPurchaseAmount(amount);
        }

        [Then(@"Verify purchase amount tab should be shown as selected")]
        public void ThenVerifyPurchaseAmountTabShouldBeShownAsSelected()
        {
            StorefrontPage storefront = new StorefrontPage(Driver, _appSettings);
            storefront.IsPurchaseAmountSelected();
        }

        [Then(@"Verify the total amount for selected plan")]
        public void ThenVerifyTheTotalAmountForSelectedPlan()
        {
            StorefrontPage storefront = new StorefrontPage(Driver, _appSettings);
            storefront.VerifyTotalPurchaseCost();
        }

        [When(@"I get Storefront data from file ""(.*)""")]
        public void GivenIGetStorefrontDataFromFile(string file)
        {
            string data = DataFiles.ReadJsonDataFile(file);
            StorefrontData storefront = ObjectSerializer.DeserializeToObject<StorefrontData>(data);
            sharedStorage.SetSharedInfo(ContextTag.GetStorefrontData, storefront);
        }

        [Then(@"I fill payment form and verify validation messages")]
        public void WhenIFillPaymentForm()
        {
            StorefrontData storefront = sharedStorage.GetSharedInfo<StorefrontData>(ContextTag.GetStorefrontData);
            StorefrontPage storefrontPage = new StorefrontPage(Driver, _appSettings);
            storefrontPage.SetPaymentDataWithValidations(storefront);
        }
    }
}