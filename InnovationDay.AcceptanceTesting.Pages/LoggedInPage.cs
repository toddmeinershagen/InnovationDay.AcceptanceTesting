using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace InnovationDay.AcceptanceTesting.Pages
{
    public class LoggedInPage : WebBlock
    {
        public LoggedInPage(Session session)
            : base(session)
        {
            Wait.Until(driver => driver.GetElement(By.Id("north")));
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }

        public NorthArea NorthArea
        {
            get { return new NorthArea(Session); }
        }
    }

    public class NorthArea : WebBlock
    {
        public NorthArea(Session session) : base(session)
        {
            Tag = GetElement(By.Id("north"));
        }

        public ITextField<NorthArea> SearchField
        {
            get { return new TextField<NorthArea>(this, By.ClassName("q")); }
        }
    }
}