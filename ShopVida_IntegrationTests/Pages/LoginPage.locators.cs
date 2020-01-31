namespace FrameworkTests.Pages
{
	using OpenQA.Selenium;
	public partial class LoginPage 
	{
		private By loginPopup = By.XPath("//div[contains(@class,'widget-container')]");
		private By welcomeHeaderTitle = By.XPath("//div[contains(@class,'header-welcome')]//div");
		private By currentTab = By.XPath("//li[contains(@class,'tabs-current')]");
		private By emailErrorMessage = By.XPath("//span[contains(text(),'Incorrect')]");
		private By emailError = By.Id("auth0-lock-error-msg-email");
		private By passwordError = By.Id("auth0-lock-error-msg-password");
		private By loginPopupText = By.XPath("//div[contains(@class,'login-pane')]//span");
	}
}