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
                    .GetElements(By.ClassName("s-result-item"))
                    .Where(e => e.GetElements(By.ClassName("s-access-detail-page")).Any())
                    .Select(r => new Result(Session, r));
            }
        }
    }
}