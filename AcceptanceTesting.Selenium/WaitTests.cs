using System;
using AcceptanceTesting.Specs.Infrastructure;
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

        [TestCase(0)]
        [TestCase(3)]
        public void given_number_of_seconds_when_logging_in_should_be_able_to_find_search_with_implicit_wait(int numberOfSeconds)
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(numberOfSeconds));
            Login(_driver);

            var search = _driver.FindElement(By.Name("q"));
            search.Clear();
            search.SendKeys("test");
        }

        [TestCase(0)]
        [TestCase(10)]
        public void given_number_of_seconds_when_logging_in_should_be_able_to_find_search_with_explicit_wait(int numberOfSeconds)
        {
            Login(_driver);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(numberOfSeconds));
            var search = wait.Until(d => d.FindElement(By.Name("q")));
            search.Clear();
            search.SendKeys("test");
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
