using NUnit.Framework;


namespace SOAPI2.Tests
{
    [TestFixture]
    public class BadgesFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanGetBadges()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Badges.Badges("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        
        [Test]
        public void CanGetBadgesByIds()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Badges.BadgesByIds("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        //client.Badges.BadgesByIdsRecipients()
        [Test]
        public void CanGetBadgesByIdsRecipients()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Badges.BadgesByIdsRecipients("stackoverflow",null,null,null,null,null);
            Assert.Greater(response.Items.Count, 0);
        }

        //client.Badges.BadgesName()
        [Test]
        public void CanGetBadgesName()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Badges.BadgesName("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        //client.Badges.BadgesRecipients()
        [Test]
        public void CanGetBadgesRecipients()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Badges.BadgesRecipients("stackoverflow", null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        //client.Badges.BadgesTags()
        [Test]
        public void CanGetBadgesTags()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Badges.BadgesTags("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

    }
}