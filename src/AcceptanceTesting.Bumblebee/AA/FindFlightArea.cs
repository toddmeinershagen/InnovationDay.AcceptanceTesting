using AcceptanceTesting.Common.Blocks;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee.AA
{
    public class FindFlightArea : WebBlock
    {
        public FindFlightArea(Session session) : base(session)
        {
            Tag = GetElement(By.Id("reservationFlightSearchForm"));
        }

        public ITextField<FindFlightArea> From
        {
            get { return new TextField<FindFlightArea>(this, By.Name("originAirport")); }
        }

        public ITextField<FindFlightArea> To
        {
            get { return new TextField<FindFlightArea>(this, By.Name("destinationAirport")); }
        }

        public ITextField<FindFlightArea> LeavingOn
        {
            get { return new TextField<FindFlightArea>(this, By.Id("aa-leavingOn")); }
        }

        public ITextField<FindFlightArea> ReturningFrom
        {
            get { return new TextField<FindFlightArea>(this, By.Id("aa-returningFrom"));}
        }

        public IClickable Search
        {
            get { return new Clickable(this, By.Id("flightSearchForm.button.reSubmit")); }
        }
    }
}