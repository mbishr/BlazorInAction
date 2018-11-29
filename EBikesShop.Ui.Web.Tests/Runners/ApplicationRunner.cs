using EBikesShop.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace EBikesShop.Ui.Web.Tests.Runners
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

        internal static void CloseBrowser()
        {
            _driver.Quit();
        }

        internal static AppMenuRunner CreateAppMenuRunner()
        {
            return new AppMenuRunner(_driver, _settings);
        }

        internal static RetailCalculatorPageRunner CreateRetailCalculatorPageRunner()
        {
            return new RetailCalculatorPageRunner(_driver, _settings);
        }

        internal static StateTaxesPageRunner CreateStateTaxPageRunner()
        {
            return new StateTaxesPageRunner(_driver, _settings);
        }
    }
}