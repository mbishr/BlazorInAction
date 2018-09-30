using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace EBikesShop.Ui.Web.Tests
{
    internal class ApplicationRunner
    {
        private static readonly string BaseUrl = "http://localhost:50655";

        private static IWebDriver _driver;

        internal static void StartBrowser()
        {
            var baseDir = Path.GetDirectoryName((typeof(ApplicationRunner)).Assembly.Location);
            _driver = new ChromeDriver(baseDir);
        }

        internal static void OpenRetailCalculatorPage()
        {
            _driver.Url = BaseUrl + "/counter";
        }

        internal static void CloseBrowser()
        {
            _driver.Quit();
        }

        internal static void SetRetailCalculatorInput(int items, decimal pricePerItem, string stateCode)
        {
            SetRetailCalculatorItemsInput(items.ToString());
            SetRetailCalculatorPricePerItemInput(pricePerItem.ToString());
            SetRetailCalculatorStateCodeInput(stateCode);
        }

        private static void SetRetailCalculatorItemsInput(string items)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_numberOfItems_input"));
            element.Clear();
            element.SendKeys(items);
        }

        private static void SetRetailCalculatorPricePerItemInput(string pricePerItem)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_pricePerItem_input"));
            element.Clear();
            element.SendKeys(pricePerItem);
        }

        private static void SetRetailCalculatorStateCodeInput(string stateCode)
        {
            IWebElement element = _driver.FindElement(By.Id("retailCalculator_stateCode_input"));
            element.Clear();
            element.SendKeys(stateCode);
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