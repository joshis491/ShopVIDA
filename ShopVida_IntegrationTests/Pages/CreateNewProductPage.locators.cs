namespace VidaDesignStudioTests.Pages
{
	using OpenQA.Selenium;
    using ShopVidaTests.Utilities.Enums;
    using ShopVidaTests.Utilities.Helpers;

    public partial class CreateNewProductPage
	{
		private string productTypeTitle = "//*[@class='color-white m0'and .='{0}']";
        private By modalHeader = By.XPath("//*[contains(@class,'Modal__header')]");
        private By modalHeaderMobileView = By.XPath("//div[@class='ant-modal-body']//*[contains(@class,'Modal__header')]");     
        private By activeNavigationText = By.XPath("//*[contains(@class,'phase is-current')]");
		private By backIcon = By.XPath("//p[@class='tl ProductTypes__backlink']");
		private string editButton = "//p[.='{0}']/../button/span";
		private string dropdownMenu = "//li//span[.='{0}']";
		private string dropdownSubMenu = "//li//span[.='{0}']/../../ul//li//span[.='{1}']";
		private string subHeadTag = "//div[contains(@class,'subhead-tag')]//span[.='{0}']";
        private string subHeadCloseBtn = "//span[.='{0}']//i[contains(@class,'close')]";
		private string productSubType = "//*[ .='{0}']/../..//div[contains(@class,'sub-categories')]//li";
		private By footerMenuActive = By.XPath("//li[@class='is-open']");
		private By productCatActiveTab = By.XPath("//div[contains(@class,'tab-active')]");
		private By productCategoryTab = By.XPath("//div[@class='multi-launch-list__tab']");
		private By subcatageryType = By.XPath("//div[contains(@class,'slick-slide')]//li//h3");
		private string subCatImg = "//*[contains(text(),'{0}')]//ancestor::li//div[contains(@class,'img-wrapper')]";
        private By rightArrow = By.XPath("//span[contains(@class,'ProductTypes__arrow_right')]");
		private By footerMenu = By.XPath("//div[@class='footer-menu']//li/h3");
		private By sliderHandle = By.XPath("//div[@role='slider']");
		private By listSelectionOption = By.XPath("//span[@class='fake-link color-black']");
		private By productCheckbox = By.XPath("//input[@type='checkbox']//parent::span");
		private By launchProductBtn = By.XPath("//span[contains(text(),'Launch')]//parent::button");
		private string badgeCount = "//*[contains(text(),'{0}')]//span";
		private By designHeaderModal = By.XPath("//*[@class='DesignModal-header__title-input']");
		private By deleteIcon = By.XPath("//*[contains(@class,'delete')]");
		private By homePageTabName = By.XPath("//div[@class='ButtonGroupToggle__buttons']//a");
        private By setPriceInput = By.XPath("//div[@class='Modal__sub-header']//input");
        private By setPriceInputMobileView = By.XPath("//div[@class='ant-modal-body']//input");
        private By previewItems = By.XPath("//ul[@class='slick-thumb']//li/img");
        private By previewLoader = By.XPath("//i[@class='anticon anticon-loading']");
        private By previewText = By.XPath("//p[contains(text(),'wrong')]");
        private By productTextCheckBox = By.XPath("//span[.='This product has text']");
        private By addProductCard = By.XPath("//div[@class='AddProductCard__inner']");
        private By termsOfService = By.CssSelector("input[name='termsOfService']");
        private By productInfo = By.XPath("//span[@class='ProductEdit__modal-trigger']");

        private By GetActionButton(SubCategoryType action)
        {
            return By.XPath(string.Format(subCatImg, action.GetEnumDescription()));
        }
    }
}