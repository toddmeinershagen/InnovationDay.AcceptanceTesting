using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace AcceptanceTesting.Selenium
{
    [TestFixture(typeof (FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof (PhantomJSDriver))]
    public class given_a_web_driver<TDriver> where TDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [TestFixtureSetUp]
        public void before()
        {
            _driver = new TDriver();
        }

        [TestFixtureTearDown]
        public void after()
        {
            _driver.Dispose();
        }

        [Test]
        public void when_navigating_to_google_should_load_page()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.PageSource.Should().Contain("Google Search");
        }
    }
}
