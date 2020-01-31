namespace FrameworkTests.Pages
{
    using AutoIt;
    using FluentAssertions;
    using FrameworkTests.Utilities;
    using FrameworkTests.Utilities.Enums;
    using FrameworkTests.Utilities.Extensions;
    using FrameworkTests.Utilities.Helpers;
    using FrameworkTests.Utilities.Objects;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using TechTalk.SpecFlow;

    public class CommonPage : SeleniumReporter
    {
        public CommonPage(RemoteWebDriver driver, AppSettings appSettings)
        : base(appSettings) { }

        internal void SetUserLoginCredentials(string username, string password)
        {
            username.Should().NotStartWith("$", "because we don't accept special charecters in string");
            username.Should().NotBeNull();
            username.Should().NotBeEmpty("because the string is not empty");
            username.Should().NotBeNullOrWhiteSpace();
            username.Should().NotContainAny("#", "$", "*", "!", "because we dont want special charecter even in middle of string");
            username.Should().Match("*@*.com");
            Regex regexUserEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Regex regexPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]|.*[_()$@!#%^*?&])[A-Za-z\d_()$@!#%^*?&]{8,}$");
            loginEmail.InputKey(username);
            loginPassword.InputKey(password);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(regexUserEmail.IsMatch(loginEmail.GetElementValueByAttribute("value")));
                loginEmail.GetElementValueByAttribute("value").Should().MatchRegex(regexUserEmail.ToString());
                Assert.IsTrue(regexPassword.IsMatch(loginPassword.GetElementValueByAttribute("value")));
            });
        }

        internal void DoUserLogin()
        {
            loginButton.Click();
            Wait.Seconds(8);
        }

        internal void DoUserSignOut()
        {
            signOut.Click();
            Wait.Seconds(5);
        }

        internal void ClickContinueShipping(string btnName)
        {
            ElementLocatorExtensions.Scrolldown();
            ElementLocatorExtensions.GetElementXpath(checkoutsBtn, btnName).HoverOverElement();
            ElementLocatorExtensions.GetElementXpath(checkoutsBtn, btnName).ClickButton();
            Wait.Seconds(2);
        }

        internal void ClickReturnLinkBtn(string btnName)
        {
            Assert.AreEqual(previousLink.GetElementValue(), btnName, "previous link button name is not as expected.");
            previousLink.ClickButton();
            Wait.Seconds(2);
        }

        internal void VerifyHeaderPageTitle(Table expectedTitle)
        {
            Wait.Seconds(7);
            Assert.AreEqual(commonHeader.GetElementValue(), expectedTitle.Rows[0]["landedScreenName"], "Landed scfreen name is not as expected.");
        }

        internal void ClickAccountSaveBtn()
        {
            accountSaveButton.ClickButton();
            Wait.Seconds(2);
        }

        internal void VerifyPageLink(Page pageName)
        {
            Wait.Seconds(15);
            var path = CommonUtils.MapPageNameToPath(pageName);
            if (pageName.Equals(Page.Launch))
            {
                successText.UntilElementIsDisplayed(new TimeSpan(0, 0, 120));
            }
            if (path.Contains("https"))
            {
                Assert.AreEqual(Driver.Url, path, "Url is not as expected.");
            }
            else
            {
                string url = $"{_appSettings.Urls.BaseUrl}{path}";
                Assert.IsTrue(Driver.Url.Contains(url), "Url is not as expected.");
            }
        }

        internal void IsUserNavigated(Page pageName)
        {
            var path = CommonUtils.MapPageNameToPath(pageName);
            string url = $"{_appSettings.Urls.BaseUrl}{path}";
            url.Should().NotBeNullOrWhiteSpace("Please check the url string !!!");
            Browser.GoToUrl(url);
            Wait.Seconds(4);
        }

        internal void VerifyPageLinkOtherWindow(Page pageName)
        {
            string newTabHandle = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(newTabHandle);
            Wait.Seconds(6);
            var path = CommonUtils.MapPageNameToPath(pageName);
            if (path.Contains("https"))
            {
                Assert.AreEqual(Driver.Url, path, "Url is not as expected.");
            }
            else if (DictionaryProperties.Details["ScenarioName"].Contains(_appSettings.ScenarioName.ViewStorefront))
            {
                string url = $"{_appSettings.Urls.BaseUrlOtherWindow}{path}{DictionaryProperties.Details["CollectionTitle"]}";
                Assert.AreEqual(Driver.Url, url, "Url is not as expected.");
            }
            else
            {
                string url = $"{_appSettings.Urls.BaseUrlOtherWindow}{path}";
                Assert.AreEqual(Driver.Url, url, "Url is not as expected.");
            }
        }

        internal void SelectMenu(string menu, string submenu)
        {
            if (menuToggle.IsDisplayed())
            {
                menuToggle.ClickButton();
                ElementLocatorExtensions.GetElementXpath(selectMenuMobile, menu).ClickButton();
            }
            else
            {
                ElementLocatorExtensions.GetElementXpath(selectMenu, menu).ClickButton();
            }
            Wait.Seconds(3);
            if (!string.IsNullOrEmpty(submenu))
            {
                ElementLocatorExtensions.GetElementXpath(selectSubMenu, menu, submenu).ClickButton();
                Wait.Seconds(1);
            }
            if (collectionTitle.IsDisplayed())
            {
                DictionaryProperties.Details["CollectionTitle"] = collectionTitle.GetElementValueByAttribute("value").ToLower();
            }
        }

        internal void IsButtonDisabled(string buttonName)
        {
            if (ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).IsDisplayed())
            {
                Assert.IsFalse(ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).IsEnabled(), "Button is not disabled.");
            }
        }

        internal void IsButtonEnabled(string buttonName)
        {
            ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).UntilElementIsEnabled(new TimeSpan(0, 0, 60));
            Assert.IsTrue(ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).IsEnabled(), "Button is not enabled.");
        }

        internal void IsButtonDisplayed(string buttonName)
        {
            ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).UntilElementIsDisplayed(new TimeSpan(0, 0, 40));
            Assert.IsTrue(ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).IsDisplayed(), "Button is not displayed.");
        }

        internal void GenerateImage()
        {
            string DownloadImgPath = Path.GetFullPath(Path.Combine(_appSettings.FileLocations.OutputPath, _appSettings.FileLocations.DownloadImg));
            if (!Directory.Exists(DownloadImgPath))
            {
                Directory.CreateDirectory(DownloadImgPath);
            }
            Image imgThumb = new Bitmap(176, 134, PixelFormat.Format24bppRgb);
            MemoryStream ms = new MemoryStream();
            Bitmap b = new Bitmap(imgThumb);
            Graphics objGraphics = Graphics.FromImage(b);
            Font objFont = new Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel);
            objGraphics = Graphics.FromImage(b);
            objGraphics.Clear(Color.Orange);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString("Test Design", objFont, new SolidBrush(Color.FromArgb(000, 122, 102)), 0, 0);
            b.Save(ms, ImageFormat.Png);
            byte[] be = ms.ToArray();
            File.WriteAllBytes(DownloadImgPath + "ShopVida.png", be);

            foreach (string file in Directory.GetFiles(DownloadImgPath))
            {
                DictionaryProperties.Details["ImgFileLocation"] = file;
            }
        }

        internal void UploadPhoto()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    AutoItX.Sleep(1000);
                    AutoItX.WinWait("Open");
                    AutoItX.Sleep(1000);
                    AutoItX.WinActivate("Open");
                    AutoItX.Sleep(1000);
                    AutoItX.Send(DictionaryProperties.Details["ImgFileLocation"]);
                    AutoItX.Sleep(5000);
                    AutoItX.Send("{ENTER}");
                    AutoItX.Sleep(3000);
                    break;
                case PlatformID.Unix:
                    Console.WriteLine("I'm on Linux!");
                    break;
                default:
                    Console.WriteLine("No Idea what I'm on!");
                    break;
            }
        }

        internal void VerifyDialogueBoxpageHeader(string headingName)
        {
            if (ElementLocatorExtensions.GetElementXpath(commonHeaderDialogueBox, headingName).IsDisplayed())
            {
                Assert.AreEqual(ElementLocatorExtensions.GetElementXpath(commonHeaderDialogueBox, headingName).GetElementValue(), headingName, "Popup header name is not as expected.");
            }
        }

        internal void VerifypageHeader(string headingName)
        {
            Wait.Seconds(3);
            ElementLocatorExtensions.GetElementXpath(getCommonHeader, headingName).UntilElementIsDisplayed(new TimeSpan(0, 0, 120));
            Assert.AreEqual(ElementLocatorExtensions.GetElementXpath(getCommonHeader, headingName).GetElementValue(), headingName, "Popup header name is not as expected.");
            if (giftBoxQuantity.IsDisplayed())
            {
                DictionaryProperties.Details["GiftBoxCountBefore"] = giftBoxQuantity.GetElementValue();
            }
            else
            {
                DictionaryProperties.Details["GiftBoxCountBefore"] = "0";
            }
        }

        internal void CommonButtonClickAction(string buttonName)
        {
            if (ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).IsDisplayed())
            {
                ElementLocatorExtensions.GetElementXpath(commonButton, buttonName).ClickButton();
                CommonPage commonPage = new CommonPage(Driver, _appSettings);
                commonPage.LoadingBar();
            }
        }

        internal void SelectDateFromDatePicker(string date)
        {
            YearSelectionFromDatePicker(date);
            MonthSelectionFromDatePicker(date);
            DateSelectionFromDatePicker(date);
        }

        internal void YearSelectionFromDatePicker(string yearValue)
        {
            calenderYearSelectButton.ClickButton();
            for (int k = 0; k < calenderYearCell.GetElements().Count; k++)
            {
                bool isFileValue = false;
                foreach (IWebElement yearcell in calenderYearCell.GetElements())
                {
                    if (yearcell.Text.Equals(yearValue.Split('-')[0]))
                    {
                        isFileValue = true;
                        yearcell.ClickButton();
                        Wait.Seconds(1);
                        break;
                    }
                }
                if (!isFileValue)
                {
                    if (int.Parse(activeSelectedYear.GetElementValue()) > int.Parse(yearValue.Split('-')[0]))
                    {
                        btnPrevious.ClickButton();
                    }
                    else
                    {
                        btnNext.ClickButton();
                    }
                    continue;
                }
                break;
            }
        }

        internal void MonthSelectionFromDatePicker(string month)
        {
            calenderMonthSelectButton.ClickButton();
            string selectedMonth = getMonth(month.Split('-')[1]);
            calenderMonthCell.SelectElementFromLooping(selectedMonth).ClickButton();
            Wait.Seconds(1);
        }

        internal void DateSelectionFromDatePicker(string date)
        {
            calenderDateCell.SelectElementFromLooping(date.Split('-')[2]).ClickButton();
            Wait.Seconds(1);
        }

        public string getMonth(string inputMonth)
        {
            string selectedMonth = string.Empty;
            switch (inputMonth)
            {
                case "01":
                case "January":
                    selectedMonth = "Jan";
                    break;
                case "02":
                case "February":
                    selectedMonth = "Feb";
                    break;
                case "03":
                case "March":
                    selectedMonth = "Mar";
                    break;
                case "04":
                case "April":
                    selectedMonth = "Apr";
                    break;
                case "05":
                case "May":
                    selectedMonth = "May";
                    break;
                case "06":
                case "June":
                    selectedMonth = "Jun";
                    break;
                case "07":
                case "July":
                    selectedMonth = "Jul";
                    break;
                case "08":
                case "August":
                    selectedMonth = "Aug";
                    break;
                case "09":
                case "September":
                    selectedMonth = "Sep";
                    break;
                case "10":
                case "October":
                    selectedMonth = "Oct";
                    break;
                case "11":
                case "November":
                    selectedMonth = "Nov";
                    break;
                case "12":
                case "December":
                    selectedMonth = "Dec";
                    break;
            }
            return selectedMonth;
        }

        internal void LoadingBar()
        {
            if (loadingBar.IsDisplayed())
            {
                loadingBar.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 60));
                Wait.Seconds(1);
            }
        }

        internal void LaunchPageLoader()
        {
            if (loader.IsDisplayed())
            {
                loader.UntilElementIsNotDisplayed(new TimeSpan(0, 0, 120));
                Wait.Seconds(3);
            }
        }
    }
}