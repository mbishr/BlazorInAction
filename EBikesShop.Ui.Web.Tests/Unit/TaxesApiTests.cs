﻿using EBikesShop.Shared.Taxes;
using EBikesShop.Ui.Web.Apis;
using Flurl.Http.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EBikesShop.Ui.Web.Tests.Unit
{
    [TestFixture]
    public class TaxesApiTests
    {
        private HttpTest _httpTest;

        [SetUp]
        public void InitializeHttp()
        {
            _httpTest = new HttpTest();
        }

        [TearDown]
        public void DisposeHttp()
        {
            _httpTest.Dispose();
        }

        [Test]
        public async Task GetStateTaxesAsync_calls_the_server_api()
        {
            var sut = new TaxesApi();
            _httpTest.RespondWith("[]");
                
            await sut.GetStateTaxesAsync();
                
            _httpTest.ShouldHaveCalled(sut.ApiBaseUrl + "/taxes")
                .WithVerb(HttpMethod.Get)
                .WithHeader("Accept", "application/json");
        }

        [Test]
        public async Task GetStateTaxesAsync_deserializes_json()
        {
            var sut = new TaxesApi();
            var expected = new StateTaxDto[] 
            {
                new StateTaxDto { StateCode = "UT", TaxRate = 6.85m },
                new StateTaxDto { StateCode = "CA", TaxRate = 8.00m },
            };
            _httpTest.RespondWith(JsonConvert.SerializeObject(expected));

            var received = await sut.GetStateTaxesAsync();

            Assert.That(received, Has.All.Matches<StateTaxDto>(r =>
                expected.Any(e => r.TaxRate == e.TaxRate && r.StateCode == e.StateCode)));
        }
    }
}
