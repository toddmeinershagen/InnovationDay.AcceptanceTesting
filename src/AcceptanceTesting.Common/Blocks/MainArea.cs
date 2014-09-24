using System.Collections.Generic;
using System.Linq;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Common.Blocks
{
    public class MainArea : WebBlock
    {
        public MainArea(Session session) : base(session)
        {
            Tag = GetElement(By.Id("main"));
        }

        public IEnumerable<TaskList> TaskLists
        {
            get { return GetElements(By.ClassName("tasklist"))
                .Select(x => new TaskList(Session, x)); }
        }
    }
}