using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
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
        [Test]
        public void CanGetFilters()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Filters.Filters("!masJQxPJAU");
            Assert.Greater(response.Items.Count, 0);

        }
    }
}