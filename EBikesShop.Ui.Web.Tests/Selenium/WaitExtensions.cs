using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace EBikesShop.Ui.Web.Tests.Selenium
{
    public static class WaitExtensions
    {
        public static void WaitToBecomeAvailable(this By locator, IWebDriver driver)
        {
            var wait = CreateWait(driver);
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static void WaitToBecomeClickable(this By locator, IWebDriver driver)
        {
            var wait = CreateWait(driver);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitToBecomeVisible(this By locator, IWebDriver driver)
        {
            var wait = CreateWait(driver);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitToBecomeInvisible(this By locator, IWebDriver driver)
        {
            var wait = CreateWait(driver);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        private static OpenQA.Selenium.Support.UI.WebDriverWait CreateWait(IWebDriver driver)
        {
            return new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
        }
    }
}