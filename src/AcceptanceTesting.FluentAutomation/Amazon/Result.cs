using OpenQA.Selenium;

namespace AcceptanceTesting.FluentAutomation.Amazon
{
    public class Result
    {
        private readonly IWebElement _element;

        public Result(IWebElement element)
        {
            _element = element;
        }

        public IWebElement Title
        {
            get
            {
                return _element.FindElement(By.ClassName("s-access-detail-page"));
            }
        }
    }
}