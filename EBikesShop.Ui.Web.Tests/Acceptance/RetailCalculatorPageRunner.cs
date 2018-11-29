using EBikesShop.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace EBikesShop.Ui.Web.Tests.Acceptance
{
    internal class RetailCalculatorPageRunner
    {       
        // TODO: extract busy indicator as a separate control 
        private By _busyIndicatorLocator = By.XPath("//*[text()='Loading...']");
 
        private readonly IWebDriver _driver;
        private readonly AppSettings _settings;

        public RetailCalculatorPageRunner(IWebDriver driver, AppSettings appSettings)
        {
            _driver = driver;
            _settings = appSettings;
        }

        internal void OpenRetailCalculatorPage()
        {
            _driver.Url = $"{_settings.BaseUrl}/retailcalculator";

            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);
        }

        internal void SetRetailCalculatorInput(int items, decimal pricePerItem, string stateCode)
        {
            SetRetailCalculatorItemsInput(items.ToString());
            SetRetailCalculatorPricePerItemInput(pricePerItem.ToString());
            SelectRetailCalculatorStateCode(stateCode);
        }

        private void SetRetailCalculatorItemsInput(string items)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_numberOfItems_input"));
            element.Clear();
            element.SendKeys(items);
        }

        private void SetRetailCalculatorPricePerItemInput(string pricePerItem)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_pricePerItem_input"));
            element.Clear();
            element.SendKeys(pricePerItem);
        }

        private void SelectRetailCalculatorStateCode(string stateCode)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_state_select"));
            SelectElement select = new SelectElement(element);
            select.SelectByText(stateCode);
        }

        internal void ClickRetailCalculatorCalculateTotalPrice()
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_calculateTotalPrice_button"));
            element.Click();
        }

        internal decimal GetRetailCalculatorTotalPrice()
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_totalPrice_text"));
            string text = element.Text;

            return decimal.Parse(text);
        }
    }
}