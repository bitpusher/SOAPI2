using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class UsersFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetUsers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.Users("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        
        [Test]
        public void CanGetUsersByIdAssociated()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdAssociated(null, null, "87636");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test,ExpectedException(typeof(System.NotImplementedException ))]
        public void CanGetUsersByIdInbox()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdInbox("stackoverflow", null, null, 242897);
            Assert.Greater(response.Items.Count, 0);
        }

    [Test, ExpectedException(typeof(System.NotImplementedException))]
        public void CanGetUsersByIdInboxUnread()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdInboxUnread("stackoverflow", null, null, 242897, null);
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdPrivileges()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdPrivileges("stackoverflow", null, null, 242897);
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIds()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIds("stackapps", null, null, null, null, null, null, null, null, "14");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsAnswers("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsBadges()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsBadges("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsComments()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsComments("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsCommentsToId()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsCommentsToId("stackoverflow", null, null, null, null, null, null, null, null, "242897", 22656);
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsFavorites()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsFavorites("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsMentioned()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsMentioned("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsQuestions()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsQuestions("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test,Ignore("apparently featured questions are transient")]
        public void CanGetUsersByIdsQuestionsFeatured()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsQuestionsFeatured("stackoverflow", null, null, null, null, null, null, null, null, "15052");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsQuestionsNoAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsQuestionsNoAnswers("stackoverflow", null, null, null, null, null, null, null, null, "47012");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsQuestionsUnaccepted()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsQuestionsUnaccepted("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsQuestionsUnanswered()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsQuestionsUnanswered("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsReputation()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsReputation("stackoverflow", null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test,Ignore("need more input data")]
        public void CanGetUsersByIdsSuggestedEdits()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsSuggestedEdits("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsTags()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsTags("stackoverflow", null, null, null, null, null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdsTimeline()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdsTimeline("stackoverflow", null, null, null, null, "242897");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdTagsByTagsTopAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdTagsByTagsTopAnswers("stackoverflow", null, null, null, null, null, null, null, null, 242897, "javascript");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdTagsByTagsTopQuestions()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdTagsByTagsTopQuestions("stackoverflow", null, null, null, null, null, null, null, null, 242897, "javascript");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersByIdTopAnswerTags()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdTopAnswerTags("stackoverflow", null, null, 242897);
            Assert.Greater(response.Items.Count, 0);
        }
         
        [Test]
        public void CanGetUsersByIdTopQuestionTags()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersByIdTopQuestionTags("stackoverflow", null, null, 242897);
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersModerators()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersModerators("stackoverflow", null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetUsersModeratorsElected()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Users.UsersModeratorsElected("stackoverflow", null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }
    }
}