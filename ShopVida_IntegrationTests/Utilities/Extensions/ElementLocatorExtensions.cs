namespace FrameworkTests.Utilities.Extensions
{
    using FrameworkTests.Utilities.Helpers;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class ElementLocatorExtensions
    {
        public static RemoteWebDriver Driver;

        public static IWebElement elementFound;

        public static bool CaseInsensitiveContains(this string text, string value,
              StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        public static WebDriverWait WaitDriver(TimeSpan? customTimeout = null)
        {
            var ExplicitSleepTimeout = customTimeout ?? TimeSpan.FromSeconds(10);
            return new WebDriverWait(SeleniumReporter.Driver, ExplicitSleepTimeout);
        }

        public static IWebElement GetElement(this By elementLocator)
        {
            return SeleniumReporter.Driver.FindElement(elementLocator);
        }

        public static IList<IWebElement> GetElements(this By elementLocator)
        {
            return SeleniumReporter.Driver.FindElements(elementLocator);
        }

        public static void Click(this By elementLocator)
        {
            elementLocator.GetElement().Click();
        }

        public static void DoubleClick(this By elementLocator)
        {
            elementLocator.GetElement().DoubleClick();
        }

        public static By GetElementXpath(this string elementLocator, string element)
        {
            return By.XPath(string.Format(elementLocator, element));
        }

        public static By GetElementXpath(this string elementLocator, string element1, string element2)
        {
            return By.XPath(string.Format(elementLocator, element1, element2));
        }

        public static void ClearData(this By element)
        {
            element.GetElement().Clear();
        }

        public static void InputKey(this By element, string input)
        {
            element.ClearData();
            int textLength = element.GetElementValueByAttribute("value").Length;
            while (textLength > 0)
            {
                textLength--;
                element.SendKeys(Keys.Backspace);
            }
            for (int i = 0; i < input.Length; i++)
            {
                element.GetElement().SendKeys(input[i].ToString());
            }
        }

        public static void InputKeyWithWait(this By element, string input)
        {
            Wait.UntilElementIsDisplayed(element);
            element.ClearData();
            for (int i = 0; i < input.Length; i++)
            {
                element.GetElement().SendKeys(input[i].ToString());
            }
        }

        public static void ClickButton(this By element)
        {
            Assert.IsTrue(element.GetElement().Enabled, $"Button '{element}' is disabled", element.GetElement());
            SeleniumReporter.Driver.ExecuteScript("arguments[0].click();", element.GetElement());
        }

        public static void ClickButton(this IWebElement element)
        {
            Assert.IsTrue(element.Enabled, string.Format("Button {0} is disabled", element));
            SeleniumReporter.Driver.ExecuteScript("arguments[0].click();", element);
        }

        public static void DoubleClick(this IWebElement elementToBeClick)
        {
            new Actions(SeleniumReporter.Driver).DoubleClick(elementToBeClick).Perform();
        }

        public static bool IsDisplayed(this By elementLocator)
        {
            try
            {
                var element = elementLocator.GetElement();
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this By elementLocator, IWebElement parentElement)
        {
            try
            {
                var element = parentElement.FindElement(elementLocator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this By elementLocator, By parentElement)
        {
            try
            {
                var parent = parentElement.GetElement();
                var element = parent.FindElement(elementLocator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayedAfterWait(this By elementLocator)
        {
            try
            {
                Wait.UntilElementIsDisplayed(elementLocator);
                return elementLocator.GetElement().Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool IsEnabled(this By elementLocator)
        {
            try
            {
                var element = elementLocator.GetElement();
                return element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static IWebElement SelectElementFromLooping(this By listOfElement, string stringToBeFound)
        {
            foreach (IWebElement element in listOfElement.GetElements())
            {
                if (element.Text.Trim().CaseInsensitiveContains(stringToBeFound))
                {
                    elementFound = element;
                    break;
                }
            }
            return elementFound;
        }

        public static void SelectElementFromLoopingAndClick(this By listOfElement, string stringToBeFound)
        {
            foreach (IWebElement element in listOfElement.GetElements())
            {
                if (element.Text.Trim().Equals(stringToBeFound))
                {
                    element.ClickButton();
                    Wait.Seconds(1);
                    break;
                }
            }
        }

        public static void SelectedListClick(this By listOfElement, string stringToBeFound)
        {
            var result = listOfElement.SelectElementFromLooping(stringToBeFound);
            Assert.NotNull(result);
            result.Click();
        }

        public static void DropDownSelectionByText(this By elementLocator, string text)
        {
            SelectElement elementSelection = new SelectElement(elementLocator.GetElement());
            elementSelection.SelectByText(text);
        }

        public static void DropDownSelectionByIndex(this By element, int valueByIndex)
        {
            SelectElement elementSelection = new SelectElement(element.GetElement());
            elementSelection.SelectByIndex(valueByIndex);
        }

        public static void DropDownSelectionByValue(this By element, string value)
        {
            SelectElement elementSelection = new SelectElement(element.GetElement());
            elementSelection.SelectByValue(value);
        }

        public static string FetchingDropDownSelectedValue(this By elementLocator)
        {
            SelectElement selectElement = new SelectElement(elementLocator.GetElement());
            return selectElement.SelectedOption.Text;
        }

        public static void SelectText(this By elementLocator, string text)
        {
            var select = elementLocator.GetSelectElement();
            select.SelectByText(text);
        }

        public static void SelectIndex(this By elementLocator, int index)
        {
            var select = elementLocator.GetSelectElement();
            select.SelectByIndex(index);
        }

        public static void SelectValue(this By elementLocator, string value)
        {
            var select = elementLocator.GetSelectElement();
            select.SelectByValue(value);
        }

        public static SelectElement GetSelectElement(this By elementLocator)
        {
            return new SelectElement(elementLocator.GetElementWithWait());
        }

        public static string GetElementValue(this By element)
        {
            return element.GetElement().Text;
        }

        public static void BlankValue(this By element)
        {
            int textLength = element.GetElementValueByAttribute("value").Length;
            while (textLength > 0)
            {
                textLength--;
                element.SendKeys(Keys.Backspace);
            }
        }

        public static void Scrolldown()
        {
            SeleniumReporter.Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void ScrollDown(this IWebElement element)
        {
            SeleniumReporter.Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Wait.Seconds(1);
        }

        public static void ScrollUp(this IWebElement element)
        {
            SeleniumReporter.Driver.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public static void Scrollup()
        {
            SeleniumReporter.Driver.ExecuteScript("window.scrollTo(Math.max(document.documentElement.scrollHeight,document.body.scrollHeight,document.documentElement.clientHeight),0);");
        }

        public static void Compare(string actual, string expected)
        {
            Assert.AreEqual(actual, expected);
        }

        public static string[] SplitValue(this string valueToBeSpit, string[] charcterToBeSplit)
        {
            return valueToBeSpit.Split(charcterToBeSplit, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IWebElement GetElement(this By elementLocator, By parentElement)
        {
            return SeleniumReporter.Driver.FindElement(parentElement).FindElement(elementLocator);
        }

        public static IWebElement GetElement(this By elementLocator, IWebElement parentElement)
        {
            return parentElement.FindElement(elementLocator);
        }

        public static IWebElement GetElementWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementPresence(elementLocator, customTimeout);
            return elementLocator.GetElement();
        }

        public static IWebElement GetElementWithWait(this By elementLocator, By parentElement, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementPresence(parentElement, customTimeout);
            return elementLocator.GetElement(parentElement);
        }

        public static IWebElement GetElementWithWait(this By elementLocator, IWebElement parentElement, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(parentElement, customTimeout);
            return elementLocator.GetElement(parentElement);
        }

        public static IList<IWebElement> GetElements(this By elementLocator, By parentElement)
        {
            var parent = parentElement.GetElement();
            return parent.FindElements(elementLocator);
        }

        public static IList<IWebElement> GetElements(this By elementLocator, IWebElement parentElement)
        {
            return parentElement.FindElements(elementLocator);
        }

        public static void ClickWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(elementLocator, customTimeout);
            elementLocator.Click();
        }

        public static void ClearWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(elementLocator, customTimeout);
            elementLocator.ClearData();
        }

        public static void ClearByBackspace(this By elementLocator)
        {
            elementLocator.GetElement().ClearDataByBackspace();
        }

        public static void ClearDataByBackspace(this IWebElement element)
        {
            element.SendKeys(Keys.End);
            while (element.GetAttribute("value").Length > 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        public static void JsClick(this By elementLocator)
        {
            elementLocator.GetElement().ClickJs();
        }
        public static void ClickJs(this IWebElement element)
        {
            SeleniumReporter.JavaScriptExecutor.ExecuteScript("var el=arguments[0]; setTimeout(function() { el.click(); }, 200);", element);
        }

        public static void JsClickWithWait(this By elementLocator, TimeSpan? customTimeout = null)
        {
            elementLocator.GetElementWithWait(customTimeout).ClickJs();
        }

        public static void SendKeys(this By elementLocator, string text)
        {
            elementLocator.GetElement().SendKeys(text);
        }

        public static void SendKeysWithWait(this By elementLocator, string text, TimeSpan? customTimeout = null)
        {
            Wait.UntilElementIsDisplayed(elementLocator, customTimeout);
            elementLocator.SendKeys(text);
        }

        public static void SendKeysWithWait(this IWebElement elementLocator, string text)
        {
            Wait.UntilElementIsDisplayed(elementLocator);
            elementLocator.SendKeys(text);
        }

        public static void SendKeysWithClear(this By elementLocator, string text)
        {
            elementLocator.ClearData();
            elementLocator.SendKeys(text);
        }

        public static void SendKeysWithClear(this IWebElement elementLocator, string text)
        {
            elementLocator.Clear();
            elementLocator.SendKeys(text);
        }

        public static void ClearAndSendKeysWithWait(this By elementLocator, string text, TimeSpan? customTimeout = null)
        {
            elementLocator.ClearWithWait(customTimeout);
            elementLocator.SendKeysWithWait(text, customTimeout);
        }

        public static string GetElementValueByAttribute(this IWebElement elementLocator, string attributeName)
        {
            return elementLocator.GetAttribute(attributeName);
        }

        public static string FetchingDropDownSelectedValueByAttribute(this By element, string attributeValue)
        {
            SelectElement selectElement = new SelectElement(element.GetElement());
            return GetElementValueByAttribute(selectElement.SelectedOption, attributeValue);
        }

        public static string GetElementValueByAttribute(this By elementLocator, string attributeName)
        {
            return elementLocator.GetElement().GetAttribute(attributeName);
        }

        public static string GetAttributeWithWait(this By elementLocator, string attribute, TimeSpan? customTimeout = null)
        {
            return elementLocator.GetElementWithWait(customTimeout).GetAttribute(attribute);
        }

        public static string GetCssValue(this By elementLocator, string propertyName)
        {
            return elementLocator.GetElement().GetCssValue(propertyName);
        }

        public static string GetCssValueWithWait(this By elementLocator, string propertyName, TimeSpan? customTimeout = null)
        {
            return elementLocator.GetElementWithWait(customTimeout).GetCssValue(propertyName);
        }

        public static string GetProperty(this By elementLocator, string propertyName)
        {
            return elementLocator.GetElement().GetProperty(propertyName);
        }

        public static string GetPropertyWithWait(this By elementLocator, string propertyName, TimeSpan? customTimeout = null)
        {
            return elementLocator.GetElementWithWait(customTimeout).GetProperty(propertyName);
        }

        public static string Text(this By elementLocator)
        {
            return elementLocator.GetElement().Text;
        }

        public static string Text(this By elementLocator, IWebElement parentElement)
        {
            return elementLocator.GetElement(parentElement).Text;
        }

        public static string Text(this By elementLocator, By parentElement)
        {
            return elementLocator.GetElement(parentElement).Text;
        }

        public static string TagName(this By elementLocator)
        {
            return elementLocator.GetElement().TagName;
        }

        public static string TagName(this By elementLocator, IWebElement parentElement)
        {
            return elementLocator.GetElement(parentElement).TagName;
        }

        public static string TagName(this By elementLocator, By parentElement)
        {
            return elementLocator.GetElement(parentElement).TagName;
        }

        public static bool IsSelected(this By elementLocalization)
        {
            return elementLocalization.GetElementWithWait().Selected;
        }

        public static Point Location(this By elementLocator)
        {
            return elementLocator.GetElementWithWait().Location;
        }

        public static Size Size(this By elementLocator)
        {
            return elementLocator.GetElementWithWait().Size;
        }

        public static void HoverOverElement(this By elementLocator)
        {
            elementLocator.GetElement().HoverOverElement();
        }

        public static void HoverOverElement(this IWebElement element)
        {
            var action = SeleniumReporter.Actions;
            action.MoveToElement(element).Perform();
        }

        public static IWebElement GetParentElement(this By elementLocator)
        {
            var element = elementLocator.GetElement();
            return element.GetParentElem();
        }

        public static IWebElement GetParentElem(this IWebElement element)
        {
            return element.FindElement(By.XPath("./.."));
        }

        public static void DragAndDrop(IWebElement source, IWebElement target)
        {
            var action = SeleniumReporter.Actions;
            action.DragAndDrop(source, target).Perform();
        }

        public static void ClickAndHold(this IWebElement source)
        {
            var action = SeleniumReporter.Actions;
            action.ClickAndHold(source).Perform();
        }

        public static void SetCheckbox(this By elementLocator, bool selected)
        {
            var element = elementLocator.GetElement();
            if ((selected && !element.Selected) || (!selected && element.Selected))
            {
                element.Click();
            }
        }
    }
}
