using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Common.Pages
{
    public class SideBar : WebBlock
    {
        public SideBar(Session session) : base(session)
        {
            Tag = GetElement(By.Id("east"));
        }

        public IWebElement Trash
        {
            get { return GetElement(By.ClassName("trash")); }
        }
    }
}