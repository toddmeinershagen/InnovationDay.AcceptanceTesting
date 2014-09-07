using Bumblebee.Setup;

namespace AcceptanceTesting.Bumblebee.AA
{
    public class HomePage : WebBlock
    {
        public HomePage(Session session) : base(session)
        {}

        public FindFlightArea FindFlightArea
        {
            get { return new FindFlightArea(Session); }
        }
    }
}