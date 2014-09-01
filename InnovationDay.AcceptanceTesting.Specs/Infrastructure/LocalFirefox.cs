using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace InnovationDay.AcceptanceTesting.Specs.Infrastructure
{
    public class LocalFirefox : IDriverEnvironment
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
