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
            get
            {
                var element = GetElement(By.ClassName("s-access-detail-page"));
                return new Clickable<Result>(this, element);
            }
        }
    }
}