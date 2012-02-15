using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class SitesFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetSites()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Sites.Sites(null, null);
            Assert.Greater(response.Items.Count, 0);
        }
    }
}