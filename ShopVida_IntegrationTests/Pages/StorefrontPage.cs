namespace ShopVidaTests.Pages
{
    using FrameworkTests.Utilities;
    using FrameworkTests.Utilities.Enums;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Utilities.Objects;
    using System;

    public partial class StorefrontPage : SeleniumReporter
    {
        public StorefrontPage(RemoteWebDriver driver, AppSettings appSettings)
        : base(appSettings) { }

        internal void ClickLink(string linkName)
        {
            ElementLocatorExtensions.GetElementXpath(commonHeaderDialogueBox, linkName).ClickButton();
            Wait.Seconds(2);
        }

        internal void SelectPurchaseAmount(string amount)
        {
            if(DictionaryProperties.Details["ScenarioName"].Contains(_appSettings.ScenarioName.StorefrontUpgradeBtn))
            {
                planAmount.SelectElementFromLooping(amount).HoverOverElement();
            }
            else
            {
                planAmount.SelectElementFromLooping(amount).ClickButton();
                DictionaryProperties.Details["Amount"] = amount;
            }
            Wait.Seconds(1);
        }

        internal void IsPurchaseAmountSelected()
        {
            Assert.IsTrue(planAmount.SelectElementFromLooping(DictionaryProperties.Details["Amount"]).GetElementValueByAttribute("class").Contains("is-selected"));
        }

        internal void VerifyTotalPurchaseCost() 
        {
            var PriceToBeCompared = double.Parse(DictionaryProperties.Details["Amount"].Replace("$", "")) * double.Parse(activeAmountMonth.GetElementValue().Substring(0, 2));
            Assert.AreEqual(string.Format("{0:0.00}", Convert.ToDouble(PriceToBeCompared)), totalValue.GetElementValue().Replace("$", ""), "Total is not as expected.");
        }

        internal void SetPaymentDataWithValidations(StorefrontData storefront)
        {
            //paymentMethod.ClickButton();
            //paymentMethodList.ClickButton();
            Browser.SwitchToFrame(iFrame.GetElement());
            cardNumber.InputKey(storefront.InvalidCardNumber);
            Browser.SwitchToDefaultContent();
            Assert.AreEqual(ErrorMessages.InvalidCardNum, paymentsError.GetElementValue());
            Driver.SwitchTo().Frame(iFrame.GetElement());
            cardNumber.InputKey(storefront.ValidCardNumber);
            Driver.SwitchTo().DefaultContent();
            if (DictionaryProperties.Details["ScenarioName"].Contains(_appSettings.ScenarioName.PromoteDesign))
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Next").ClickButton();
            }
            else
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Add Card").ClickButton();
            }
            Assert.AreEqual(ErrorMessages.RequiredExpError, paymentsError.GetElementValue());
            Driver.SwitchTo().Frame(iFrame.GetElement());
            expires.InputKey(storefront.InvalidExpires);
            Driver.SwitchTo().DefaultContent();
            Assert.AreEqual(ErrorMessages.InvaidExp, paymentsError.GetElementValue());
            Driver.SwitchTo().Frame(iFrame.GetElement());
            expires.InputKey(storefront.ValidExpires);
            CVC.InputKey(storefront.InvalidCVC);
            Driver.SwitchTo().DefaultContent();
            if (DictionaryProperties.Details["ScenarioName"].Contains(_appSettings.ScenarioName.PromoteDesign))
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Next").ClickButton();
            }
            else
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Add Card").ClickButton();
            }
            Assert.AreEqual(ErrorMessages.RequiredCVC, paymentsError.GetElementValue());
            Driver.SwitchTo().Frame(iFrame.GetElement());
            CVC.InputKey(storefront.ValidCVC);
            Driver.SwitchTo().DefaultContent();
            if (DictionaryProperties.Details["ScenarioName"].Contains(_appSettings.ScenarioName.PromoteDesign))
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Next").ClickButton();
            }
            else
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, "Add Card").ClickButton();
            }
            Assert.AreEqual(ErrorMessages.RequiredPostal, paymentsError.GetElementValue());
        }
    }
}