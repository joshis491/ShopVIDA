namespace ShopVidaTests.Pages
{
	using OpenQA.Selenium;
	public partial class DesignGalleryPage
	{
		private By noDesign = By.XPath("//div[@class='DesignLibrary']//p");
		private By reuseDesignText = By.XPath("//div[@class='Header__upper']//p");
        private By activeStep = By.XPath("//div[@class='ShowSteps']//li[@class='ActivePage']");
        private By promotedDropdown = By.XPath("//div[@class='ant-select-selection__rendered']");
        private By promotionCalender = By.XPath("//span[@class='ant-calendar-picker']");
        private By promotionPlan = By.XPath("//div[contains(@class,'Plans__plan')]");
	}
}