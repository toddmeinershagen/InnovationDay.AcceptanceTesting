using System;
using System.Diagnostics;
using System.Linq;
using FluentAutomation;
using NUnit.Framework;

namespace AcceptanceTesting.FluentAutomation.Amazon
{
    [TestFixture]
    public class AmazonTests : FluentTest
    {
        public AmazonTests()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Firefox, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void given_marriage_as_search_term_when_searching_from_home_page_should_return_results()
        {
            var results = new HomePage(this)
                .Go()
                .SearchFor("marriage")
                .Results;

            results.ToList()
                .ForEach(r => Debug.Print(r.Title.Text));

            I.Assert.True(() => results.Any());
        }
    }
}
