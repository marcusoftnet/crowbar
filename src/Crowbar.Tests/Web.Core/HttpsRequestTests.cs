using Crowbar.Mvc.Common;
using NUnit.Framework;

namespace Crowbar.Tests.Web.Core
{
    public class HttpsRequestTests : TestBase
    {
        [TestCase("DELETE")]
        [TestCase("GET")]
        [TestCase("POST")]
        [TestCase("PUT")]
        public void Should_be_able_to_perform_an_https_request(string method)
        {
            Application.Execute(browser =>
            {
                var response = browser.PerformRequest(method, CrowbarRoute.HttpsRequest, ctx => ctx.HttpsRequest());
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
    }
}