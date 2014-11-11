using FluentAutomation;
using OpenQA.Selenium;

namespace AcceptanceTesting.FluentAutomation.Amazon
{
    public class HomePage : PageObject<HomePage>
    {
        public HomePage(FluentTest test)
            : base(test)
        {
            Url = "http://wwww.amazon.com";
        }

        public ResultsPage SearchFor(string searchText)
        {
            I.Enter(searchText + Keys.Enter).In("#twotabsearchtextbox");
            return Switch<ResultsPage>();
        }
    }
}