namespace VidaDesignStudioTests.Tests.Steps.CreateNewProduct
{
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Utilities.Enums;
    using TechTalk.SpecFlow;
    using VidaDesignStudioTests.Pages;

    [Binding]
	public class CreateNewProductSteps : SeleniumReporter
	{
		public CreateNewProductSteps(RemoteWebDriver driver, AppSettings appSettings)
		: base(appSettings)
		{
			Driver = driver;
		}

		[When(@"I select ""(.*)"" product category type with ""(.*)"" sub category type")]
		public void WhenISelectCatagoryTypeWithProductSubCategoryType(string category, string subcategory)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectProductToCreate(category, subcategory);
		}

		[When(@"Verify product subcategory page title should be ""(.*)""")]
		public void WhenVerifyProductSubcategoryPageTitleShouldBe(string pageTitle)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SubCategoryPageTitle(pageTitle);
		}

		[When(@"I select ""(.*)"" subcategory type")]
		public void WhenISelectSubcategoryTitle(string title)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectSubCategoryType(title);
        }

        [Then(@"Verify subcategory type below side bar header should be ""(.*)""")]
        public void ThenVerifySubcategoryTypeBelowSideBarHeaderShouldBe(string subcategory)
        {
            CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
            createNewProduct.VerifySubCatTypeText(subcategory);
        }

        [When(@"I click on product info")]
        public void WhenIClickOnProductInfo()
        {
            CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
            createNewProduct.ClickProductInfo();
        }

        [Then(@"I navigated to a page where side bar header should be ""(.*)""")]
		public void ThenVerifySideBarHeaderShouldBe(string expectedTitle)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.VerifyPageTitle(expectedTitle);
		}

        [When(@"Verify active navigation tab text should be ""(.*)"" or ""(.*)""")]
        [Then(@"Verify active navigation tab text should be ""(.*)"" or ""(.*)""")]
        public void ThenVerifyActiveNavigationTabTextShouldBeOr(string stepName, string stepNameMobileView)
        {
            CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
            createNewProduct.IsActiveNavigationTextCorrect(stepName, stepNameMobileView);
        }

        [When(@"I click ""(.*)"" link on subcatagory page")]
		public void WhenIClickIconOnSubcatagoryPage(string iconName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickBackLink(iconName);
		}

		[Then(@"Verify ""(.*)"" product types title should be shown")]
		public void ThenVerifyProductTypesTitleShouldBeShown(string productTitle)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsProductTitleDisplayed(productTitle);
		}

		[When(@"I click ""(.*)"" edit button")]
		public void WhenIClickEditButton(string editBtn)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickArtworkEditButton(editBtn);
		}

		[When(@"I select ""(.*)"" artwork")]
		public void WhenISelectArtwork(string artworkName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectArtwork(artworkName);
		}

		[Then(@"Verify product is live text on launch page")]
		public void ThenVerifyTheTextOnLaunchPage()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.VerifySuccessText();
		}

		[Then(@"Verify product card is shown for ""(.*)"" with ""(.*)"" subcategory")]
		public void ThenVerifyProductCardIsShownForWithSubcatagory(string artwork, string subcategory)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsProductCardDisplayed(artwork, subcategory);
		}

		[Then(@"Verify product card is not shown for ""(.*)"" with ""(.*)"" subcategory")]
		public void ThenVerifyProductCardIsNotShownForWithSubcategory(string artwork, string subcategory)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsProductCardNotDisplayed(artwork, subcategory);
		}

		[When(@"I click more option icon")]
		public void WhenIClickMoreOptionIcon()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickMoreOptionIcon();
		}

		[When(@"Select ""(.*)"" action")]
		public void WhenSelectAction(string action)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectAction(action);
		}

		[When(@"I name my design as ""(.*)""")]
		public void WhenINameMyDesignAs(string nameDesign)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.InputNameDesign(nameDesign);
		}

		[Then(@"Verify artwork should be uploaded successfully")]
		public void ThenVerifyArtworkShouldBeUploadedSuccessfully()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsArtworkUploaded();
		}

		[When(@"I select ""(.*)"" option and ""(.*)"" tag from dropdowmn")]
		public void WhenISelectAs(string menu, string submenu)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectDropdownOptions(menu, submenu);
		}

		[Then(@"Verify subhead tag should be same for selected tag above tag container")]
		public void WhenVerifySubheadTagShouldBeSameForSelectedTagAboveTagContainer()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsSubHeadTagVerified();
		}

		[When(@"I click ""(.*)"" product types title and verify it")]
		public void WhenIClickProductTypesTitle(string productType)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectProductTypeTitle(productType);
		}

		[When(@"Verify active footer menu should be ""(.*)""")]
		public void WhenVerifyActiveFooterMenuShouldBe(string footerName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsFooterMenuActive(footerName);
		}

		[Then(@"Product catagory active tab should be ""(.*)""")]
		public void ThenProductCatagoryActiveTabShouldBe(string tabName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ProcuctCatActiveTab(tabName);
		}

		[When(@"I select ""(.*)"" subcategory image")]
		public void WhenISelectSubcategoryImage(string subcatImg)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickSubCatImage(subcatImg);
		}

		[When(@"I click ""(.*)"" footer menu")]
		public void WhenIClickFooterMenu(string footerName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickFooterMenu(footerName);
		}

		[When(@"I click ""(.*)"" Product catagory tab")]
		public void WhenIClickProductCatagoryTab(string tabName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickProductCatTab(tabName);
		}

		[When(@"I set product edit slider to ""(.*)""")]
		public void WhenISetProductEditSliderTo(string parameter)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.MoveSlider(parameter);
		}

		[Then(@"Verify slider should be slide to the given parameter")]
		public void ThenVerifySliderShouldBeSlideToTheGivenParameter()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsSliderWorked();
		}

		[When(@"I select ""(.*)"" list selection option")]
		public void WhenISelectListSelectionOption(string linkName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ListSelectionOption(linkName);
		}

		[Then(@"Verify all checkboxes should be deselected")]
		public void ThenVerifyAllCheckboxesShouldBeDeselected()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsProductsCheckBoxesUnchecked();
		}

		[Then(@"Verify LAUNCH PRODUCTS button is disabled")]
		public void ThenVerifyLAUNCHPRODUCTSButtonIsDisabled()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsLaunchProductsButtonDisabled();
		}

		[Then(@"Verify LAUNCH PRODUCTS button is enabled")]
		public void ThenVerifyButtonIsEnabled()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsLaunchProductsButtonEnabled();
		}

		[Then(@"Verify all checkboxes should be selected")]
		public void ThenVerifyAllCheckboxesShouldBeSelected()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsProductsCheckBoxesChecked();
		}

		[Then(@"Verify products count should be same as transparent badge for ""(.*)"" tab")]
		public void ThenVerifyProductsCountShouldBeSameAsTransparentBadgeForTab(string productName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.VerifyTranspaentBadgeCount(productName);
		}

		[When(@"I Click ""(.*)"" button and upload artwork")]
		public void WhenIClickButtonAndUploadPhoto(string action)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.ClickAndUploadPhotos(action);
		}

		[Then(@"Verify uploaded artwork should be displayed on design page")]
		public void ThenVerifyUploadedArtworkShouldBeDisplayed()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsUploadedArtwokDisplayed();
		}

		[When(@"I select that artwork")]
		public void WhenISelectThatArtwork()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectTheUploadedArtwork();
		}

		[When(@"Verify Delete icon should be displayed and click")]
		public void WhenVerifyDeleteIconShouldBeDisplayedAndClick()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.VerifyAndClickDeleteIcon();
		}

		[Then(@"Verify selected item should be deleted successfully")]
		public void ThenVerifySelectedItemShouldBeDeletedSuccessfully()
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IsSelectedArtworkDeleted();
		}

		[When(@"I Click on ""(.*)"" tab button")]
		public void WhenIClickOnTabButton(string tabName)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SelectHomePageTab(tabName);
		}

		[When(@"Artwork ""(.*)"" is uploaded then delete from gallery")]
		public void WhenArtworkIsUploadedThenDeleteFromGallery(string action)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.IfArtworkUploadedThenDelete(action);
		}

        [When(@"I set my retail price for product is ""(.*)""")]
        [Then(@"I set my retail price for product is ""(.*)""")]
		public void ThenISetMyRetailPriceForProductIs(string action)
		{
			CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
			createNewProduct.SetProductPrice(action);
        }

        [When(@"Preview the all images")]
        public void WhenPreviewTheAllImages()
        {
            CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
            createNewProduct.PreviewImages();
        }

        [When(@"Add a ""(.*)"" with ""(.*)"" and ""(.*)""")]
        public void WhenAddAWithAnd(string category, string productType, string subCategory)
        {
            CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
            createNewProduct.AddAProductOnHomePage(category, productType, subCategory);
        }

        [When(@"I select ""(.*)"" product types sub-category")]
        public void WhenISelectProductTypesSub_Category(SubCategoryType subCategoryType)
        {
            CreateNewProductPage createNewProduct = new CreateNewProductPage(Driver, _appSettings);
            createNewProduct.ClickAction(subCategoryType);
            Wait.Seconds(1);
        }

    }
}