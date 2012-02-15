using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class SearchFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanGetSearch()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Search.Search("stackoverflow", null, null, null, null, null, null, null, null, null, null, "jquery");
            Assert.Greater(response.Items.Count, 0);
        }
        [Test]
        public void CanGetSimilar()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Search.Similar("stackoverflow", null, null, null, null, null, null, null, null, null, null, "Why is subtracting these two times (in 1927) giving a strange result");
            Assert.Greater(response.Items.Count, 0);
        }
    }
}