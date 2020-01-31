namespace ShopVidaTests.Pages
{
    using OpenQA.Selenium;
    public partial class SalesDashboardPage
    {
        private By rangePicker = By.XPath("//div[@class='Dashboard__range-picker']");
        private By startDate = By.XPath("//div[contains(@class,'left')]//input[@placeholder='Start date']");
        private By startDateMonth = By.XPath("//div[contains(@class,'left')]//*[@class='ant-calendar-month-select']");
        private By startDateYear = By.XPath("//div[contains(@class,'left')]//*[@class='ant-calendar-year-select']");
        private By startDateDate = By.XPath("//div[contains(@class,'left')]//*[@aria-selected='true']");
        private By endDate = By.XPath("//div[contains(@class,'right')]//input[@placeholder='End date']");
        private By endDateMonth = By.XPath("//div[contains(@class,'right')]//*[@class='ant-calendar-month-select']");
        private By endDateYear = By.XPath("//div[contains(@class,'right')]//*[@class='ant-calendar-year-select']");
        private By endDateDate = By.XPath("//div[contains(@class,'right')]//*[@aria-selected='true']");
        private By calenderFooter = By.XPath("//div[contains(@class,'calendar-footer')]//span");
        private string productRelaunch = "//td[.='{0}']/../td[.='{1}']//ancestor::tr//span[contains(@class,'relaunch')]";
        private string productStatus = "//td[.='{0}']/../td[.='{1}']/..//td[3]";
        private string productRemove = "//td[.='{0}']/../td[.='{1}']//ancestor::tr//span[contains(@class,'remove')]";
        private By emptyImage = By.XPath("//div[@class='ant-empty-image']");
        private By limitItemsSelect = By.CssSelector("div.ant-select-selection-selected-value");
        private By tableRows = By.CssSelector("table > tbody >tr");

        private By TableRows { get => tableRows; set => tableRows = value; }
    }
}