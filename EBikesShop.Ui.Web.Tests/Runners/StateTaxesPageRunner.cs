using EBikesShop.Shared;
using EBikesShop.Ui.Web.Tests.Selenium;
using OpenQA.Selenium;

namespace EBikesShop.Ui.Web.Tests.Runners
{
    internal class StateTaxesPageRunner
    {
        // TODO: extract busy indicator as a separate control 
        private By _busyIndicatorLocator = By.XPath("//*[text()='Loading...']");

        private readonly IWebDriver _driver;
        private readonly AppSettings _settings;

        public StateTaxesPageRunner(IWebDriver driver, AppSettings appSettings)
        {
            _driver = driver;
            _settings = appSettings;
        }

        internal void OpenStateTaxesPage()
        {
            _driver.Url = $"{_settings.BaseUrl}/statetaxes";

            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);
        }

        internal bool ShowsStateTax(string stateCode)
        {
            var row = _driver.FindElement(By.XPath($"//table[@id='stateTaxes_table']//tr[td[text()='{stateCode}']]"));
            
            return row != null;
        }
    }
}