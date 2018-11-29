using NUnit.Framework;

namespace EBikesShop.Ui.Web.Tests.Acceptance
{
    [TestFixture]
    public class StateTaxesPageTests : PageTestsBase
    {
        private StateTaxesPageRunner _pageRunner;

        [OneTimeSetUp]
        public void OpenPageInBrowser()
        {
            _pageRunner = ApplicationRunner.CreateStateTaxPageRunner();
            _pageRunner.OpenStateTaxesPage();
        }

        [TestCase("UT")]
        public void Can_list_default_state_taxes(string stateCode)
        {
            Assert.IsTrue(_pageRunner.ShowsStateTax(stateCode));
        }        
    }
}
