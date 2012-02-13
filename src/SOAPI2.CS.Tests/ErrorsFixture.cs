using Salient.JsonClient;
using Newtonsoft.Json;
using NUnit.Framework;
using SOAPI2.Model;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class ErrorsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanGetErrors()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Errors.Errors(null, null);
            Assert.Greater(response.Items.Count, 0);
        }
        [Test]
        public void CanGetErrorsById()
        {
            var client = new SoapiClient(Apikey, AppId);
            try
            {
                client.Errors.ErrorsById(401);
            }
            catch (ApiException apiException)
            {
                // #TODO put this functionality back in ApiException
                var error = JsonConvert.DeserializeObject<ErrorClass>(apiException.ResponseText);
                Assert.AreEqual(401, error.ErrorId);
            }

        }
    }
}