using AcceptanceTesting.Common.Blocks;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTesting.Bumblebee.AA
{
    public class DepartureChoicePage : WebBlock
    {
        public DepartureChoicePage(Session session) : base(session)
        {
            Wait.Until(d => ExpectedConditions.ElementExists(By.ClassName("aa-summary")));
            Tag = Wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }
}