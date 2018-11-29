using EBikesShop.Ui.Web.Tests.Runners;
using NUnit.Framework;

namespace EBikesShop.Ui.Web.Tests.Acceptance
{
    [TestFixture]
    public class NavigationTests : PageTestsBase
    {
        private AppMenuRunner _runner;

        [OneTimeSetUp]
        public void OpenPageInBrowser()
        {
            _runner = ApplicationRunner.CreateAppMenuRunner();
            _runner.OpenDefaultPage();
        }

        [Test]
        public void Can_navigate_to_RetailCalculator_page()
        {
            _runner.ClickRetailCalculatorNavLink();

            Assert.IsTrue(_runner.ShowsRetailCalculatorPageContent());
        }

        [Test]
        public void Can_navigate_to_StateTaxes_page()
        {
            _runner.ClickStateTaxesNavLink();

            Assert.IsTrue(_runner.ShowsStateTaxesPageContent());
        }
    }
}
