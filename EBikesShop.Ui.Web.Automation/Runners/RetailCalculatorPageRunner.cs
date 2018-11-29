using EBikesShop.Shared;
using EBikesShop.Ui.Web.Automation.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EBikesShop.Ui.Web.Automation.Runners
{
    public class RetailCalculatorPageRunner
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

        public void OpenRetailCalculatorPage()
        {
            _driver.Url = $"{_settings.BaseUrl}/retailcalculator";

            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);
        }

        public void SetRetailCalculatorInput(int items, decimal pricePerItem, string stateCode)
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

        public void ClickRetailCalculatorCalculateTotalPrice()
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_calculateTotalPrice_button"));
            element.Click();
        }

        public decimal GetRetailCalculatorTotalPrice()
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_totalPrice_text"));
            string text = element.Text;

            return decimal.Parse(text);
        }
    }
}