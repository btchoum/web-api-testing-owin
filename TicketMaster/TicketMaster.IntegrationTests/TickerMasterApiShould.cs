using NUnit.Framework;
using System.Net.Http;

namespace TicketMaster.IntegrationTests
{
    [TestFixture]
    public class TickerMasterApiShould : BaseApiTests
    {
        [Test]
        public void Get_should_be_successfull()
        {
            var response = HttpClient.GetAsync("api/todos").Result;

            Assert.IsTrue(response.IsSuccessStatusCode, "Actual Status Code " + response.StatusCode);
        }

    }
}
