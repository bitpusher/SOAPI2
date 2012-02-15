using NUnit.Framework;


namespace SOAPI2.Tests
{
    [TestFixture]
    public class AnswersFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Answers.Answers("stackoverflow", null, null, null, null, null, null, null, null);

            Assert.Greater(response.Items.Count, 0);
        }
        [Test]
        public void CanGetAnswersById()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Answers.AnswersByIds("stackoverflow", null, null, null, null, null, null, null, null, "6841479");

            Assert.AreEqual(1, response.Items.Count);
        }
        [Test]
        public void CanGetAnswersByIdComments()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Answers.AnswersByIdsComments("stackoverflow", null, null, null, null, null, null, null, null, "6841479");

            Assert.Greater(response.Items.Count, 0);
        }
    }
}