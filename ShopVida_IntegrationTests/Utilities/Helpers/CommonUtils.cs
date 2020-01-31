namespace FrameworkTests.Utilities.Helpers
{
	using FrameworkTests.Utilities.Enums;
	using FrameworkTests.Utilities.Objects;
	using OpenQA.Selenium.Remote;
	using System;

	public partial class CommonUtils
	{
		public static string MapPageNameToPath(Page pageName)
		{
			switch (pageName)
			{
                case Page.Home: return "";
                case Page.Design: return "/design";
				case Page.Settings: return "/settings";
                case Page.Gallery: return "/gallery";
                case Page.Dashboard: return "/dashboard";
                case Page.DesignGallery: return "/design-gallery";
				case Page.EmailMarketing: return "/marketing-email";
                case Page.PremiumSubscription: return "/pages/subscription";
                case Page.ArtistAmbassadorProgram: return "/pages/artist-ambassador";
                case Page.EditorialPhotography: return "/pages/marketing-tools#editorial-photos-top";
				case Page.TipsAndResources: return "/pages/marketing-tools#tips-inspiration-top";
				case Page.OrderHistory: return "/account";
				case Page.Sample: return "/sample-order";
                case Page.Reviews: return "/pages/reviews";
                case Page.Launch: return "/multi-launch/design";
                case Page.Storefront: return "/collections/";
                case Page.Checkouts: return "/3125973/checkouts/";
                case Page.LearnMoreAboutVIDA: return "/design-with-vida";
                case Page.StorefrontSample: return "/collections/sample-page";
                case Page.Feedback: return "/feedback";
                case Page.Blogs: return "https://blog.shopvida.com/";
				case Page.Twitter: return "https://twitter.com/shopvida";
				case Page.Facebook: return "https://www.facebook.com/shopatvida";
				case Page.Instagram: return "https://www.instagram.com/shopvida/";
				case Page.Pinterest: return "https://www.pinterest.com/shopVIDA/";
                case Page.HelpCenter: return "https://shopvida.zendesk.com/hc/en-us";
                case Page.PrivacyPolicy: return "https://shopvida.com/pages/privacy-policy";
                case Page.YouTube: return "https://www.youtube.com/channel/UCVGCwEY5S0SOCN01R8vmASg";
				case Page.TermsAndConditions: return "https://studio.shopvida.com/terms-of-service";
                case Page.PremiumStorefront: return "https://studio.shopvida.com/premium-storefront";
                case Page.HolidayCalender: return "https://shopvida.zendesk.com/hc/en-us/articles/360035636834";
                case Page.SeeProductionTimes: return "https://shopvida.zendesk.com/hc/en-us/articles/360000021147-Shipping-Times";
                case Page.ShippingTimes: return "https://shopvida.zendesk.com/hc/en-us/articles/360000021147-Manufacturing-Lead-Times";

                default: throw new Exception($"Page name '{pageName}' is not mapped");
			}
		}

		public static void RedirectToPath(string path, RemoteWebDriver driver, AppSettings appSettings)
		{
			string url = $"{appSettings.Urls.BaseUrl}{path}";
			Browser.GoToUrl(url);
			Wait.ExplicitWait(2);
		}

		public static (int Width, int Height) ReturnMobileViewDimensions(MobileView dimensions)
		{
			switch (dimensions)
			{
				case MobileView.GalaxyS5: return (360, 640);
				case MobileView.iPad: return (768, 1024);
				case MobileView.iPadMini: return (768, 1024);
				case MobileView.iPadPro: return (1024, 1024);
				case MobileView.iPhone5_SE: return (360, 640);
				case MobileView.iPhone6_7_8: return (375, 667);
				case MobileView.iPhoneX: return (375, 812);
				case MobileView.Nexus5X: return (412, 732);
				case MobileView.Nexus6P: return (412, 732);
				case MobileView.Pixel2: return (411, 731);
				case MobileView.Pixel2XL: return (411, 823);
                case MobileView.iPhone6_7_8Plus: return (414, 736);

                default: throw new Exception($"Dimension '{dimensions}' is not mapped");
			}
		}
	}
}