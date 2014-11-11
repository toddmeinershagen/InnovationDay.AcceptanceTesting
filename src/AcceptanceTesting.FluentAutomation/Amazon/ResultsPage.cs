using System.Collections.Generic;
using System.Linq;
using FluentAutomation;
using OpenQA.Selenium;

namespace AcceptanceTesting.FluentAutomation.Amazon
{
    public class ResultsPage : PageObject<ResultsPage>
    {
        public ResultsPage(FluentTest test)
            : base(test)
        {}

        public IEnumerable<Result> Results
        {
            get
            {
                var element = I.Find("#atfResults").Element as Element;

                return element.WebElement
                    .FindElements(By.ClassName("s-result-item"))
                    .Where(e => e.FindElements(By.ClassName("s-access-detail-page")).Any())
                    .Select(e => new Result(e));
            }

        }
    }
}