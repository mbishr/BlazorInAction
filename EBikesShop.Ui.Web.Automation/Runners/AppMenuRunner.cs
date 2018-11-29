using EBikesShop.Shared;
using EBikesShop.Ui.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace EBikesShop.Ui.Web.Automation.Runners
{
    public class AppMenuRunner
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

        public void OpenDefaultPage()
        {
            _driver.Url = $"{_settings.BaseUrl}";

            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);
        }

        public void ClickRetailCalculatorNavLink()
        {
            _driver.FindElement(By.XPath("//*[@id='retailCalculatorNavLink']"))
                .Click();

            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);
        }    

        public bool ShowsRetailCalculatorPageContent()
        {
            var element = _driver.FindElement(By.XPath("//div[@id='retailCalculatorPage_container']"));

            return element != null;
        }

        public void ClickStateTaxesNavLink()
        {
            _driver.FindElement(By.XPath("//*[@id='stateTaxesNavLink']"))
                .Click();
                
            _busyIndicatorLocator.WaitToBecomeInvisible(_driver);            
        }
        
        public bool ShowsStateTaxesPageContent()
        {
            var element = _driver.FindElement(By.XPath("//table[@id='stateTaxes_table']"));

            return element != null;
        }
    }
}