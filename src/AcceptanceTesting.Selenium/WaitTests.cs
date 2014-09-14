using System;
using AcceptanceTesting.Specs.Infrastructure;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTesting.Selenium
{
    [TestFixture]
    public class WaitTests
    {
        private IWebDriver _driver;
        private readonly Settings _settings = new Settings();

        [SetUp]
        public void before_each()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void after_each()
        {
            _driver.Dispose();
        }

        [TestCase(0, true)]
        [TestCase(3, false)]
        public void given_number_of_seconds_when_searching_with_implicit_wait_should_demonstrate_expected_timeout(int numberOfSeconds, bool shouldTimeout)
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(numberOfSeconds));
            Login(_driver);

            Action action = () =>
            {
                var search = _driver.FindElement(By.Name("q"));
                search.Clear();
                search.SendKeys("test");
            };

            if (shouldTimeout)
            {
                action.ShouldThrow<NoSuchElementException>();
            }
            else
            {
                action.ShouldNotThrow();
            }
        }

        [TestCase(0, true)]
        [TestCase(10, false)]
        public void given_number_of_seconds_when_searching_with_explicit_wait_should_demonstrate_expected_timeout(int numberOfSeconds, bool shouldTimeout)
        {
            Login(_driver);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(numberOfSeconds));

            Action action = () =>
            {
                var search = wait.Until(d => d.FindElement(By.Name("q")));
                search.Clear();
                search.SendKeys("test");
            };

            if (shouldTimeout)
            {
                action.ShouldThrow<WebDriverTimeoutException>();
            }
            else
            {
                action.ShouldNotThrow();
            }
        }

        private void Login(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.nirvanahq.com/account/login");
                        
            var username = driver.FindElement(By.Id("username"));
            username.Clear();
            username.SendKeys(_settings.ValidUserName);

            var password = driver.FindElement(By.Id("password"));
            password.Clear();
            password.SendKeys(_settings.ValidPassword);

            var submit = driver.FindElement(By.ClassName("submit"));
            submit.Click();
        }
    }
}
