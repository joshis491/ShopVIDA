namespace ShopVidaTests.Tests.Steps.DesignGallery
{
    using OpenQA.Selenium.Remote;
    using TechTalk.SpecFlow;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using ShopVidaTests.Pages;

    [Binding]
	public class DesignGallerySteps : SeleniumReporter
    {
        public DesignGallerySteps(RemoteWebDriver driver, AppSettings appSettings)
        : base(appSettings)
		{
			Driver = driver;
        }

		[When(@"There is no design in gallery then add a design")]
		public void WhenThereIsNoDEsignInGalleryThenAddADesign()
		{
			DesignGalleryPage gallery = new DesignGalleryPage(Driver, _appSettings);
			gallery.IsADesignAdded();
		}

		[When(@"I select ""(.*)"" desgin")]
		public void WhenISelectDesgin(string designName)
		{
			DesignGalleryPage gallery = new DesignGalleryPage(Driver, _appSettings);
			gallery.SelectDesignFromGallery(designName);
		}

		[Then(@"Verify the header text ""(.*)""")]
		public void ThenVerifyTheHeaderText(string text)
		{
			DesignGalleryPage gallery = new DesignGalleryPage(Driver, _appSettings);
			gallery.VerifyHeaderTextDesignPage(text);
		}

        [Then(@"Active step text should be ""(.*)""")]
        public void ThenActiveStepTextShouldBe(string action)
        {
            DesignGalleryPage gallery = new DesignGalleryPage(Driver, _appSettings);
            gallery.VerifyActiveStepText(action);
        }

        [When(@"I selected ""(.*)"" as promoted on with date ""(.*)""")]
        public void WhenISelectedAsPromotedOnWithDate(string promotedOn, string promotionDate)
        {
            DesignGalleryPage gallery = new DesignGalleryPage(Driver, _appSettings);
            gallery.SetPromotionFirstStepData(promotedOn, promotionDate);
        }

        [When(@"I select the plan ""(.*)""")]
        public void WhenISelectThePlan(string plan)
        {
            DesignGalleryPage gallery = new DesignGalleryPage(Driver, _appSettings);
            gallery.SelectThePlan(plan);
        }

    }
}