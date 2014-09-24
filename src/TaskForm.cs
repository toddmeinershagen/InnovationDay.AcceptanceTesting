using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Demo.Blocks
{
    public class TaskForm : Block
    {
        public TaskForm(Session session) : base(session)
        {
            Tag = session.Driver.GetElement(By.ClassName("promptnewtask"));
        }

        public ITextField<TaskForm> Name
        {
            get { return new TextField<TaskForm>(this, By.Name("name"));}
        }

        public ITextField<TaskForm> Note
        {
            get { return new TextField<TaskForm>(this, By.Name("note"));}
        }

        public IClickable<MainPage> SaveChanges
        {
            get { return new Clickable<MainPage>(this, By.ClassName("save"));}
        }
    }
}