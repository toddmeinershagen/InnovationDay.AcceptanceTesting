using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace AcceptanceTesting.Common.Infrastructure
{
    public class LocalPhantomJsEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new PhantomJSDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            return driver;
        }
    }
}
