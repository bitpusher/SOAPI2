using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class InfoFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetInfo()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Info.Info("stackoverflow");
            Assert.Greater(response.Items.Count, 0);
        }
    }

}