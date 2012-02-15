using NUnit.Framework;

namespace SOAPI2.Tests
{
    //
    [TestFixture]
    public class QuestionsFixture : FixtureBase
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test]
        public void CanGetQuestions()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.Questions("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        [Test]
        public void CanGetQuestionsByIds()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsByIds("stackoverflow", null, null, null, null, null, null, null, null, "6841333");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetQuestionsByIdsAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsByIdsAnswers("stackoverflow", null, null, null, null, null, null, null, null, "6841333");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetQuestionsByIdsComments()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsByIdsComments("stackoverflow", null, null, null, null, null, null, null, null, "6841333");
            Assert.Greater(response.Items.Count, 0);
        }
        
        [Test]
        public void CanGetQuestionsByIdsLinked()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsByIdsLinked("stackoverflow", null, null, null, null, null, null, null, null, "6841333");
            Assert.Greater(response.Items.Count, 0);
        }

        [Test]
        public void CanGetQuestionsByIdsRelated()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsByIdsRelated("stackoverflow", null, null, null, null, null, null, null, null, "6841333");
            Assert.Greater(response.Items.Count, 0);
        }

        [Test]
        public void CanGetQuestionsByIdsTimeline()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsByIdsTimeline("stackoverflow", null, null, null, null, "6841333");
            Assert.Greater(response.Items.Count, 0);
        }

        [Test]
        public void CanGetQuestionsFeatured()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsFeatured("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        [Test]
        public void CanGetQuestionsNoAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsNoAnswers("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }

        [Test]
        public void CanGetQuestionsUnanswered()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Questions.QuestionsUnanswered("stackoverflow", null, null, null, null, null, null, null, null, null);
            Assert.Greater(response.Items.Count, 0);
        }
    }
}