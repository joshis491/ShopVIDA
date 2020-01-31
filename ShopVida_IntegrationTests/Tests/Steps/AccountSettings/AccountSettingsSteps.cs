namespace ShopVidaTests.Tests.Steps.AccountSettings
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
    internal class AccountSettingsSteps : SeleniumReporter
    {
        private SharedStorage sharedStorage;

        private readonly string resourceTag = "resource.tag";

        public AccountSettingsSteps(RemoteWebDriver driver, AppSettings appSettings, SharedStorage sharedStorage)
        : base(appSettings)
        {
            Driver = driver;
            this.sharedStorage = sharedStorage;
        }

        [Given(@"I get Settings data from file ""(.*)""")]
		public void GivenIGetPickupDataFromFile(string file)
		{
			string data = DataFiles.ReadJsonDataFile(file);
			ProfileSettings settings = ObjectSerializer.DeserializeToObject<ProfileSettings>(data);
			sharedStorage.SetSharedInfo(ContextTag.SettingData, settings);
        }

        [When(@"I fill account settings form:")]
        public void WhenIFillAccountSettingsFormWithData()
        {
            ProfileSettings settings = sharedStorage.GetSharedInfo<ProfileSettings>(ContextTag.SettingData);
            AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
            accountSettings.FillSettingsForm(settings);
        }

		[When(@"I select ""(.*)"" payment preferences radio button")]
		public void WhenISelectPaymentPreferencesRadioButton(string option)
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.SelectSettingsRadioBtn(option);
		}

		[When(@"I Uploaded all the required photos")]
		public void WhenIUploadedAllTheRequiredPhotos()
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.UploadPhotos();
		}

		[When(@"Draw a new signature on canvas")]
		public void WhenDrawANewSignatureOnCanvas()
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.DrawSignature();
		}

		[When(@"I clear and input values and verify validation messages")]
		public void WhenIClearAndInputValuesAndVerifyValidationMessages()
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.CompareSettingsErrorMessages();
		}

		[When(@"I click Deactivate Account link")]
		public void WhenIClickDeactivateAccountLink()
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.ClickDeactivateLink();
		}

		[Then(@"Verify the deactive account content in dialogue box")]
		public void ThenVerifyTheDeactiveAccountContentInDialogueBox()
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.VerifyDeactivateAccountContent();
		}

		[When(@"I click ""(.*)"" social media icon")]
		public void WhenIClickIcon(string action)
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.ClickSocialMediaIcons(action);
		}

		[When(@"I click ""(.*)"" lower footer link")]
		public void WhenIClickLowerFooterLink(string action)
		{
			AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
			accountSettings.ClickAboutLinks(action);
		}

        [Then(@"Verify account settings page contains correct data")]
        public void ThenVerifyAccountSettingsPageContainsCorrectData()
        {
            ProfileSettings settings = sharedStorage.GetSharedInfo<ProfileSettings>(resourceTag);
            AccountSettingsPage accountSettings = new AccountSettingsPage(Driver, _appSettings, sharedStorage);
            accountSettings.AssertSettingDetailsData(settings);
        }
    }
}