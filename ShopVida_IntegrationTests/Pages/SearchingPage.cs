namespace ShopVidaTests.Pages
{
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using System;

    public partial class SearchingPage : SeleniumReporter
    {
        public SearchingPage(RemoteWebDriver driver, AppSettings appSettings)
          : base(appSettings) { }

        internal void ClickHomePageSearchButton()
        {
            homePageSerachBtn.ClickButton();
            Wait.Seconds(2);
        }

        internal void SetSearchData(string inputData)
        {
            DictionaryProperties.Details["SearchData"] = inputData;
            searchInput.InputKey(inputData);
            searchDetails.UntilElementIsDisplayed(new TimeSpan(0, 0, 15));
        }

        internal void IsSearchedDetailsVerified(string value)
        {
            Assert.True(searchDetails.GetElements().Count > 0, "There was no result on list");
            foreach (var ele in searchDetails.GetElements())
            {
                Assert.IsTrue(ele.Text.ToUpper().Contains(value.ToUpper()), "Searched details has wrong value.");
            }
        }

        internal void SelectProductFromSearchDetails(string artwork, string product)
        {
            ElementLocatorExtensions.GetElementXpath(selectProduct, artwork, product).ClickButton();
        }

        internal void VerifyDeailsOnProductModal(string artwork, string product)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(artworkName.GetElementValue(), artwork.ToUpper(), "Artwork name is not as expected.");
                Assert.AreEqual(productName.GetElementValue(), product.ToUpper(), "Product name is not as expected.");
            });
        }

        internal void SetTheQuantity(string quantity)
        {
            if (!quantityProduct.GetElementValue().Equals(quantity))
            {
                plusButton.ClickButton();
                SetTheQuantity(quantity);
            }
        }

        internal void PreviewProductModalImages()
        {
            for (int i = 1; i <= slideImages.GetElements().Count; i++)
            {
                rightArrow.ClickButton();
                Wait.Seconds(1);
                continue;
            }
        }
    }
}