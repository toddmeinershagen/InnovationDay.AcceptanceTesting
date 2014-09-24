using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Demo.Blocks
{
    public class Toolbar : Block
    {
        public Toolbar(Session session) : base(session)
        {
            Tag = Session.Driver.GetElement(By.Id("north"));
        }

        public IClickable<TaskForm> NewTask
        {
            get { return new Clickable<TaskForm>(this, By.ClassName("newtask"));}
        }
    }
}