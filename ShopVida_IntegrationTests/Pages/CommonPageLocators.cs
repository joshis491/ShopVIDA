namespace FrameworkTests.Pages
{
	using OpenQA.Selenium;
	public class CommonPageLocators : TechTalk.SpecFlow.Steps
	{
		public By loginEmail = By.Id("1-email");
		public By loginPassword = By.XPath("//*[@placeholder='your password']");
		public By sideBarHeader = By.XPath("//*[@class='DesignWizard__header']");
        public By sideBarHeaderMobileView = By.XPath("//*[contains(@class,'Header wrapper')]");     
        public By loginButton = By.XPath("//button[.='Log In']");
		public By closeIcon = By.Id("Icon");
        public By closeIconPopup = By.XPath("//*[@class='ant-modal-close']/span/i");
		public By logo = By.XPath("//*[contains(@class,'__nav')]//img");
		public By createNewProductText = By.XPath("//div[contains(@class,'AddProductCard')]//p");
		public By signOut = By.XPath("//*[text()='Sign Out']");
		public By commonHeader = By.XPath("//*[@class='mb0']");
		public string selectMenu = "//*[contains(@class,'_desktop')]//*[contains(text(),'{0}')]";
        public string selectMenuMobile = "//*[contains(@class,'_mobile')]//*[contains(text(),'{0}')]";
        public string selectSubMenu = "//*[text()='{0}']//../../..//ul//*[text()='{1}']";
        public string selectSubCatagotyTitle = "//*[contains(@class,'__subcategory-title') and text()=\"{0}\"]";
        public string commonButton = "//button[.='{0}']";
		public string commonHeaderDialogueBox = "//*[text()='{0}']";
		public string getCommonHeader = "//div[contains(@class,'wrapper')]//*[contains(@class,'mb') and text()='{0}']";
		public By btnPrevious = By.XPath("//*[contains(@class,'prev-decade-btn')]");
		public By btnNext = By.XPath("//*[contains(@class,'next-decade-btn')]");
		public By calenderYearSelectButton = By.XPath("//*[@class='ant-calendar-year-select']");
		public By calenderMonthSelectButton = By.XPath("//*[@class='ant-calendar-month-select']");
		public By activeSelectedYear = By.XPath("//*[contains(@class,'calendar-year-panel-selected-cell')]");
		public By calenderYearCell = By.XPath("//*[contains(@class,'year-panel-cell') and not(contains(@class,'next')) and not(contains(@class,'last'))]");
		public By calenderMonthCell = By.XPath("//*[contains(@class,'calendar-month-panel-cell')]");
		public By calenderDateCell = By.XPath("//*[contains(@class,'ant-calendar-cell') and not(contains(@class,'next')) and not(contains(@class,'calendar-last-month-cell'))]");
		public By dropdownItems = By.XPath("//*[contains(@class,'select-dropdown-menu-item')]");
		public string getCategoryAndSubCategory = "//*[text()='{0}']/../..//li/span[contains(text(),\"{1}\")]";
		public By selectArtwork = By.XPath("//div[contains(@class,'gutter-box')]//p");
		public By productSubCatText = By.XPath("//*[contains(@class,'__subcategory-text')]");
		public By successText = By.XPath("//div[@class='MultiLaunchSidebar']//h1");
		public By giftBoxQuantity = By.XPath("//img[@alt='Gift Box']/../../div[@class='LineItems__end']/p");
		public By moreOptionLogo = By.XPath("//*[@id='Mobile---Product-4']//ancestor::button");
		public By moreActions = By.XPath("//div[@class='PoductCard__more-actions']//p");
		public By cardRemoveOption = By.XPath("//div[@class='PoductCard__more-actions']//p[.='Remove']");
		public By productQuantity = By.XPath("//div[@class='LineItems__end']//p");
		public By discountPrice = By.XPath("//*[contains(@class,'active')]//*[@class='mb0']");
        public By discountPriceMobileView = By.XPath("//*[@class='LineItems']//p[contains(@class,'hidden')]");
		public By retailPrice = By.XPath("//*[contains(@class,'LineItems__type')]//*[@class='mb0']");
        public string productCard = "//*[.='{0}']//preceding-sibling::*[.=\"{1}\"]/../../../../../..";
        public string productCardDetails = "//*[.='{0}']//preceding-sibling::*[.=\"{1}\"]/../../..";
        public By inputDesignName = By.Id("designForm_title");
		public By designCardTitle = By.XPath("//*[@class='DesignCard__title truncated']");
		public By successMessage = By.XPath("//div[contains(@class,'message-success')]//span");
        public By totalSaving = By.XPath("//*[@class='color-gold mb0']//span");
        public By totalValue = By.XPath("//*[contains(text(),'TOTAL')]//span/../following-sibling::h4/span");
        public By collectionTitle = By.Id("account settings_displayName");
        public string checkoutsBtn = "//span[contains(text(),'{0}')]";
        public By previousLink = By.XPath("//span[contains(@class,'previous-link-content')]");
        public By loadingBar = By.XPath("//div[@class='loadingbar']");
        public By promoteProduct = By.XPath("//div[@class='promoted-placement']");
        public By plusButton = By.XPath("//*[@class='anticon anticon-plus']");
        public By loader = By.XPath("//*[@class='anticon anticon-loading']");
        public By menuToggle = By.CssSelector("div[class='nav-icon__inner']");
        public By commonDropdownList = By.XPath("//div[contains(@class,'select-dropdown')]//li");
        public By accountSaveButton = By.XPath("//div[@class='ant-row ant-form-item']//button[.='Save']");
    }
}