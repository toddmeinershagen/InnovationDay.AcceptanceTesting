using System.Linq;
using AcceptanceTesting.Common.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee.Amazon
{
    [TestFixture]
    public class AmazonTests
    {
        [TearDown]
        public void after_each()
        {
            Threaded<Session>
                .End();
        }

        [Test]
        public void given_marriage_as_search_term_when_searching_from_home_page_should_return_results()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<HomePage>("http://www.amazon.com")
                .NavBar
                .SearchField.EnterText("marriage" + Keys.Enter)
                .Verify("that there are results", p => p.Results.Any())
                .DebugPrint(x => x.Results.Select(r => r.Title.Text + " - " + r.Author));
        }
    }
}
