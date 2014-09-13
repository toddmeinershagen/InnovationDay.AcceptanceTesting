using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AcceptanceTesting.Specs.Infrastructure
{
    public class LocalFirefoxEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            return driver;
        }
    }
}
