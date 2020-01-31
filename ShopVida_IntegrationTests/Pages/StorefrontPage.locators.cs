namespace ShopVidaTests.Pages
{
    using OpenQA.Selenium;
    public partial class StorefrontPage
    {
        private By planAmount = By.XPath("//div[contains(@class,'Plans__plan')]");
        private By activeAmountMonth = By.XPath("//div[contains(@class,'is-selected')]//preceding-sibling::h4");
        private By paymentMethod = By.XPath("//div[@class='ant-select-selection__rendered']");
        private By paymentMethodList = By.XPath("//li[.='Add Card']");
        private By iFrame = By.XPath("//*[@title='Secure payment input frame']");
        private By cardNumber = By.XPath("//*[@placeholder='Card number']");
        private By expires = By.XPath("//*[@placeholder='MM / YY']");
        private By CVC = By.XPath("//*[@placeholder='CVC']");
        private By paymentsError = By.XPath("//*[@class='SubTitle']/..//div[@role='alert']");
    }
}