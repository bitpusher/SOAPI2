using NUnit.Framework;


namespace SOAPI2.Tests
{
    [TestFixture]
    public class CommentsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";
        [Test]
        public void CanGetComments()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Comments.Comments("stackoverflow", null, null, null, null, null, null, null, null);


            Assert.Greater(response.Items.Count, 0);
        }
        [Test]
        public void CanGetCommentsByIds()
        {
            var client = new SoapiClient(Apikey, AppId);

            var response = client.Comments.CommentsByIds("stackoverflow", null, null, null, null, null, null, null, null, "11651797");

            Assert.Greater(response.Items.Count, 0);
        }
    }
}