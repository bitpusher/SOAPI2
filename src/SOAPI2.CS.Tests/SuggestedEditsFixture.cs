using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class SuggestedEditsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanGetSuggestedEdits()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Suggested_Edits.SuggestedEdits("stackoverflow", null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
            
        }
        [Test]
        public void CanGetSuggestedEditsByIds()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Suggested_Edits.SuggestedEdits("stackoverflow", null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
            client.Suggested_Edits.SuggestedEditsByIds("stackoverflow", null, null, null, null, null, null, null, null,"9248237");
        }
    }
}