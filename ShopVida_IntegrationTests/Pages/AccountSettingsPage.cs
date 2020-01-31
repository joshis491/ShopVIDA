namespace ShopVidaTests.Pages
{
    using FrameworkTests.Pages;
    using FrameworkTests.Utilities.Enums;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using ShopVidaTests.Utilities.Helpers;
    using ShopVidaTests.Utilities.Objects;
    using ShopVidaTests.Utilities.TestDataGenerator.BaseGenerators;
    using System;
    using System.Linq;

    public partial class AccountSettingsPage : SeleniumReporter
    {
        private SharedStorage sharedStorage;

        private readonly string resourceTag = "resource.tag";

        public AccountSettingsPage(RemoteWebDriver driver, AppSettings appSettings, SharedStorage sharedStorage)
          : base(appSettings)
        {
            this.sharedStorage = sharedStorage;
        }

        internal void FillSettingsForm(ProfileSettings settings)
        {
            FillAccountSettingsForm(settings);
            sharedStorage.SetSharedInfo(resourceTag, settings);
        }

        internal void FillAccountSettingsForm(ProfileSettings settings)
        {
            collectionTitle.InputKey(settings.CollectionTitle);
            payPalEmail.InputKey(settings.PaypalEmail);
            firstName.InputKey(settings.FirstName);
            lastName.InputKey(settings.LastName);
            bio.InputKey(settings.Bio);
            settingsPhone.InputKey(settings.PhoneNumber);
            country.InputKey(settings.Country);
            dropdownItems.SelectElementFromLoopingAndClick(settings.Country);
            city.InputKey(settings.City);
            lastName.GetElement().ScrollDown();
            birthDate.ClickButton();
            CommonPage commonPage = new CommonPage(Driver, _appSettings);
            commonPage.SelectDateFromDatePicker(settings.BirthDate);
            //var test = Time.Parse(GetPickupDate(), "yyyy-MM-dd");
        }

        public string GetPickupDate()
        {
            return birthDateInput.GetElementValue();
        }

        internal void SelectSettingsRadioBtn(string preference)
        {
            ElementLocatorExtensions.Scrollup();
            ElementLocatorExtensions.GetElementXpath(paymentPreferences, preference).ClickButton();
            Assert.IsTrue(ElementLocatorExtensions.GetElementXpath(paymentPreferences, preference).GetElementValueByAttribute("class").Contains("checked"), "radio button is not selected.");
        }

        internal void UploadPhotos()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    CommonPage commonPage = new CommonPage(Driver, _appSettings);
                    commonPage.GenerateImage();
                    uploadCoverPhoto.ClickButton();
                    commonPage.UploadPhoto();
                    Wait.Seconds(2);
                    uploadCoverPhoto.GetElement().ScrollDown();
                    uploadProfilePhoto.Click();
                    commonPage.UploadPhoto();
                    Wait.Seconds(2);
                    break;

                case PlatformID.Unix:
                    break;

                default:
                    Console.WriteLine("No Idea what I'm on!");
                    break;
            }
        }

        internal void DrawSignature()
        {
            uploadProfilePhoto.GetElement().ScrollDown();
            var action = Actions;
            action.ClickAndHold(canvasSign.GetElement()).MoveByOffset(-20, 30);
            action.MoveByOffset(40, 10).Build().Perform();
            action.MoveByOffset(-60, 5).Build().Perform();
            action.MoveByOffset(-20, 40).Build().Perform();
        }

        internal void CompareSettingsErrorMessages()
        {
            collectionTitle.BlankValue();
            var sg = new StringGenerator();
            var inputString = sg.AlphanumericString(8);
            payPalEmail.InputKey(inputString);
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    CommonPage commonPage = new CommonPage(Driver, _appSettings);
                    commonPage.GenerateImage();
                    uploadSignPhoto.ClickButton();
                    commonPage.UploadPhoto();
                    Wait.Seconds(2);
                    Assert.AreEqual(signUploadError.GetElementValue(), ErrorMessages.SignUploadError, "Sign upload error is not as expected.");
                    break;
            }
            Assert.Multiple(() =>
            {
                Assert.AreEqual(collectionTitleError.GetElementValue(), ErrorMessages.CollectionTitleError, "Collection title error is not as expected.");
                Assert.AreEqual(paypalEmailError.GetElementValue(), ErrorMessages.PaypalEmailError, "PayPal Email error is not as expected.");
            });
        }

        internal void ClickDeactivateLink()
        {
            canvasSign.GetElement().ScrollDown();
            deactivateLink.ClickButton();
            Wait.Seconds(2);
        }

        internal void VerifyDeactivateAccountContent()
        {
            string[] deactivateAccountContents = { Contents.DeactivateAccountContent1, Contents.DeactivateAccountContent2 };
            foreach (string node in deactivateAccountContents)
            {
                var contents = deactivateContent.GetElements().Where(item => item.ToString().Equals(node, StringComparison.InvariantCultureIgnoreCase));
                Assert.IsFalse(contents == null, "Deactivate account content is not as expected.");
            }
        }

        internal void ClickSocialMediaIcons(string action)
        {
            ElementLocatorExtensions.Scrolldown();
            Wait.Seconds(1);
            foreach (IWebElement icon in socialMediaIcons.GetElements())
            {
                if (icon.GetElementValueByAttribute("class").CaseInsensitiveContains(action))
                {
                    icon.ClickButton();
                    Wait.Seconds(3);
                    break;
                }
            }
        }

        internal void ClickAboutLinks(string action)
        {
            ElementLocatorExtensions.Scrolldown();
            Wait.Seconds(1);
            aboutListItems.SelectElementFromLooping(action).ClickButton();
            Wait.Seconds(3);
        }

        internal void AssertSettingDetailsData(ProfileSettings expectedResource)
        {
            ProfileSettings actualData = GetSettingDetails();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedResource.CollectionTitle, actualData.CollectionTitle);
                Assert.AreEqual(expectedResource.CollectionTitle, actualData.CollectionTitle);
                Assert.AreEqual(expectedResource.PaypalEmail, actualData.PaypalEmail);
                Assert.AreEqual(expectedResource.FirstName, actualData.FirstName);
                Assert.AreEqual(expectedResource.LastName, actualData.LastName);
                Assert.AreEqual(expectedResource.Bio, actualData.Bio);
                Assert.AreEqual(expectedResource.PhoneNumber, actualData.PhoneNumber);
                Assert.AreEqual(expectedResource.Country, actualData.Country);
                Assert.AreEqual(expectedResource.City, actualData.City);
                Assert.AreEqual(expectedResource.BirthDate, actualData.BirthDate);
            });
        }

        internal ProfileSettings GetSettingDetails()
        {
            ProfileSettings details = new ProfileSettings()
            {
                CollectionTitle = collectionTitle.GetElementValueByAttribute("value"),
                PaypalEmail = payPalEmail.GetElementValueByAttribute("value"),
                FirstName = firstName.GetElementValueByAttribute("value"),
                LastName = lastName.GetElementValueByAttribute("value"),
                Bio = bio.GetElementValueByAttribute("value"),
                PhoneNumber = settingsPhone.GetElementValueByAttribute("value"),
                Country = country.GetElementValueByAttribute("value"),
                City = city.GetElementValueByAttribute("value"),
                BirthDate = birthDate.GetElementValueByAttribute("value"),
            };
            return details;
        }
    }
}