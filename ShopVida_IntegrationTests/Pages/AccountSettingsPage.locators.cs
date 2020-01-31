namespace ShopVidaTests.Pages
{
	using OpenQA.Selenium;
	public partial class AccountSettingsPage
	{
		private By payPalEmail = By.Id("account settings_paypal");
		private By firstName = By.Id("account settings_firstName");
		private By lastName = By.Id("account settings_lastName");
		private By bio = By.Id("account settings_bio");
		private By settingsPhone = By.CssSelector("input[id='account settings_mobile']");
		private By country = By.XPath("//div[@id='account settings_country']//input");
		private By city = By.Id("account settings_city");
		private By birthDate = By.XPath("//*[@id='account settings_birthday']//input");
        private By birthDateInput = By.XPath("//*[@id='account settings_birthday']//input");      
        private string paymentPreferences = "//*[@value='{0}']/.././..";
        private By canvasSign = By.XPath("//canvas");
		private By uploadCoverPhoto = By.XPath("//*[contains(text(),'Upload Cover Photo')]");
		private By uploadProfilePhoto = By.XPath("//*[contains(text(),'Upload Profile Photo')]");
		private By uploadSignPhoto = By.XPath("//*[contains(text(),'Upload Signature Photo')]");
		private By collectionTitleError = By.XPath("//*[contains(text(),'Title')]//..//..//..//div[contains(@class,'has-error')]//div");
		private By paypalEmailError = By.XPath("//*[contains(text(),'Email')]//..//..//div[contains(@class,'has-error')]//div");
		private By signUploadError = By.XPath("//div[@class='signature-pad']//..//div[@class='toast']//p");
		private By deactivateAccountContent = By.XPath("//div[@class='ant-popover-inner-content']");
		private By deactivateLink = By.XPath("//div[@class='deactivate-account']//span");
		private By deactivateContent = By.XPath("//div[@class='ant-popover-inner-content']//p");
		private By socialMediaIcons = By.XPath("//*[contains(@class,'icon-social')]");
		private By aboutListItems = By.XPath("//*[.='ABOUT']/..//li//a");
	}
}