using NUnit.Framework;

namespace SOAPI2.Tests
{
    [TestFixture, RequiresSTA,Ignore]
    public class OAuthFixture : FixtureBase
    {
        [Test]
        public void Test()
        {
            OAuthForm form = new OAuthForm();
            form.ShowDialog();
        }
    }
}