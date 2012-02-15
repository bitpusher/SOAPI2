using Newtonsoft.Json;
using NUnit.Framework;
using SOAPI2.Model;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class VariousFixture:FixtureBase
    {
        [Test]
        public void DeserializeRelatedSites()
        {
            var json = "{    \"name\": \"SharePoint Meta\",    \"site_url\": \"http://meta.sharepoint.stackexchange.com\",    \"relation\": \"meta\",    \"api_site_parameter\": \"meta.sharepoint\" }";
            var site = JsonConvert.DeserializeObject<RelatedSiteClass>(json);
            json = "{\"name\": \"Chat Stack Exchange\",\"site_url\": \"http://chat.stackexchange.com\",\"relation\": \"chat\"}";
            site = JsonConvert.DeserializeObject<RelatedSiteClass>(json);
        }
    }
}