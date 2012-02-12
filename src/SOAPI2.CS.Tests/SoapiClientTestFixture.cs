using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SOAPI2.Model;

namespace SOAPI2.Tests
{
    [TestFixture]
    public class SoapiClientTestFixture
    {
        const string Apikey = "SFh4Ag1Pid7I4i)VDYjyIw((";
        private const string AppId = "66";

        [Test, Ignore("kevin doesn't like this method being called more than very infrequently.... because his backend sucks?")]
        public void CanGetSites()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Sites.Sites(1, 10);
            Assert.AreEqual(10, response.Items.Count);
        }

        [Test]
        public void CanGetStackOverflowErrors()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Errors.Errors(1, 100);
            Assert.Greater(response.Items.Count, 0);

        }
        [Test]
        public void CanGetInfo()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Info.Info("stackoverflow");

            Assert.Greater(response.Items.Count, 0);
        }
        [Test]
        public void CanGetAnswers()
        {
            var client = new SoapiClient(Apikey, AppId);
            var response = client.Answers.Answers("stackoverflow", null, null, null, null, null, null, null, null);

            Assert.Greater(response.Items.Count, 0);
        }
    }
}
