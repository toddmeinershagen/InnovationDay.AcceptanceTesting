using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace AcceptanceTesting.Selenium
{
    [TestFixture]
    public class WebDriverTests
    {
        [TestCase(typeof(FirefoxDriver))]
        [TestCase(typeof(PhantomJSDriver))]
        [TestCase(typeof(InternetExplorerDriver))]
        public void given_driver_type_when_navigating_to_google_should_load_page(Type typeOfDriver)
        {
            using (IWebDriver driver = GetDriver(typeOfDriver))
            {
                driver.Navigate().GoToUrl("http://www.google.com");
                driver.PageSource.Should().Contain("Google Search");
            }
        }

        public IWebDriver GetDriver(Type typeOfDriver)
        {
           return  Activator.CreateInstance(typeOfDriver) as IWebDriver;
        }
    }
}
