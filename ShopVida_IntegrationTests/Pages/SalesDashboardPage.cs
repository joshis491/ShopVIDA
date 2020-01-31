namespace ShopVidaTests.Pages
{
    using FrameworkTests.Pages;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using System;

    public partial class SalesDashboardPage : SeleniumReporter
    {
        public SalesDashboardPage(RemoteWebDriver driver, AppSettings appSettings)
            : base(appSettings) { }

        internal void RangerPickerForDashboard(string startdate, string enddate)
        {
            rangePicker.Click();
            Wait.Seconds(1);
            startDate.InputKey(startdate);
            DictionaryProperties.Details["StartDate"] = startdate;
            endDate.InputKey(enddate);
            DictionaryProperties.Details["EndDate"] = enddate;
        }

        internal void VerifyDatesInCalenderPicker()
        {
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            string startDateSelectedMonth = commonPage.getMonth(DictionaryProperties.Details["StartDate"].Split('/')[1].ToString());
            string endDateSelectedMonth = commonPage.getMonth(DictionaryProperties.Details["EndDate"].Split('/')[1].ToString());
            Assert.Multiple(() =>
            {
                Assert.AreEqual(startDateYear.GetElementValue(), DictionaryProperties.Details["StartDate"].Split('/')[0]);
                Assert.AreEqual(startDateMonth.GetElementValue(), startDateSelectedMonth);
                StringComparer.CurrentCultureIgnoreCase.Equals(DictionaryProperties.Details["StartDate"].Split('/')[2], startDateDate.GetElementValue());
                Assert.AreEqual(endDateYear.GetElementValue(), DictionaryProperties.Details["EndDate"].Split('/')[0]);
                Assert.AreEqual(endDateMonth.GetElementValue(), endDateSelectedMonth);
                StringComparer.CurrentCultureIgnoreCase.Equals(DictionaryProperties.Details["EndDate"].Split('/')[2], endDateDate.GetElementValue());
            });
        }

        internal void SelectCalenderFooterButton(string buttonName)
        {
            rangePicker.Click();
            Wait.Seconds(1);
            calenderFooter.SelectElementFromLooping(buttonName).Click();
            emptyImage.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 180));
        }

        internal void RelaunchProduct(string artwork, string product)
        {
            DictionaryProperties.Details["Artwork"] = artwork;
            var relaunchBtnList = ElementLocatorExtensions.GetElementXpath(productRelaunch, artwork, product);
            foreach (IWebElement relaunchBtn in relaunchBtnList.GetElements())
            {
                relaunchBtn.HoverOverElement();
                relaunchBtn.ClickButton();
                Wait.Milliseconds(1500);
            }
            if (relaunchBtnList.GetElements().Count.Equals(0))
            {
                Assert.Fail("There is no product in the list with name.");
            }
        }

        internal void VerifyDashboradStatus(string status, string product)
        {
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.LoadingBar();
            var productList = ElementLocatorExtensions.GetElementXpath(productStatus, DictionaryProperties.Details["Artwork"], product);
            foreach (IWebElement ele in productList.GetElements())
            {
                ele.HoverOverElement();
                Assert.IsTrue(ele.Text.Equals(status), "Status is not as expected.");
            }
        }

        internal void RemoveTheProduct(string product)
        {
            var removeBtnList = ElementLocatorExtensions.GetElementXpath(productRemove, DictionaryProperties.Details["Artwork"], product);
            foreach (IWebElement removeBtn in removeBtnList.GetElements())
            {
                removeBtn.HoverOverElement();
                removeBtn.ClickButton();
                Wait.Milliseconds(500);
            }
        }

        internal void SetLimitItems(string value)
        {
            limitItemsSelect.ClickButton();
            Wait.Milliseconds(500);
            commonDropdownList.SelectElementFromLooping(value).ClickButton();
            Wait.Seconds(1);
        }

        internal void WaitForListToHasSize(int size)
        {
            Wait.UntileElementsCollectionHasSize(TableRows, size, new TimeSpan(0, 0, 20));
        }
    }
}