using NUnit.Framework;
using SOAPI2.Model;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class TagsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetTags()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.Tags("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);

        }



        [Test]
        public void CanGetTagsByTagsFaq()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagsFaq("stackoverflow", null, null, "asp.net");
            Assert.Greater(response.Items.Count, 0);

        }

        [Test]
        public void CanGetTagsByTagsInfo()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagsInfo("stackoverflow", null, null, null, null, null, null, null, null, "asp.net");
            Assert.Greater(response.Items.Count, 0);

        }

        [Test]
        public void CanGetTagsByTagsRelated()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagsRelated("stackoverflow", null, null, "asp.net");
            Assert.Greater(response.Items.Count, 0);

        }

        [Test]
        public void CanGetTagsByTagsSynonyms()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagsSynonyms("stackoverflow", null, null, null, null, null, null, null, null, "asp.net");
            Assert.Greater(response.Items.Count, 0);

        }
        
        [Test]
        public void CanGetTagsByTagsWikis()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagsWikis("stackoverflow", null, null, "asp.net");
            Assert.Greater(response.Items.Count, 0);

        }

        [Test]
        public void CanGetTagsByTagTopAnswerersByPeriod()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagTopAnswerersByPeriod("stackoverflow", null, null, "asp.net", Period.all_time);
            Assert.Greater(response.Items.Count, 0);

        }

        [Test]
        public void CanGetTagsByTagTopAskersByPeriod()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsByTagTopAskersByPeriod("stackoverflow", null, null, "asp.net", Period.all_time);
            Assert.Greater(response.Items.Count, 0);

        }
        
        [Test]
        public void CanGetTagsModeratorOnly()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsModeratorOnly("stackapps", null, null, null, null, null, null, null, null, "status");
            Assert.Greater(response.Items.Count, 0);

        }
        
        [Test]
        public void CanGetTagsRequired()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsRequired("stackapps", null, null, null, null, null, null, null, null, null);
            Assert.Greater( response.Items.Count, 0);

        }

        [Test]
        public void CanGetTagsSynonyms()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Tags.TagsSynonyms("stackoverflow", null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);

        }
    }
}