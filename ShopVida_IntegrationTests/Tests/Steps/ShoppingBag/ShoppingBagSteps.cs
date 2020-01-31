namespace ShopVidaTests.Tests.Steps.ShoppingBag
{
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Pages;
    using ShopVidaTests.Utilities.Enums;
    using ShopVidaTests.Utilities.Objects;
    using ShopVidaTests.Utilities.Helpers;
    using TechTalk.SpecFlow;

    [Binding]
	public class ShoppingBagSteps : SeleniumReporter
    {
        private SharedStorage sharedStorage;

        public ShoppingBagSteps(RemoteWebDriver driver, AppSettings appSettings, SharedStorage sharedStorage)
        : base(appSettings)
		{
			Driver = driver;
            this.sharedStorage = sharedStorage;
        }

		[Then(@"Verify ""(.*)"" text should be displayed for shopping bag page")]
		public void ThenVerifyTextShouldBeDisplayedForShoppingBagPage(string headingName)
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.CartHeadingDisplayed(headingName);
		}

		[When(@"There is no product in bag then add a product")]
		public void WhenThereIsNoProductInBagThenAddAProduct()
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.IsProductAdded();
		}

		[When(@"There is any product in bag then delete that")]
		public void WhenThereIsAnyProductInBagThenDeleteThat()
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.IfProductAddedThenDelete();
		}

		[When(@"I click (Product Minus|Remove Samples|Gift Box Minus|close|Gift Box Plus) button")]
		public void WhenIClickMinusButtton(string action)
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			switch (action)
			{
				case "Remove Samples":
					shoppingBag.ClickRemoveSamplesBtn();
					break;

				case "Product Minus":
					shoppingBag.ClickProductMinusBtn();
					break;

				case "Gift Box Minus":
					shoppingBag.ClickGiftBoxMinusBtn();
					break;

				case "Gift Box Plus":
					shoppingBag.ClickGiftBoxPlusBtn();
					break;

				case "close":
					shoppingBag.ClickCloseButton();
					break;
			}
		}

		[Then(@"Verify Gift box quantity should be updated in grid")]
		public void ThenVerifyGiftBoxShouldBeUpdatedInGrid()
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.IsGiftBoxIsUpdated();
		}

		[Then(@"Verify gift card should be removed from grid")]
		public void ThenVerifyGiftCardShouldBeRemovedFromGrid()
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.IsGiftBoxIsRemoved();
		}

		[Then(@"Verify total checkout cost")]
		public void ThenVerifyTotalCheckoutCost()
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.VerifyTotalCheckoutCost();
		}

		[When(@"I click Product Plus button and verify it")]
		public void WhenIClickProductPlusButtonAndVerifyIt()
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.ClickProductPlusBtn();
		}

		[Then(@"Remove the product from home page for ""(.*)"" with ""(.*)"" subcategory")]
		public void ThenRemoveTheProductFromHomePageForWithSubcategory(string artwork, string subcatagory)
		{
			ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
			shoppingBag.RemoveProductFromHomePage(artwork, subcatagory);
        }

        [Then(@"Click on Promote for ""(.*)"" with ""(.*)"" subcategory")]
        public void ThenClickOnPromoteForWithSubcategory(string artwork, string subcatagory)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.PromoteProduct(artwork, subcatagory);
        }

        [Then(@"Verify the validation messages for checkout page:")]
        public void ThenVerifyTheValidationMessagesForCheckoutPage(Table dataToAdd)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.VerifyErrorMessageCheckout(dataToAdd);
        }

        [When(@"I get Shopping Bag Payments data from file ""(.*)""")]
        public void WhenIGetShoppingBagPaymentsDataFromFile(string file)
        {
            string data = DataFiles.ReadJsonDataFile(file);
            ShoppingBag bag = ObjectSerializer.DeserializeToObject<ShoppingBag>(data);
            sharedStorage.SetSharedInfo(ContextTag.ShoppingBagPaymentData, bag);
        }

        [When(@"I fill shopping bag checkout form information step")]
        public void WhenIFillShoppingBagCheckoutFormInformationStep()
        {
            ShoppingBag bag = sharedStorage.GetSharedInfo<ShoppingBag>(ContextTag.ShoppingBagPaymentData);
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.FillCheckoutInformationStep(bag);
        }

        [Then(@"I'm on ""(.*)"" payment page")]
        public void ThenIMOnPaymentPage(string pageName)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.VerifyPaymentPageLink(pageName);
        }

        [When(@"I select ""(.*)"" shipping method")]
        public void WhenISelectShippingMethod(string shippingMethod)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.SelectShippingMethod(shippingMethod);
        }

        [Then(@"Verify current active header tab should be ""(.*)""")]
        public void ThenVerifyCurrentActiveHeaderTabShouldBe(string activeTab)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.IsCurrentPaymentTabActive(activeTab);
        }

        [When(@"I click active header tab ""(.*)""")]
        public void WhenIClickActiveHeaderTab(string tabName)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.PaymentHaederTabClick(tabName);
        }

        [When(@"I click the ""(.*)"" change button for ""(.*)"" step")]
        public void WhenIClickTheChangeButton(string buttonName, string stepName)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.SelectChangeButton(buttonName, stepName);
        }
        [When(@"I fill data for ""(.*)"" in checkout Information step")]
        public void ThenIFillDataForInCheckoutInformationStep(string action)
        {
            ShoppingBag bag = sharedStorage.GetSharedInfo<ShoppingBag>(ContextTag.ShoppingBagPaymentData);
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.FillCheckoutInfoData(bag, action);
        }

        [Then(@"Verify data should be updated for ""(.*)"" in shipping step")]
        public void ThenVerifyDataShouldBeUpdatedForInShippingStep(string action)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.IsDataUpdatedForShippingStep(action);
        }

        [When(@"I select ""(.*)"" billing address")]
        public void WhenISelectBillingAddress(string option)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.SelectBillingMethod(option);
        }

        [When(@"I fill billing address form")]
        public void WhenIFillBillingAddressForm()
        {
            ShoppingBag bag = sharedStorage.GetSharedInfo<ShoppingBag>(ContextTag.ShoppingBagPaymentData);
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.FillBillingAddress(bag);
        }

        [Then(@"Verify ""(.*)"" should be shown in line items")]
        public void ThenVerifyShouldBeShownInLineItems(string subProduct)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.IsProductshownInLineItems(subProduct);
        }

        [Then(@"Select the ""(.*)"" size from dropdown")]
        public void ThenSelectTheSizeFromDropdown(string size)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.SelectSizeFromDropDown(size);
        }

        [Then(@"Verify active dropdown text should be ""(.*)""")]
        public void ThenVerifyActiveDropdownTextShouldBe(string size)
        {
            ShoppingBagPage shoppingBag = new ShoppingBagPage(Driver, _appSettings);
            shoppingBag.VerifySizeActiveText(size);
        }
    }
}