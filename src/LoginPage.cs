using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Demo.Blocks
{
    public class LoginPage : Block
    {
        public LoginPage(Session session) : base(session)
        {
            Tag = session.Driver.GetElement(By.TagName("body"));
        }

        public ITextField<LoginPage> Username
        {
            get { return new TextField<LoginPage>(this, By.Id("username")); }
        }

        public ITextField<LoginPage> Password
        {
            get { return new TextField<LoginPage>(this, By.Id("password")); }
        }

        public IClickable<MainPage> Login
        {
            get { return new Clickable<MainPage>(this, By.ClassName("submit")); }
        }
    }
}
