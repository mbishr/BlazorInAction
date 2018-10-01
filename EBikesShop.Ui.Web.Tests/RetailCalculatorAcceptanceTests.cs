using NUnit.Framework;
using System.Threading;

namespace EBikesShop.Ui.Web.Tests
{
    [TestFixture]
    public class RetailCalculatorAcceptanceTests
    {
        [OneTimeSetUp]
        public void OpenAppInBrowser()
        {
            ApplicationRunner.StartBrowser();
            ApplicationRunner.OpenRetailCalculatorPage();

            Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            ApplicationRunner.CloseBrowser();
        }

        [TestCase(2, 50.0, "UT", 106.85)]
        [TestCase(11, 2.5, "NV", 29.7)]
        [TestCase(301, 3.12, "TX", 997.815)] 
        [TestCase(99, 1.9, "AL", 195.624)]
        [TestCase(45, 19.99, "CA", 973.762875)]
        public void Can_calculate_total_price_without_discount(
            int items, decimal pricePerItem, string stateCode, decimal expectedTotalPrice)
        {
            ApplicationRunner.SetRetailCalculatorInput(items, pricePerItem, stateCode);

            ApplicationRunner.ClickRetailCalculatorCalculateTotalPrice();

            Assert.AreEqual(expectedTotalPrice, ApplicationRunner.GetRetailCalculatorTotalPrice());
        }
    }
}
