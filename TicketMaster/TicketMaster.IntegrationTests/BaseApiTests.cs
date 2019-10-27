using NUnit.Framework;
using System;
using System.Net.Http;

namespace TicketMaster.IntegrationTests
{
    public class BaseApiTests
    {
        protected HttpClient HttpClient;
        protected IDisposable WebApp;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var _baseAddress = "http://localhost:9000/";

            Microsoft.Owin.Hosting.WebApp.Start<Startup>(url: _baseAddress);

            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            HttpClient = new HttpClient(handler) { BaseAddress = new Uri(_baseAddress) };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (HttpClient != null)
            {
                HttpClient.Dispose();
                HttpClient = null;
            }

            if (WebApp != null)
            {
                WebApp.Dispose();
                WebApp = null;
            }
        }
    }
}