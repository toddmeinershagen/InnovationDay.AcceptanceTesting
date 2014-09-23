using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Demo.Blocks
{
    public class LoggedOutPage : WebBlock
    {
        public LoggedOutPage(Session session) : base(session)
        {
            Tag = GetElement(By.Id("login"));
        }

        public IHasText Error
        {
            get { return new TextField(this, By.ClassName("formerror"));}
        }

        public ITextField<LoggedOutPage> UserName
        {
            get { return new TextField<LoggedOutPage>(this, By.Id("username"));}
        }

        public ITextField<LoggedOutPage> Password
        {
            get { return new TextField<LoggedOutPage>(this, By.Id("password"));}
        }

        public IClickable Submit
        {
            get { return new Clickable(this, By.ClassName("submit"));}
        }
    }
}
