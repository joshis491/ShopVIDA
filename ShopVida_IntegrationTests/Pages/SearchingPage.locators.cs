namespace ShopVidaTests.Pages
{
    using OpenQA.Selenium;
    public partial class SearchingPage
    {
        private By homePageSerachBtn = By.XPath("//button[@class='ButtonGroupToggle__search']");
        private By quantityProduct = By.XPath("//*[@class='mb0 color-gold']");
        private By searchInput = By.CssSelector("input[placeholder='Search']");
        private By searchDetails = By.CssSelector("div[class='Search-result__details']");
        private By productName = By.XPath("//div[@class='ProductModal__upper']//*[@class='tu']");
        private By artworkName = By.XPath("//div[@class='ProductModal__upper']//h1");
        private By slideImages = By.XPath("//div[@class='slick-track']//div[contains(@class,'slick-slide')]");
        private By rightArrow = By.XPath("//span[contains(@class,'ProductModal__slider-arrow_right')]");
        private string selectProduct = "//*[.='{0}']/following-sibling::*[.=\"{1}\"]";
    }
}