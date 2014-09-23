using AcceptanceTesting.Common.Blocks;
using Bumblebee.Setup;

namespace AcceptanceTesting.Bumblebee.Amazon
{
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
}