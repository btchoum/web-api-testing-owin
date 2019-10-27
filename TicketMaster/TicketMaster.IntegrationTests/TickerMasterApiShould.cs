using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace TicketMaster.IntegrationTests
{
    [TestFixture]
    public class TickerMasterApiShould
    {
        private HttpClient _httpClient;
        private IDisposable _webApp;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var _baseAddress = "http://localhost:9000/";
            
            WebApp.Start<Startup>(url: _baseAddress);

            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(_baseAddress) };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
                _httpClient = null;
            }

            if (_webApp != null)
            {
                _webApp.Dispose();
                _webApp = null;
            }
        }


        [Test]
        public void Get_should_be_successfull()
        {
            var response = _httpClient.GetAsync("api/todos").Result;

            Assert.IsTrue(response.IsSuccessStatusCode, "Actual Status Code " + response.StatusCode);
        }

        [Test]
        public void Get_should_be_successfull_owin_selfhost()
        {
            var response = _httpClient.GetAsync("api/todos").Result;

            Assert.IsTrue(response.IsSuccessStatusCode, "Actual Status Code " + response.StatusCode);
        }
    }
}
