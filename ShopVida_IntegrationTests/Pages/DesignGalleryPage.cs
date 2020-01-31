namespace ShopVidaTests.Pages
{
    using FrameworkTests.Pages;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using System;

    public partial class DesignGalleryPage : SeleniumReporter
    {
        public DesignGalleryPage(RemoteWebDriver driver, AppSettings appSettings)
             : base(appSettings) { }

        internal void IsADesignAdded()
        {
            if (noDesign.IsDisplayed())
            {
                ElementLocatorExtensions.GetElementXpath(selectMenu, "Create New Product").ClickButton();
                Wait.Seconds(2);
                ElementLocatorExtensions.GetElementXpath(getCategoryAndSubCategory, "bags", "Handbags").ClickButton();
                productSubCatText.UntilElementIsDisplayed(new TimeSpan(0, 0, 15));
                ElementLocatorExtensions.GetElementXpath(selectSubCatagotyTitle, "Tote Bag").ClickButton();
                ElementLocatorExtensions.GetElementXpath(commonButton, "Launch Product").UntilElementIsDisplayed(new TimeSpan(0, 0, 15));
                CommonPage commonPage = new CommonPage(Driver, _appSettings);
                commonPage.GenerateImage();
                ElementLocatorExtensions.GetElementXpath(commonButton, "Upload Artwork").Click();
                Wait.Seconds(2);
                commonPage.UploadPhoto();
                inputDesignName.InputKey("Artwork1");
                Wait.Seconds(1);
                ElementLocatorExtensions.GetElementXpath(commonButton, "Save").ClickButton();
                Wait.Seconds(4);
                closeIcon.Click();
                Wait.Seconds(3);
            }
        }

        internal void SelectDesignFromGallery(string designName)
        {
            designCardTitle.SelectElementFromLooping(designName).ClickButton();
        }

        internal void VerifyHeaderTextDesignPage(string textToBeCompared)
        {
            reuseDesignText.UntilElementIsDisplayed(new TimeSpan(0, 0, 30));
            Assert.AreEqual(reuseDesignText.GetElementValue().ToUpper(), textToBeCompared.ToUpper(), "Re-Use design text is not matched.");
        }

        internal void VerifyActiveStepText(string action) 
        {
            Assert.AreEqual(activeStep.GetElementValue(), action, "Active step text is not as expected.");
        }

        internal void SetPromotionFirstStepData(string promotedOn, string promotionDate)
        {
            promotedDropdown.ClickButton();
            Wait.Seconds(1);
            commonDropdownList.SelectElementFromLooping(promotedOn).ClickButton();
            Wait.Seconds(1);
            promotionCalender.Click();
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.SelectDateFromDatePicker(promotionDate);
        }

        internal void SelectThePlan(string plan)
        {
            promotionPlan.SelectElementFromLooping(plan).ClickButton();
            Assert.IsTrue(promotionPlan.SelectElementFromLooping(plan).GetElementValueByAttribute("class").Contains("is-selected"));
        }
    }
}