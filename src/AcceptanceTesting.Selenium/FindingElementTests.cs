using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AcceptanceTesting.Selenium
{
    [TestFixture]
    public class FindingElementTests
    {
        private IWebDriver _driver;

        [TestFixtureSetUp]
        public void before()
        {
            _driver = new FirefoxDriver();
        }

        [SetUp]
        public void before_each()
        {
            _driver.Navigate().GoToUrl("https://www.nirvanahq.com/account/login");
        }

        [TestFixtureTearDown]
        public void after()
        {
            _driver.Quit();
        }

        [Test]
        public void when_finding_element_by_id()
        {
            var element = _driver.FindElement(By.Id("username"));
            element.Clear();
            element.SendKeys("By.Id");
        }

        [Test]
        public void when_finding_element_by_name()
        {
            var element = _driver.FindElement(By.Name("emailaddress"));
            element.Clear();
            element.SendKeys("By.Name");
        }

        [Test]
        public void when_finding_element_by_classname()
        {
            var element = _driver.FindElement(By.ClassName("submit"));
            element.Click();
        }

        [Test]
        public void when_finding_element_by_cssselector()
        {
            var elements = _driver.FindElements(By.CssSelector("a.forgot"));
            foreach (var element in elements)
            {
                Debug.Print(element.Text);
            }
        }

        [Test]
        public void when_finding_element_by_xpath()
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"username\"]"));
            element.Clear();
            element.SendKeys("By.XPath");
        }

        [Test]
        public void when_finding_element_by_link()
        {
            var element = _driver.FindElement(By.LinkText("Forgot your password?"));
            element.Click();
        }

        [Test]
        public void when_finding_element_by_partial_link_text()
        {
            var element = _driver.FindElement(By.PartialLinkText("Sign Up"));
            element.Click();
        }

        [Test]
        public void when_finding_element_by_tag_name()
        {
            var elements = _driver.FindElements(By.TagName("div"));
            foreach (var element in elements)
            {
                Debug.Print(element.Text);
            }
        }
    }
}
