using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class RevisionsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanGetRevisions()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Revisions.RevisionsByIds("stackoverflow", null, null, null, null, "91265C70-4988-4AAC-9C34-D6370EA0CAC4");
            Assert.Greater(response.Items.Count, 0);
        }
    }
}