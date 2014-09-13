using System.Collections.Generic;
using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Common.Pages
{
    public class MainArea : WebBlock
    {
        public MainArea(Session session) : base(session)
        {
            Tag = GetElement(By.Id("main"));
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