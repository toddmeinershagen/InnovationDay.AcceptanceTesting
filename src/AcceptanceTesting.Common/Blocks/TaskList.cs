using System.Collections.Generic;
using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Common.Blocks
{
    public class TaskList : SpecificBlock
    {
        public TaskList(Session session, IWebElement tag) : base(session, tag)
        {}

        public IHasText Name
        {
            get { return new TextField(this, By.ClassName("name"));}
        }

        public IEnumerable<TaskRow> TaskRows
        {
            get
            {
                return GetElement(By.ClassName("tasks"))
                    .GetElements(By.ClassName("task"))
                    .Select(tag => new TaskRow(Session, tag));
            }
        }
    }
}