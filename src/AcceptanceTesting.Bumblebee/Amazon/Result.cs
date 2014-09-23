using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee.Amazon
{
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