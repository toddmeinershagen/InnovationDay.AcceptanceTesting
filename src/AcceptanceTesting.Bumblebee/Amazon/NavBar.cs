using AcceptanceTesting.Common.Blocks;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee.Amazon
{
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
}