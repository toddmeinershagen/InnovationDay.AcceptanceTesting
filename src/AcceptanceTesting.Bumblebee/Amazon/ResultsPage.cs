using System.Collections.Generic;
using System.Linq;
using AcceptanceTesting.Common.Blocks;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee.Amazon
{
    public class ResultsPage : WebBlock
    {
        public ResultsPage(Session session) : base(session)
        {}

        public IEnumerable<Result> Results
        {
            get
            {
                return GetElement(By.Id("atfResults"))
                    .GetElements(By.TagName("div"))
                    .Where(r => WebElementConvenience.GetID((IWebElement) r).Contains("result"))
                    .Select(r => new Result(Session, r));
            }
        }
    }
}