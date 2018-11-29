using EBikesShop.Ui.Web.Automation.Runners;
using NUnit.Framework;

namespace EBikesShop.Ui.Web.Tests.Acceptance
{
    [TestFixture]
    public class RetailCalculatorPageTests : PageTestsBase
    {
        private RetailCalculatorPageRunner _pageRunner;

        [OneTimeSetUp]
        public void OpenPageInBrowser()
        {
            _pageRunner = ApplicationRunner.CreateRetailCalculatorPageRunner();
            _pageRunner.OpenRetailCalculatorPage();
        }

        // without discount
        [TestCase(2, 50.0, "UT", 106.85)]
        [TestCase(11, 2.5, "NV", 29.7)]
        [TestCase(301, 3.12, "TX", 997.815)] 
        [TestCase(99, 1.9, "AL", 195.624)]
        [TestCase(45, 19.99, "CA", 973.762875)]
        // with discount applied before taxes
        [TestCase(1, 1000, "UT", 1036.445)] // 3%
        [TestCase(2, 2500, "NV", 5130)] // 5%
        [TestCase(10, 700, "TX", 6916.875)] // 7%
        [TestCase(100, 100, "AL", 9360)] // 10%
        [TestCase(5000, 10, "CA", 46006.25)] // 15%
        public void Can_calculate_total_price(
            int items, decimal pricePerItem, string stateCode, decimal expectedTotalPrice)
        {
            _pageRunner.SetRetailCalculatorInput(items, pricePerItem, stateCode);

            _pageRunner.ClickRetailCalculatorCalculateTotalPrice();

            Assert.AreEqual(expectedTotalPrice, _pageRunner.GetRetailCalculatorTotalPrice());
        }
    }
}
