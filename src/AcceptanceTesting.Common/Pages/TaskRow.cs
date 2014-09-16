using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Common.Pages
{
    public class TaskRow : SpecificBlock
    {
        public TaskRow(Session session, IWebElement tag) : base(session, tag)
        {}

        public IHasText Name
        {
            get
            {
                return new TextField(this, By.CssSelector("span.name.edittask"));
            }
        }

        public IClickable<TaskRow> Complete
        {
            get { return new Clickable<TaskRow>(this, By.CssSelector("span.i.check")); }
        }

        public void Delete()
        {
            var drag = GetElement(By.CssSelector("span.i.drag.project"));
            var drop = new SideBar(Session).Trash;
            GetDragAndDropPerformer()
                .DragAndDrop(drag, drop);

            Session.Pause(200);

        }
    }
}