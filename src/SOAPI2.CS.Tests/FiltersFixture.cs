using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture, Ignore("// #TODO: implement per-method request content type")]
    public class FiltersFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanCreateFilters()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Filters.FiltersCreate(".total;question.body", null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }
    }
}