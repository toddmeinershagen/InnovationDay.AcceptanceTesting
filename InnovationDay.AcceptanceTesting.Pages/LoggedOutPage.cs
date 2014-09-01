using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace InnovationDay.AcceptanceTesting.Pages
{
    public class LoggedOutPage : WebBlock
    {
        public LoggedOutPage(Session session) 
            : base(session)
        {}

        public LoginArea LoginArea
        {
            get { return new LoginArea(Session); }
        }
    }

    public class LoginArea : WebBlock
    {
        public LoginArea(Session session)
            : base(session)
        {
            Tag = GetElement(By.Id("login"));
        }

        public ITextField<LoginArea> Username
        {
            get { return new TextField<LoginArea>(this, By.Id("username")); }
        }

        public ITextField<LoginArea> Password
        {
            get { return new TextField<LoginArea>(this, By.Id("password"));}
        }

        public IClickable<LoggedInPage> LoginButton
        {
            get { return new Clickable<LoggedInPage>(this, By.ClassName("submit"));}
        }
    }
}
