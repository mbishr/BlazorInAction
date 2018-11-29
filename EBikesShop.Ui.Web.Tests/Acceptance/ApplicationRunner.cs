using EBikesShop.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace EBikesShop.Ui.Web.Tests.Acceptance
{
    internal class ApplicationRunner
    {
        private static readonly AppSettings _settings = new AppSettings();

        private static IWebDriver _driver;

        internal static void StartBrowser()
        {
            // Azure DevOps Hosted VS2017 environment has this variable set
            var baseDir = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (string.IsNullOrWhiteSpace(baseDir))
            {
                baseDir = Path.GetDirectoryName(typeof(ApplicationRunner).Assembly.Location);
            }

            _driver = new ChromeDriver(baseDir);
        }

        internal static void OpenRetailCalculatorPage()
        {
            _driver.Url = $"{_settings.BaseUrl}/retailcalculator";
        }

        internal static void CloseBrowser()
        {
            _driver.Quit();
        }

        internal static void SetRetailCalculatorInput(int items, decimal pricePerItem, string stateCode)
        {
            SetRetailCalculatorItemsInput(items.ToString());
            SetRetailCalculatorPricePerItemInput(pricePerItem.ToString());
            SelectRetailCalculatorStateCode(stateCode);
        }

        private static void SetRetailCalculatorItemsInput(string items)
        {
            Thread.Sleep(1000);
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_numberOfItems_input"));
            element.Clear();
            element.SendKeys(items);
        }

        public static bool ShowsStateTax(string stateCode)
        {
            Thread.Sleep(1000);
            var row = _driver.FindElement(By.XPath($"//table[@id='stateTaxes_table']//tr[td[text()='{stateCode}']]"));
            return row != null;
        }

        public static void OpenStateTaxesPage()
        {
            _driver.Url = $"{_settings.BaseUrl}/statetaxes";
        }

        private static void SetRetailCalculatorPricePerItemInput(string pricePerItem)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_pricePerItem_input"));
            element.Clear();
            element.SendKeys(pricePerItem);
        }

        private static void SelectRetailCalculatorStateCode(string stateCode)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_state_select"));
            SelectElement select = new SelectElement(element);
            select.SelectByText(stateCode);
        }

        internal static void ClickRetailCalculatorCalculateTotalPrice()
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_calculateTotalPrice_button"));
            element.Click();
        }

        internal static decimal GetRetailCalculatorTotalPrice()
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_totalPrice_text"));
            string text = element.Text;

            return decimal.Parse(text);
        }
    }
}