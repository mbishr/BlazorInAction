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

        [Test]
        public void Can_calculate_total_price_for_UT_without_discount()
        {
            ApplicationRunner.SetRetailCalculatorInput(2, 50.0m, "UT");

            ApplicationRunner.ClickRetailCalculatorCalculateTotalPrice();

            Assert.AreEqual(106.85m, ApplicationRunner.GetRetailCalculatorTotalPrice());
        }
    }
}
