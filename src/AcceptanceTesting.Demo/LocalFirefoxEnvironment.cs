using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AcceptanceTesting.Demo
{
    public class LocalFirefoxEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            return new FirefoxDriver();
        }
    }
}
