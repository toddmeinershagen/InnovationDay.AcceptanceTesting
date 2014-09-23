using AcceptanceTesting.Common.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee
{
    [TestFixture(typeof (LocalChromeEnvironment))]
    [TestFixture(typeof (LocalFirefoxEnvironment))]
    [TestFixture(typeof(LocalIeEnvironment))]
    [TestFixture(typeof(LocalPhantomJsEnvironment))]
    public class DriverEnvironmentTests<TDriverEnvironment>
        where TDriverEnvironment : IDriverEnvironment, new()
    {
        [Test]
        public void when_navigating_to_google_should_load_page()
        {
            Threaded<Session>
                .With<TDriverEnvironment>()
                .NavigateTo<GoogleSearch>("http://www.google.com")
                .Verify("that page contains text 'Google Search'", x => x.Session.Driver.PageSource.Contains("Google Search"))
                .Session.End();
        }
    }

    public class GoogleSearch : Block
    {
        public GoogleSearch(Session session) : base(session)
        {
            Tag = session.Driver.GetElement(By.TagName("body"));
        }
    }
}