namespace ShopVidaTests.Tests.Steps.SalesDashboard
{
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Pages;
    using TechTalk.SpecFlow;

    [Binding]
    public class SalesDashboardSteps : SeleniumReporter
    {
        public SalesDashboardSteps(RemoteWebDriver driver, AppSettings appSettings)
        : base(appSettings)
        {
            Driver = driver;
        }

        [When(@"I select start date ""(.*)"" and end date ""(.*)""")]
        public void WhenISelectStartDateAndEndDate(string startDate, string endDate)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.RangerPickerForDashboard(startDate, endDate);
        }

        [Then(@"Verify the selected dated in calender picker")]
        public void ThenVerifyTheSelectedDatedInCalenderPicker()
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.VerifyDatesInCalenderPicker();
        }

        [When(@"I select ""(.*)"" from calender picker")]
        public void WhenISelectFromCalenderPicker(string buttonName)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.SelectCalenderFooterButton(buttonName);
        }

        [When(@"Relaunch the ""(.*)"" with ""(.*)"" type")]
        public void WhenRelaunchTheWithType(string artwork, string product)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.RelaunchProduct(artwork, product);
        }

        [Then(@"Verify status should changed to ""(.*)"" for ""(.*)"" product")]
        public void ThenVerifyStatusShouldChangedToForProduct(string status, string product)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.VerifyDashboradStatus(status, product);
        }

        [When(@"I Remove the products with ""(.*)"" type")]
        public void WhenIRemoveTheProductsWithType(string product)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.RemoveTheProduct(product);
        }

        [When(@"I select ""(.*)"" value in Limit items filter")]
        public void WhenISelectValueInLimitItemsFilter(string value)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.SetLimitItems(value);
        }

        [Then(@"There should be (.*) results on resources list")]
         public void ThenThereShouldBeResultsOnResourcesList(int expectedNumber)
        {
            SalesDashboardPage salesDashboard = new SalesDashboardPage(Driver, _appSettings);
            salesDashboard.WaitForListToHasSize(expectedNumber);
        }
    }
}