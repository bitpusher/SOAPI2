using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture ]
    public class PostsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetPosts()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Posts.Posts("stackoverflow", null, null, null, null, null, null, null, null);

            Assert.Greater(response.Items.Count, 0);
        }

        
        [Test]
        public void CanGetPostsByIds()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Posts.PostsByIds("stackoverflow", null, null, null, null, null, null, null, null, "9247024");

            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetPostsByIdsComments()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Posts.PostsByIdsComments("stackoverflow", null, null, null, null, null, null, null, null, "9247024");

            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetPostsByIdsRevisions()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Posts.PostsByIdsRevisions("stackoverflow", null, null, null, null, "6841333");

            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test,Ignore("need a post id with suggested edits")]
        public void CanGetPostsByIdsSuggestedEdits()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Posts.PostsByIdsSuggestedEdits("stackoverflow", null, null, null, null, null, null, null, null, "6841479");

            Assert.Greater(response.Items.Count, 0);
        }
    }
}