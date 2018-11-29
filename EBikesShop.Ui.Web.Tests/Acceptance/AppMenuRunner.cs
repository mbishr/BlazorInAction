using System;
using EBikesShop.Shared;
using OpenQA.Selenium;

namespace EBikesShop.Ui.Web.Tests.Acceptance
{
    internal class AppMenuRunner
    {
        // TODO: extract busy indicator as a separate control 
        private By _busyIndicatorLocator = By.XPath("//*[text()='Loading...']");

        private readonly IWebDriver _driver;
        private readonly AppSettings _settings;

        public AppMenuRunner(IWebDriver driver, AppSettings appSettings)
        {
            _driver = driver;
            _settings = appSettings;
        }

        internal void OpenDefaultPage()
        {
            _driver.Url = $"{_settings.BaseUrl}";

            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);
        }

        internal void ClickRetailCalculatorNavLink()
        {
            _driver.FindElement(By.XPath("//*[@id='retailCalculatorNavLink']"))
                .Click();
        }    

        internal bool ShowsRetailCalculatorPageContent()
        {
            var element = _driver.FindElement(By.XPath("//div[@id='retailCalculatorPage_container']"));

            return element != null;
        }

        internal void ClickStateTaxesNavLink()
        {
            _driver.FindElement(By.XPath("//*[@id='stateTaxesNavLink']"))
                .Click();
        }
        
        internal bool ShowsStateTaxesPageContent()
        {
            var element = _driver.FindElement(By.XPath("//table[@id='stateTaxes_table']"));

            return element != null;
        }
    }
}