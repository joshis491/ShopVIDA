namespace FrameworkTests.Utilities
{
    using FrameworkTests.Utilities.Extensions;
	using FrameworkTests.Utilities.Helpers;
	using OpenQA.Selenium;
	using System.Collections.ObjectModel;
	using System.Threading;

	public static class Browser
	{
		public static void GoToUrl(string url)
		{
			SeleniumReporter.Driver.Navigate().GoToUrl(url);
		}
		public static void RefreshPage()
		{
			SeleniumReporter.Driver.Navigate().Refresh();
		}
		public static void WindowMaximize()
		{
			SeleniumReporter.Driver.Manage().Window.Maximize();
		}
		public static void NavigateBack()
		{
			SeleniumReporter.Driver.Navigate().Back();
		}
		public static void NavigateForward()
		{
			SeleniumReporter.Driver.Navigate().Forward();
		}
		public static string GetCurrentUrl()
		{
			return SeleniumReporter.Driver.Url;
		}
		public static string GetTitle()
		{
			return SeleniumReporter.Driver.Title;
		}
		public static void AddCookie(Cookie cookie)
		{
			SeleniumReporter.Driver.Manage().Cookies.AddCookie(cookie);
		}
		public static void DeleteCookie(Cookie cookie)
		{
			SeleniumReporter.Driver.Manage().Cookies.DeleteCookie(cookie);
		}
		public static void DeleteCookies()
		{
			SeleniumReporter.Driver.Manage().Cookies.DeleteAllCookies();
		}
		public static void SwitchToWindowHandle(int window)
		{
			var windowHandles = GetWindowHandles();
			SeleniumReporter.Driver.SwitchTo().Window(windowHandles[window]);
		}
		public static void SwitchToFrame(IWebElement frame)
		{
			SeleniumReporter.Driver.SwitchTo().Frame(frame);
		}
		public static void SwitchToDefaultContent()
		{
			SeleniumReporter.Driver.SwitchTo().DefaultContent();
		}
		public static IAlert SwitchToAlert()
		{
			return SeleniumReporter.Driver.SwitchTo().Alert();
		}
		public static void SwitchToActiveElement()
		{
			SeleniumReporter.Driver.SwitchTo().ActiveElement();
		}
		public static ReadOnlyCollection<string> GetWindowHandles()
		{
			return SeleniumReporter.Driver.WindowHandles;
		}
		public static void AcceptAlert()
		{
			if (IsAlertPresent())
			{
				var alert = SwitchToAlert();
				alert.Accept();
				Wait(1);
			}
		}
		public static void Wait(int timeToWaitInSec)
		{
			Thread.Sleep(timeToWaitInSec * 1000);
		}
		public static void DismissAlert()
		{
			if (IsAlertPresent())
			{
				var alert = SwitchToAlert();
				alert.Dismiss();
				Wait(1);
			}
		}

		public static void ScrollIntoView(IWebElement element)
		{
			SeleniumReporter.Driver.ExecuteScript("arguments[0].scrollIntoView();", element);
		}

		public static void ScrollIntoView(By elementLocator)
		{
			var element = elementLocator.GetElement();
			ScrollIntoView(element);
		}

		private static bool IsAlertPresent()
		{
			try
			{
				SwitchToAlert();
				return true;
			}
			catch (NoAlertPresentException)
			{
				return false;
			}
			catch (NoSuchWindowException)
			{
				return false;
			}
			catch (WebDriverException)
			{
				return false;
			}
		}
    }
}