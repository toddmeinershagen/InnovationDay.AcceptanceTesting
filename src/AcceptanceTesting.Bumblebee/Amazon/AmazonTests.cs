using System.Collections.Generic;
using System.Linq;
using AcceptanceTesting.Bumblebee.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee.Amazon
{
    [TestFixture]
    public class AmazonTests
    {
        [TearDown]
        public void after_each()
        {
            Threaded<Session>
                .End();
        }

        [Test]
        public void given_marriage_as_search_term_when_searching_from_home_page_should_return_results()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<HomePage>("http://www.amazon.com")
                .NavBar
                .SearchField.EnterText("marriage" + Keys.Enter)
                .Verify("that there are results", p => p.Results.Any())
                .DebugPrint(x => x.Results.Select(r => r.Title.Text + " - " + r.Author));
        }
    }

    public class HomePage : WebBlock
    {
        public HomePage(Session session) : base(session)
        {
        }

        public NavBar NavBar
        {
            get { return new NavBar(Session); }
        }
    }

    public class NavBar : WebBlock
    {
        public NavBar(Session session) : base(session)
        {
            Tag = GetElement(By.Id("navbar"));
        }


        public ITextField<ResultsPage> SearchField
        {
            get { return new TextField<ResultsPage>(this, By.Id("twotabsearchtextbox")); }
        }
    }

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
                    .Where(r => r.GetID().Contains("result"))
                    .Select(r => new Result(Session, r));
            }
        }
    }

    public class Result : SpecificBlock
    {
        public Result(Session session, IWebElement tag) : base(session, tag)
        {
        }

        public IClickable<Result> Title
        {
            get { return new Clickable<Result>(this, GetElement(By.ClassName("newaps")).GetElement(By.TagName("a"))); }
        }

        public string Author 
        {
            get { return ParseAuthor(GetElement(By.CssSelector("span.med.reg")).Text); }
        }

        private string ParseAuthor(string value)
        {
            const int lengthOfBy = 4;

            return value
                .Substring(3, value.Length - lengthOfBy)
                .Substring(0, value.IndexOf("(") - lengthOfBy);
        }
    }
}
