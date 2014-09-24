using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Demo.Blocks
{
    public class MainPage : Block
    {
        public MainPage(Session session) : base(session)
        {
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }

        public Toolbar Toolbar
        {
            get { return new Toolbar(Session);}
        }
    }
}