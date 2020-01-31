namespace FrameworkTests.Utilities.Helpers
{
	using System;
	using System.Threading;
	using FrameworkTests.Hooks;
	using FrameworkTests.Utilities.Extensions;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;
	using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

	public static class Wait
	{
		public static void WaitForJsJq()
		{
			WebDriverWait WaitDriver = SeleniumExecutor.WaitDriver();
			try
			{
				WaitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return document.readyState === 'complete'"));
				WaitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return jQuery.active === 0"));
			}
			catch (Exception)
			{
				return;
			}
		}

		public static void UntilElementPresence(this By elementLocator, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d =>
				{
					try
					{
						d.FindElement(elementLocator);
						return true;
					}
					catch (NoSuchElementException)
					{
						return false;
					}
				});
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' could not be found within specified timeout limit", e);
			}
		}

		public static void UntilElementIsDisplayed(this By elementLocator, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.ElementIsVisible(elementLocator));
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't visible within specified timeout limit", e);
			}
		}

		public static void UntilElementIsDisplayed(IWebElement element, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => element.Displayed);
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element wasn't visible within specified timeout limit", e);
			}
		}

		public static void UntilElementIsEnabled(this By elementLocator, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => d.FindElement(elementLocator).Enabled);
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't enabled within specified timeout limit", e);
			}
		}

		public static void UntilElementIsEnabled(IWebElement element, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => element.Enabled);
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element wasn't enabled within specified timeout limit", e);
			}
		}

		public static void UntilElementIsClickable(this By elementLocator, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.ElementToBeClickable(elementLocator));
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' wasn't clickable within specified timeout limit", e);
			}
		}

		public static void UntilElementIsClickable(IWebElement element, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.ElementToBeClickable(element));
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element wasn't clickable within specified timeout limit", e);
			}
		}

		public static void UntilElementIsNotDisplayed(this By elementLocator, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' didn't disappear within specified timeout limit", e);
			}
		}

		public static void UntilElementIsNotDisplayed(IWebElement element, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => !element.Displayed);
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element didn't disappear within specified timeout limit", e);
			}
		}

		public static void UntilElementHasAttributesValue(By elementLocator, string attribute, string expectedValue, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => d.FindElement(elementLocator).GetAttribute(attribute).Equals(expectedValue));
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element with locator: '{elementLocator}' didn't have expected value '{expectedValue}' in '{attribute}' within specified timeout limit", e);
			}
		}

		public static void UntilElementHasAttributesValue(IWebElement element, string attribute, string expectedValue, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => element.GetAttribute(attribute).Equals(expectedValue));
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Element didn't have expected value '{expectedValue}' in '{attribute}' attribute within specified timeout limit", e);
			}
		}

		public static void UntileElementsCollectionHasSize(By elementsLocator, int size, TimeSpan? customTimeout = null)
		{
			try
			{
				SeleniumExecutor.WaitDriver(customTimeout).Until(d => elementsLocator.GetElements().Count == size);
			}
			catch (WebDriverTimeoutException e)
			{
				throw new WebDriverTimeoutException($"Elements collection didn't have expected size. Expected: {size}, Actual: {elementsLocator.GetElements().Count}", e);
			}
		}

		public static void ExplicitSleep(TimeSpan time)
		{
			Thread.Sleep(time);
		}

		public static void ExplicitWait(int seconds)
		{
			Thread.Sleep(seconds * 1000);
		}

		public static void Milliseconds(int milliseconds)
		{
			ExplicitSleep(TimeSpan.FromMilliseconds(milliseconds));
		}

		public static void Seconds(int seconds)
		{
			ExplicitSleep(TimeSpan.FromSeconds(seconds));
		}
	}
}