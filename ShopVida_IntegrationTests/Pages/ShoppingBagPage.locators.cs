namespace ShopVidaTests.Pages
{
    using OpenQA.Selenium;
    public partial class ShoppingBagPage
    {
        private By cartName = By.XPath("//*[text()='Your bag is empty']");
        private By closeBtn = By.XPath("//button[contains(@class,'close-btn')]");
        private By minusButton = By.XPath("//*[@class='anticon anticon-minus']");
        private By removeSampleBtn = By.XPath("//div[contains(@class,'WholesaleCart__remove-btn')]//span[.='Remove Samples']");
        private By removeSampleBtnMobileView = By.XPath("//div[@class='WholesaleCart__actions']//span[.='Remove Samples']");
        private By productsList = By.XPath("//li[@class='LineItems__item']");
        private By giftBoxMinusBtn = By.XPath("//img[@alt='Gift Box']/../../div[@class='LineItems__end']//i[contains(@class,'minus')]");
        private By giftBoxPlusBtn = By.XPath("//img[@alt='Gift Box']/../../div[@class='LineItems__end']//i[contains(@class,'plus')]");
        private By totalCost = By.XPath("//*[text()='TOTAL:']//span");
        private By msrpTotal = By.XPath("//*[text()='MSRP TOTAL:']//del");
        private By checkoutFirstName = By.Id("checkout_shipping_address_first_name");
        private By checkoutLastName = By.Id("checkout_shipping_address_last_name");
        private By checkoutAddress1 = By.Id("checkout_shipping_address_address1");
        private By checkoutCity = By.Id("checkout_shipping_address_city");
        private By checkoutCountry = By.Id("checkout_shipping_address_country");
        private By checkoutState = By.Id("checkout_shipping_address_province");
        private By checkoutZipCode = By.Id("checkout_shipping_address_zip");
        private By checkoutPhoneNumber = By.Id("checkout_shipping_address_phone");
        private By checkoutGiftCardInput = By.Id("checkout_reduction_code");
        private By discountBtn = By.XPath("//*[.='Gift card']//..//button");
        private By logOut = By.XPath("//a[.='Log out']");
        private By checkoutEmail = By.Id("checkout_email");
        private By checkoutEmailError = By.XPath("//input[@placeholder='Email']/../../p");
        private By checkoutFirstNameError = By.XPath("//input[@placeholder='First name']/../..//p");
        private By checkoutLastNameError = By.XPath("//input[@placeholder='Last name']/../..//p");
        private By checkoutAddressError = By.XPath("//input[@placeholder='Address']/../..//p");
        private By checkoutCityError = By.XPath("//input[@placeholder='City']/../..//p");
        private By checkoutStateError = By.XPath("//select[@placeholder='State']/../..//p");
        private By checkoutZipCodeError = By.XPath("//input[@placeholder='ZIP code']/../..//p");
        private By checkoutPhoneError = By.XPath("//input[@placeholder='Phone (required)']/../..//p");
        private By giftCardCodeError = By.XPath("//label[text()='Gift card']/../../../p");
        private By autocompleteAddress = By.XPath("//ul[@id='address-autocomplete']//li");
        private By shippingMethodRadio = By.XPath("//label[@class='radio__label']//span[contains(@class,'primary')]");
        private By currentActiveHeader = By.XPath("//ul[@class='breadcrumb ']//li[contains(@class,'current')]");
        private By paymentHaeder = By.XPath("//ul[@class='breadcrumb ']//li");
        private string editPaymentStep = "//div[@role='gridcell']/../../..//span[.='{0}']/parent::a";
        private string changeContent = "//span[.='{0}']/../../..//div[@class='review-block__content']";
        private By billingAddressRadio = By.XPath("//*[.='Billing address']/../..//label[contains(@class,'radio')]");
        private By checkoutBillingAddress1 = By.Id("checkout_billing_address_address1");
        private By billingFirstName = By.Id("checkout_billing_address_first_name");
        private By orderSummaryToggle = By.XPath("//span[contains(@class,'toggle__text--show')]");
        private By lineItems = By.XPath("//div[contains(@class,'type-details')]//p[contains(@class,'black')]");
        private By sizeDropdown = By.CssSelector("div.ant-select-selection-selected-value");
        private By dropdownValues = By.XPath("//ul[contains(@class,'dropdown')]//li");
    }
}