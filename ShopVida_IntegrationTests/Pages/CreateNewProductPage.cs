namespace VidaDesignStudioTests.Pages
{
    using FrameworkTests.Pages;
    using FrameworkTests.Utilities;
    using FrameworkTests.Utilities.Enums;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Utilities.Enums;
    using System;
    using System.Collections.Generic;

    public partial class CreateNewProductPage : SeleniumReporter
    {
        public CreateNewProductPage(RemoteWebDriver driver, AppSettings appSettings)
        : base(appSettings) { }

        private IList<string> name1 = new List<string>();

        internal void SelectProductToCreate(string category, string subcategory)
        {
            ElementLocatorExtensions.GetElementXpath(getCategoryAndSubCategory, category, subcategory).ClickButton();
            Wait.Seconds(2);
        }

        internal void SubCategoryPageTitle(string pageTitle)
        {
            productSubCatText.UntilElementIsDisplayed(new TimeSpan(0, 0, 30));
            Assert.IsTrue(productSubCatText.GetElementValue().Contains(pageTitle), "Sub category page title is not as expected.");
        }

        internal void VerifyPageTitle(string expectedTitle)
        {
            if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                sideBarHeaderMobileView.UntilElementIsDisplayed(new TimeSpan(0, 0, 30));
                Assert.IsTrue(sideBarHeaderMobileView.GetElementValue().Contains(expectedTitle), "Side bar header is not as expected.");
            }
            else
            {
                sideBarHeader.UntilElementIsDisplayed(new TimeSpan(0, 0, 30));
                Assert.IsTrue(sideBarHeader.GetElementValue().Contains(expectedTitle), "Side bar header is not as expected.");
            }
        }

        internal void SelectSubCategoryType(string subCategoryType)
        {
            DictionaryProperties.Details["SubCategoryType"] = subCategoryType;
            ElementLocatorExtensions.GetElementXpath(selectSubCatagotyTitle, subCategoryType).ClickButton();
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.LoadingBar();
        }

        internal void ClickProductInfo()
        {
            if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                productInfo.Click();
                Wait.Seconds(1);
            }
        }

        internal void VerifySubCatTypeText(string subcategory)
        {
            if (!DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                Assert.AreEqual(modalHeader.GetElementValue(), subcategory, "Sub category type text is not as expected.");
            }
            else
            {
                Assert.AreEqual(modalHeaderMobileView.GetElementValue(), subcategory, "Sub category type text is not as expected.");
            }
        }

        internal void IsActiveNavigationTextCorrect(string stepName, string stepNameMobileView)
        {
            activeNavigationText.UntilElementIsDisplayed(new TimeSpan(0, 0, 120));
            if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                Assert.IsTrue(activeNavigationText.GetElementValue().Contains(stepNameMobileView), "Active navigation tab text is not as expected.");
            }
            else
            {
                Assert.IsTrue(activeNavigationText.GetElementValue().Contains(stepName), "Active navigation tab text is not as expected.");
            }
        }

        internal void IsProductTitleDisplayed(string productTitle)
        {
            Assert.IsTrue(ElementLocatorExtensions.GetElementXpath(productTypeTitle, productTitle).IsDisplayed(), "Product title is not displayed.");
        }

        internal void ClickBackLink(string iconName)
        {
            Assert.IsTrue(backIcon.GetElementValue().Equals(iconName), "Back icon name is not as expected.");
            backIcon.ClickButton();
            Wait.Seconds(1);
        }

        internal void ClickArtworkEditButton(string editBtn)
        {
            ElementLocatorExtensions.GetElementXpath(editButton, editBtn).ClickButton();
            Wait.Seconds(1);
        }

        internal void SelectArtwork(string artworkName)
        {
            selectArtwork.SelectElementFromLooping(artworkName).ClickButton();
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.LoadingBar();
            if (productTextCheckBox.IsDisplayed())
            {
                productTextCheckBox.ClickButton();
                Wait.Seconds(1);
            }
            if (termsOfService.IsDisplayed())
            {
                termsOfService.ClickButton();
                Wait.Seconds(1);
            }
        }

        internal void VerifySuccessText()
        {
            var DataToBeCompared = Contents.ProductLivePart1 + " " + DictionaryProperties.Details["SubCategoryType"] + " " + Contents.ProductLivePart2;
            Assert.AreEqual(successText.GetElementValue(), DataToBeCompared, "Seccess text is not as expected.");
        }

        internal void IsProductCardDisplayed(string artwork, string subcategory)
        {
            ElementLocatorExtensions.GetElementXpath(productCard, artwork, subcategory).UntilElementIsDisplayed(new TimeSpan(0, 0, 60));
            Assert.IsTrue(ElementLocatorExtensions.GetElementXpath(productCard, artwork, subcategory).IsDisplayed(), "Product card is not displayed.");
        }

        internal void IsProductCardNotDisplayed(string artwork, string subcategory)
        {
            Wait.Seconds(5);
            Assert.IsFalse(ElementLocatorExtensions.GetElementXpath(productCard, artwork, subcategory).IsDisplayed(), "Product card is displayed.");
            if (DictionaryProperties.Details["ScenarioName"].Equals(_appSettings.ScenarioName.AddProductInBag))
            {
                Browser.RefreshPage();
                Wait.Seconds(1);
            }

            Browser.RefreshPage();
        }

        internal void ClickMoreOptionIcon()
        {
            moreOptionLogo.HoverOverElement();
            moreOptionLogo.Click();
            Wait.Seconds(1);
        }

        internal void SelectAction(string action)
        {
            moreActions.SelectElementFromLooping(action).ClickButton();
            Wait.Seconds(2);
        }

        internal void InputNameDesign(string designName)
        {
            DictionaryProperties.Details["DesignName"] = designName;
            if (inputDesignName.IsDisplayed())
            {
                inputDesignName.InputKey(designName);
                Wait.Seconds(1);
            }
        }

        internal void IsArtworkUploaded()
        {
            Wait.Seconds(3);
            Assert.IsTrue(selectArtwork.SelectElementFromLooping(DictionaryProperties.Details["DesignName"]).Displayed);
        }

        internal void SelectDropdownOptions(string menu, string submenu)
        {
            if (submenu.Contains(" "))
            {
                DictionaryProperties.Details["SelectedTag"] = submenu.ToUpper().Replace(" ", "_");
            }
            else if (submenu.Contains("-"))
            {
                DictionaryProperties.Details["SelectedTag"] = submenu.ToUpper().Replace("-", "_");
            }
            else
            {
                DictionaryProperties.Details["SelectedTag"] = submenu.ToUpper();
            }
            if (ElementLocatorExtensions.GetElementXpath(subHeadCloseBtn, DictionaryProperties.Details["SelectedTag"]).IsDisplayed())
            {
                ElementLocatorExtensions.GetElementXpath(subHeadCloseBtn, DictionaryProperties.Details["SelectedTag"]).ClickButton();
                Wait.Seconds(1);
            }
            ElementLocatorExtensions.GetElementXpath(dropdownMenu, menu).ClickButton();
            ElementLocatorExtensions.GetElementXpath(dropdownSubMenu, menu, submenu).ClickButton();
        }

        internal void IsSubHeadTagVerified()
        {
            Assert.AreEqual(ElementLocatorExtensions.GetElementXpath(subHeadTag, DictionaryProperties.Details["SelectedTag"]).GetElementValue(), DictionaryProperties.Details["SelectedTag"], "Subhead tag text is not as expected.");
        }

        internal void SelectProductTypeTitle(string productType)
        {
            var subcatagoryCount1 = ElementLocatorExtensions.GetElementXpath(productSubType, productType).GetElements();
            foreach (var item in subcatagoryCount1)
            {
                var text = ((RemoteWebElement)item).Text;
                name1.Add(text);
            }
            ElementLocatorExtensions.GetElementXpath(productTypeTitle, productType).ClickButton();
            Wait.Seconds(1);

            IList<string> name2 = new List<string>();
            var subcatagoryCount2 = subcatageryType.GetElements();
            foreach (var item in subcatagoryCount2)
            {
                if (!string.IsNullOrEmpty(item.Text))
                {
                    var text2 = ((RemoteWebElement)item).Text.Replace("\r\n", "").Remove(item.Text.Replace("\r\n", "").Length - 1);
                    name2.Add(text2);
                }
            }
            for (int i = 0; i <= 3; i++)
            {
                Assert.IsTrue(name2[i].Contains(name1[i]), "Product category elements are not as expected.");
            }
        }

        internal void IsFooterMenuActive(string footermenu)
        {
            Assert.IsTrue(footerMenuActive.GetElementValue().Contains(footermenu), "Footer menu tab is not active.");
        }

        internal void ProcuctCatActiveTab(string tabName)
        {
            loader.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 120));
            Assert.IsTrue(productCatActiveTab.GetElementValue().Contains(tabName), "Active product catagory tab on launch page is not as expected.");
        }

        internal void ClickSubCatImage(string subCatImage)
        {
            DictionaryProperties.Details["SubCategoryType"] = subCatImage;
            if (!ElementLocatorExtensions.GetElementXpath(subCatImg, subCatImage).IsDisplayed())
            {
                rightArrow.Click();
            }
            ElementLocatorExtensions.GetElementXpath(subCatImg, subCatImage).Click();
            Wait.Seconds(3);
        }

        internal void ClickFooterMenu(string footerName)
        {
            footerMenu.SelectElementFromLooping(footerName).ClickButton();
            Wait.Seconds(1);
        }

        internal void ClickProductCatTab(string tabName)
        {
            productCategoryTab.SelectElementFromLooping(tabName).ClickButton();
            Wait.Seconds(1);
        }

        internal void MoveSlider(string parameter)
        {
            DictionaryProperties.Details["SliderParam"] = parameter;
            Driver.ExecuteScript("arguments[0].setAttribute('style',  'left:" + parameter + "' )", sliderHandle.GetElement());
            sliderHandle.Click();
        }

        internal void IsSliderWorked()
        {
            var getAttribute = sliderHandle.GetElementValueByAttribute("style");
            var sliderToBeMatched = getAttribute.Substring(6).Replace("%;", "");
            var sliderToBeMatchedActual = Math.Round(double.Parse(sliderToBeMatched), 0, MidpointRounding.AwayFromZero);
            Assert.AreEqual(sliderToBeMatchedActual + "%", DictionaryProperties.Details["SliderParam"], "Product edit slider is not worked properly.");
        }

        internal void ListSelectionOption(string option)
        {
            loader.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 120));
            listSelectionOption.SelectElementFromLooping(option).ScrollDown();
            listSelectionOption.SelectElementFromLooping(option).ClickButton();
        }

        internal void IsProductsCheckBoxesUnchecked()
        {
            foreach (IWebElement checkbox in productCheckbox.GetElements())
            {
                Assert.IsFalse(checkbox.GetElementValueByAttribute("class").Contains("checkbox-checked"), "Checkboxes are not unchecked.");
            }
        }

        internal void IsProductsCheckBoxesChecked()
        {
            foreach (IWebElement checkbox in productCheckbox.GetElements())
            {
                Assert.IsTrue(checkbox.GetElementValueByAttribute("class").Contains("checkbox-checked"), "Checkboxes are not checked.");
            }
        }

        internal void IsLaunchProductsButtonDisabled()
        {
            Assert.IsFalse(launchProductBtn.IsEnabled(), "LAUNCH PRODUCTS button is not disabled.");
        }

        internal void IsLaunchProductsButtonEnabled()
        {
            Assert.IsTrue(launchProductBtn.IsEnabled(), "LAUNCH PRODUCTS button is not disabled.");
        }

        internal void VerifyTranspaentBadgeCount(string productName)
        {
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.LaunchPageLoader();
            if (ElementLocatorExtensions.GetElementXpath(badgeCount, productName).IsDisplayed())
            {
                Assert.AreEqual(ElementLocatorExtensions.GetElementXpath(badgeCount, productName).GetElementValue(), productCheckbox.GetElements().Count.ToString(), "Batch count is not as expected.");
            }
        }

        internal void ClickAndUploadPhotos(string action)
        {
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.GenerateImage();
            ElementLocatorExtensions.GetElementXpath(commonButton, action).Click();
            Wait.Seconds(2);
            commonPage.UploadPhoto();
        }

        internal void IsUploadedArtwokDisplayed()
        {
            Assert.IsTrue(designCardTitle.SelectElementFromLooping(DictionaryProperties.Details["DesignName"]).Displayed, "Uploaded artwork is not displayed in gallery page.");
        }

        internal void SelectTheUploadedArtwork()
        {
            designCardTitle.SelectElementFromLooping(DictionaryProperties.Details["DesignName"]).ClickButton();
        }

        internal void VerifyAndClickDeleteIcon()
        {
            Assert.IsTrue(deleteIcon.IsDisplayed(), "Delete icon is not displayed");
            deleteIcon.ClickButton();
            Wait.Seconds(3);
        }

        internal void IsSelectedArtworkDeleted()
        {
            if (designCardTitle.GetElements().Count == 1)
            {
                Assert.IsFalse(designCardTitle.GetElementValue().Equals(DictionaryProperties.Details["DesignName"]), "Uploaded artwork is not deleted.");
            }
            else
            {
                Assert.IsFalse(designCardTitle.SelectElementFromLooping(DictionaryProperties.Details["DesignName"]).Displayed, "Uploaded artwork is not deleted.");
            }
        }

        internal void SelectHomePageTab(string tabName)
        {
            foreach (IWebElement tab in homePageTabName.GetElements())
            {
                if (tab.GetElementValueByAttribute("href").Contains(tabName))
                {
                    tab.Click();
                    break;
                }
            }
        }

        internal void IfArtworkUploadedThenDelete(string action)
        {
            SelectHomePageTab("gallery");
            Wait.Seconds(3);
            foreach (IWebElement tab in designCardTitle.GetElements())
            {
                if (tab.Text.Contains(action))
                {
                    designCardTitle.SelectElementFromLooping(action).ClickButton();
                    Wait.Seconds(3);
                    ElementLocatorExtensions.GetElementXpath(commonButton, "Edit").Click();
                    deleteIcon.ClickButton();
                    break;
                }
            }
        }

        internal void SetProductPrice(string price)
        {
            if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                setPriceInputMobileView.InputKey(price);
                Wait.Seconds(1);
                closeIconPopup.ClickButton();
            }
            else
            {
                setPriceInput.InputKey(price);
                Wait.Seconds(1);
            }
        }

        internal void PreviewImages()
        {
            for (int i = 0; i <= 3; i++)
            {
                previewLoader.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 80));
                ElementLocatorExtensions.GetElementXpath(commonButton, "Design").ClickButton();
                selectArtwork.SelectElementFromLooping("Artwork1").ClickButton();
                ElementLocatorExtensions.GetElementXpath(commonButton, "Preview").ClickButton();
                previewLoader.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 80));
                if (previewItems.IsDisplayed())
                {
                    foreach (IWebElement card in previewItems.GetElements())
                    {
                        card.ClickButton();
                        Wait.Seconds(1);
                    }
                    break;
                }
                continue;
            }
            if (!previewItems.IsDisplayed())
            {
                Assert.Fail("Preview items are not displayed.");
            }
        }

        internal void AddAProductOnHomePage(string category, string productType, string subCategory)
        {
            addProductCard.ClickButton();
            Wait.Seconds(3);
            ElementLocatorExtensions.GetElementXpath(getCategoryAndSubCategory, category, productType).ClickButton();
            productSubCatText.UntilElementIsDisplayed(new TimeSpan(0, 0, 60));
            ElementLocatorExtensions.GetElementXpath(selectSubCatagotyTitle, subCategory).ClickButton();
            ElementLocatorExtensions.GetElementXpath(commonButton, "Upload Artwork").UntilElementIsDisplayed(new TimeSpan(0, 0, 15));
            if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Choose From Gallery").ClickButton();
                Wait.Seconds(2);
            }
            selectArtwork.SelectElementFromLooping("Artwork1").ClickButton();
            ElementLocatorExtensions.GetElementXpath(commonButton, "Launch Product").UntilElementIsEnabled(new TimeSpan(0, 0, 15));
            ElementLocatorExtensions.GetElementXpath(commonButton, "Launch Product").ClickButton();
            successText.UntilElementIsDisplayed(new TimeSpan(0, 0, 120));
            Wait.Seconds(3);
            closeIcon.Click();
            Wait.Seconds(1);
        }

        internal void ClickAction(SubCategoryType subCategoryType)
        {
            ElementLocatorExtensions.GetElementXpath(productTypeTitle, "bags").ClickButton();
            Wait.Seconds(1);
            this.GetActionButton(subCategoryType).Click();
        }
    }
}