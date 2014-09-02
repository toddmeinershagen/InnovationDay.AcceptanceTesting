using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace InnovationDay.AcceptanceTesting.Specs.Infrastructure
{
    public class LocalFirefox : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            //var driver = new FirefoxDriver();
            var driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            return driver;
        }
    }
}
