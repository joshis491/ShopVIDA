namespace ShopVidaTests.Pages
{
    using FrameworkTests.Utilities.Enums;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Utilities.Objects;
    using System;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class ShoppingBagPage : SeleniumReporter
    {
        public ShoppingBagPage(RemoteWebDriver driver, AppSettings appSettings)
            : base(appSettings) { }

        internal void CartHeadingDisplayed(string headingName)
        {
            Assert.AreEqual(cartName.GetElementValue(), headingName, "Bag is not empty.");
        }

        internal void ClickCloseButton()
        {
            closeBtn.ClickButton();
        }

        internal void IsProductAdded()
        {
            if (giftBoxQuantity.IsDisplayed())
            {
                ClickGiftBoxMinusBtn();
            }
            if (cartName.IsDisplayed())
            {
                closeBtn.Click();
                ElementLocatorExtensions.GetElementXpath(selectMenu, "Create New Product").ClickButton();
                Wait.Seconds(3);
                ElementLocatorExtensions.GetElementXpath(getCategoryAndSubCategory, "bags", "Handbags").ClickButton();
                productSubCatText.UntilElementIsDisplayed(new TimeSpan(0, 0, 60));
                ElementLocatorExtensions.GetElementXpath(selectSubCatagotyTitle, "Tote Bag").ClickButton();
                ElementLocatorExtensions.GetElementXpath(commonButton, "Upload Artwork").UntilElementIsDisplayed(new TimeSpan(0, 0, 15));
                if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
                {
                    ElementLocatorExtensions.GetElementXpath(commonButton, "Choose From Gallery").ClickButton();
                    Wait.Seconds(2);
                }
                selectArtwork.SelectElementFromLooping("Artwork(1)").ClickButton();
                ElementLocatorExtensions.GetElementXpath(commonButton, "Launch Product").UntilElementIsEnabled(new TimeSpan(0, 0, 15));
                ElementLocatorExtensions.GetElementXpath(commonButton, "Launch Product").ClickButton();
                successText.UntilElementIsDisplayed(new TimeSpan(0, 0, 20));
                ElementLocatorExtensions.GetElementXpath(commonButton, "Skip").ClickButton();
                plusButton.UntilElementIsDisplayed(new TimeSpan(0, 0, 60));
                Wait.Seconds(3);
            }
        }

        internal void IfProductAddedThenDelete()
        {
            Wait.Seconds(3);
            if (giftBoxQuantity.IsDisplayed())
            {
                ClickGiftBoxMinusBtn();
            }
            if (!cartName.IsDisplayed())
            {
                ClickRemoveSamplesBtn();
            }
        }

        internal void ClickRemoveSamplesBtn()
        {
            if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
            {
                if (removeSampleBtnMobileView.IsDisplayed())
                {
                    removeSampleBtnMobileView.ClickButton();
                    Wait.Seconds(1);
                }
            }
            else
            {
                if (removeSampleBtn.IsDisplayed())
                {
                    removeSampleBtn.ClickButton();
                    Wait.Seconds(1);
                }
            }
            Wait.Seconds(1);
        }

        internal void ClickProductMinusBtn()
        {
            if (productsList.GetElements().Count > 1)
            {
                int row = 0;
                for (int i = 0; productsList.GetElements().Count > 1; i++)
                {
                    if (!productsList.FindElements(productQuantity.GetElement())[row].Text.Equals(0))
                    {
                        minusButton.ClickButton();
                        Wait.Seconds(2);
                        continue;
                    }
                }
                if (productsList.GetElements().Count.Equals(1))
                {
                    RemoveProduct();
                }
            }
            else
            {
                RemoveProduct();
            }
        }

        internal void ClickProductPlusBtn()
        {
            if (giftBoxQuantity.IsDisplayed())
            {
                ClickGiftBoxMinusBtn();
            }
            if (productsList.GetElements().Count > 1)
            {
                int index = 0;
                foreach (IWebElement ele in productsList.GetElements())
                {
                    DictionaryProperties.Details["ProductCountBefore"] = ele.FindElements(productQuantity)[index].Text;
                    ele.FindElements(plusButton)[index].ClickButton();
                    Wait.Seconds(2);
                    Assert.AreNotEqual(ele.FindElements(productQuantity)[index].Text, DictionaryProperties.Details["ProductCountBefore"], "Product quantity is not updated.");
                    index++;
                }
            }
            else
            {
                DictionaryProperties.Details["ProductCountBefore"] = productQuantity.GetElementValue();
                plusButton.ClickButton();
                Wait.Seconds(2);
                Assert.AreNotEqual(productQuantity.GetElementValue(), DictionaryProperties.Details["ProductCountBefore"], "Product quantity is not updated.");
            }
        }

        internal void RemoveProduct()
        {
            for (int i = 0; productsList.GetElements().Count.Equals(1); i++)
            {
                if (!productQuantity.GetElementValue().Equals(0))
                {
                    minusButton.ClickButton();
                    Wait.Seconds(2);
                    continue;
                }
            }
        }

        internal void IsGiftBoxIsUpdated()
        {
            Assert.AreNotEqual(giftBoxQuantity.GetElementValue(), DictionaryProperties.Details["GiftBoxCountBefore"], "Gift Box quantity is not updated.");
        }

        internal void IsGiftBoxIsRemoved()
        {
            Assert.IsFalse(giftBoxQuantity.IsDisplayed(), "Gift Box is not removed.");
        }

        internal void ClickGiftBoxMinusBtn()
        {
            for (int i = 0; giftBoxQuantity.IsDisplayed(); i++)
            {
                if (!giftBoxQuantity.GetElementValue().Equals(0))
                {
                    giftBoxMinusBtn.ClickButton();
                    Wait.Seconds(2);
                    continue;
                }
            }
        }

        internal void ClickGiftBoxPlusBtn()
        {
            giftBoxPlusBtn.ClickButton();
            Wait.Seconds(2);
        }

        internal void VerifyTotalCheckoutCost()
        {
            if (productsList.GetElements().Count > 1)
            {
                double TotalRetailPrice = 0;
                double TotalDiscountedPrice = 0;
                int index = 0;
                foreach (IWebElement ele in productsList.GetElements())
                {
                    double retail = double.Parse(ele.FindElements(retailPrice)[index].Text.Replace("$", "").Substring(13));
                    double quantity = double.Parse(ele.FindElements(productQuantity)[index].Text);
                    TotalRetailPrice = TotalRetailPrice + (retail * quantity);
                    if (DictionaryProperties.Details["ScenarioName"].Contains("mobile view"))
                    {
                        double discount = double.Parse(ele.FindElements(discountPriceMobileView)[index].Text.Replace("$", ""));
                        TotalDiscountedPrice = TotalDiscountedPrice + (discount * quantity);
                    }
                    else
                    {
                        double discount = double.Parse(ele.FindElements(discountPrice)[index].Text.Replace("$", ""));
                        TotalDiscountedPrice = TotalDiscountedPrice + (discount * quantity);
                    }
                    index++;
                }
                VerifyCosts(TotalRetailPrice, TotalDiscountedPrice);
            }
            else
            {
                var TotalRetailPrice = double.Parse(retailPrice.GetElementValue().Substring(13).Replace("$", "")) * double.Parse(productQuantity.GetElementValue());
                var TotalDiscountPrice = double.Parse(discountPrice.GetElementValue().Replace("$", "")) * double.Parse(productQuantity.GetElementValue());
                VerifyCosts(TotalRetailPrice, TotalDiscountPrice);
            }
        }

        internal void VerifyCosts(double totalRetail, double totalDiscount)
        {
            var TotalSaving = string.Format("{0:0}", Convert.ToDouble(totalRetail - totalDiscount));
            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Format("{0:0}", Convert.ToDouble(totalRetail)), string.Format("{0:0}", Convert.ToDouble(msrpTotal.GetElementValue().Replace("$", ""))), "MSRP total is not as expected.");
                Assert.AreEqual(string.Format("{0:0}", Convert.ToDouble(TotalSaving)), string.Format("{0:0}", Convert.ToDouble(totalSaving.GetElementValue().Replace("$", ""))), "Total wholesale savings is not as expected.");
                Assert.AreEqual(string.Format("{0:0}", Convert.ToDouble(totalDiscount)), string.Format("{0:0}", Convert.ToDouble(totalCost.GetElementValue().Replace("$", ""))), "Total is not as expected.");
            });
        }

        internal void RemoveProductFromHomePage(string artwork, string subcategory)
        {
            var getProductCard = ElementLocatorExtensions.GetElementXpath(productCard, artwork, subcategory);
            if(!getProductCard.GetElements().Count.Equals(0))
            {
                if (getProductCard.GetElements().Count > 1)
                {
                    int index = 0;
                    foreach (IWebElement card in getProductCard.GetElements())
                    {
                        card.FindElements(moreOptionLogo)[index].HoverOverElement();
                        card.FindElements(moreOptionLogo)[index].ClickButton();
                        Wait.Seconds(1);
                        card.FindElements(cardRemoveOption)[index].ClickButton();
                        Wait.Seconds(6);
                    }
                }
                else
                {
                    moreOptionLogo.HoverOverElement();
                    moreOptionLogo.Click();
                    Wait.Seconds(1);
                    moreActions.SelectElementFromLooping("Remove").ClickButton();
                    Wait.Seconds(2);
                    successMessage.UntilElementIsDisplayed(new TimeSpan(0, 0, 5));
                    Assert.AreEqual(successMessage.GetElementValue(), ToastMessage.productRemoved, "Product is not removed successfully.");
                }
            }
        }

        internal void PromoteProduct(string artwork, string subcategory)
        {
            var productCard = ElementLocatorExtensions.GetElementXpath(productCardDetails, artwork, subcategory);
            int index = 0;
            foreach (IWebElement card in productCard.GetElements())
            {
                card.FindElements(promoteProduct)[index].ClickButton();
            }
        }

        internal void VerifyErrorMessageCheckout(Table dataToAdd)
        {
            ShoppingBag bag = dataToAdd.CreateInstance<ShoppingBag>();
            logOut.ClickButton();
            Wait.Seconds(2);
            checkoutEmail.ClearData();
            checkoutFirstName.BlankValue();
            checkoutLastName.BlankValue();
            checkoutCountry.DropDownSelectionByText(bag.Country);
            ElementLocatorExtensions.GetElementXpath(checkoutsBtn, "Continue to shipping").ClickButton();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(checkoutEmailError.GetElementValue(), ErrorMessages.CheckoutEmailError, "Checkout email error is not as expected.");
                Assert.AreEqual(checkoutFirstNameError.GetElementValue(), ErrorMessages.CheckoutFirstNameError, "Checkout first name error is not as expected.");
                Assert.AreEqual(checkoutLastNameError.GetElementValue(), ErrorMessages.CheckoutLastNameError, "Checkout last name error is not as expected.");
                Assert.AreEqual(checkoutAddressError.GetElementValue(), ErrorMessages.CheckoutAddressError, "Checkout address error is not as expected.");
                Assert.AreEqual(checkoutCityError.GetElementValue(), ErrorMessages.CheckoutCityError, "Checkout email city is not as expected.");
                Assert.AreEqual(checkoutStateError.GetElementValue(), ErrorMessages.CheckoutStateError, "Checkout email state is not as expected.");
                Assert.AreEqual(checkoutZipCodeError.GetElementValue(), ErrorMessages.CheckoutZipCodeError, "Checkout zip code error is not as expected.");
            });
            if (orderSummaryToggle.IsDisplayed())
            {
                orderSummaryToggle.Click();
                Wait.Seconds(1);
            }
            checkoutGiftCardInput.InputKey(bag.GiftCardCode);
            discountBtn.ClickButton();
            Assert.AreEqual(giftCardCodeError.GetElementValue(), ErrorMessages.GiftCardCodeError, "Checkout gift card code error is not as expected.");
        }

        internal void FillCheckoutInformationStep(ShoppingBag bag)
        {
            checkoutFirstName.InputKey(bag.FirstName);
            checkoutLastName.InputKey(bag.LastName);
            checkoutAddress1.InputKey(bag.Address);
            autocompleteAddress.UntilElementIsDisplayed(new TimeSpan(0, 0, 10));
            autocompleteAddress.SelectElementFromLooping(bag.AddressToBeSelected).ClickAndHold();
            Wait.Seconds(1);
            checkoutPhoneNumber.InputKey(bag.PhoneNumber);
        }

        internal void VerifyPaymentPageLink(string pageName)
        {
            //currentActiveHeader.UntilElementIsDisplayed(new TimeSpan(0, 0, 30);
            Assert.IsTrue(Driver.Url.Contains(pageName), "Url is not as expected.");
        }

        internal void SelectShippingMethod(string shippingMethod)
        {
            DictionaryProperties.Details["ShippingMethod"] = shippingMethod;
            shippingMethodRadio.SelectElementFromLooping(shippingMethod).ClickButton();
        }

        internal void IsCurrentPaymentTabActive(string activeTab)
        {
            Assert.AreEqual(currentActiveHeader.GetElementValue(), activeTab, "Payment active tab text is not as expected.");
        }

        internal void PaymentHaederTabClick(string tabName)
        {
            paymentHaeder.SelectElementFromLooping(tabName).Click();
            Wait.Seconds(2);
            currentActiveHeader.UntilElementIsDisplayed(new TimeSpan(0, 0, 30));
        }

        internal void SelectChangeButton(string buttonName, string stepName)
        {
            if (stepName.Equals("shipping"))
            {
                DictionaryProperties.Details["contactBefore"] = ElementLocatorExtensions.GetElementXpath(changeContent, "Change contact information").GetElementValue();
                DictionaryProperties.Details["shippingAddressBrefore"] = ElementLocatorExtensions.GetElementXpath(changeContent, "Change shipping address").GetElementValue();
            }
            else if (stepName.Equals("payment"))
            {
                DictionaryProperties.Details["contactBefore"] = ElementLocatorExtensions.GetElementXpath(changeContent, "Change contact information").GetElementValue();
                DictionaryProperties.Details["shippingAddressBrefore"] = ElementLocatorExtensions.GetElementXpath(changeContent, "Change shipping address").GetElementValue();
                DictionaryProperties.Details["shippinhgMethodBefore"] = ElementLocatorExtensions.GetElementXpath(changeContent, "Change shipping method").GetElementValue();
            }
            ElementLocatorExtensions.GetElementXpath(editPaymentStep, buttonName).ClickButton();
            Wait.Seconds(2);
            currentActiveHeader.UntilElementIsDisplayed(new TimeSpan(0, 0, 15));
        }

        internal void FillCheckoutInfoData(ShoppingBag bag, string action)
        {
            if (action.Equals("Contact Info"))
            {
                logOut.ClickButton();
                Wait.Seconds(2);
                checkoutEmail.InputKey(bag.Email);
                DictionaryProperties.Details["Email"] = bag.Email;
            }
            else if (action.Equals("Shipping address"))
            {
                checkoutAddress1.InputKey(bag.AddressEdit);
                autocompleteAddress.UntilElementIsDisplayed(new TimeSpan(0, 0, 30));
                autocompleteAddress.SelectElementFromLooping(bag.AddressToBeSelectedEdit).ClickAndHold();
                Wait.Seconds(1);
                checkoutEmail.Click();
                DictionaryProperties.Details["Address"] = checkoutAddress1.GetElementValueByAttribute("value");
                DictionaryProperties.Details["City"] = checkoutCity.GetElementValueByAttribute("value");
                DictionaryProperties.Details["PinCode"] = checkoutZipCode.GetElementValueByAttribute("value");
            }
        }

        internal void IsDataUpdatedForShippingStep(string action)
        {
            var valueToBeCompared = ElementLocatorExtensions.GetElementXpath(changeContent, action).GetElementValue();
            if (action.Equals("Change contact information"))
            {
                Assert.Multiple(() =>
                {
                    Assert.AreNotEqual(valueToBeCompared, DictionaryProperties.Details["contactBefore"]);
                    Assert.AreEqual(valueToBeCompared, DictionaryProperties.Details["Email"], "Contact info is not updated.");
                });
            }
            else if (action.Equals("Change shipping address"))
            {
                Assert.Multiple(() =>
                {
                    Assert.IsTrue(valueToBeCompared.Contains(DictionaryProperties.Details["Address"]), "Checkout address is not as expected.");
                    Assert.IsTrue(valueToBeCompared.Contains(DictionaryProperties.Details["City"]), "Checkout city name is not as expected.");
                    Assert.IsTrue(valueToBeCompared.Contains(DictionaryProperties.Details["PinCode"]), "Checkout pin code is not as expected.");
                });
            }
            else if (action.Equals("Change shipping method"))
            {
                Assert.IsFalse(valueToBeCompared.Contains(DictionaryProperties.Details["shippinhgMethodBefore"]));
                Assert.IsTrue(valueToBeCompared.Contains(DictionaryProperties.Details["ShippingMethod"]));
            }
        }

        internal void SelectBillingMethod(string option)
        {
            billingAddressRadio.SelectElementFromLooping(option).ClickButton();
            Wait.Seconds(2);
        }

        internal void FillBillingAddress(ShoppingBag bag)
        {
            checkoutBillingAddress1.InputKey(bag.Address);
            autocompleteAddress.UntilElementIsDisplayed(new TimeSpan(0, 0, 10));
            autocompleteAddress.SelectElementFromLooping(bag.AddressToBeSelected).ClickAndHold();
            Wait.Seconds((1));
            billingFirstName.Click();
        }

        internal void IsProductshownInLineItems(string subProduct)
        {
            Assert.IsTrue(lineItems.SelectElementFromLooping(subProduct).Text.Contains(subProduct), "Sample is not available in shopping bag.");
        }

        internal void SelectSizeFromDropDown(string size)
        {
            sizeDropdown.ClickButton();
            Wait.Milliseconds(500);
            dropdownValues.SelectElementFromLooping(size).ClickButton();
            Wait.Seconds(3);
        }

        internal void VerifySizeActiveText(string size)
        {
            Assert.IsTrue(sizeDropdown.GetElementValue().Equals(size), "Active size text is not as expected.");
        }
    }
}