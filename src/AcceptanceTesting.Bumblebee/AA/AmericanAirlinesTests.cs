using System;
using AcceptanceTesting.Bumblebee.Infrastructure;
using Bumblebee.Setup;
using NUnit.Framework;

namespace AcceptanceTesting.Bumblebee.AA
{
    [TestFixture]
    public class AmericanAirlinesTests
    {
        [Test]
        public void given_search_terms_when_searching_for_flights_should_return_departure_choice_page()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<HomePage>("https://www.aa.com/homePage.do")
                .FindFlightArea
                .From.EnterText("DFW")
                .LeavingOn.EnterText(DateTime.Now.AddDays(30).ToShortDateString())
                .To.EnterText("LAS")
                .ReturningFrom.EnterText(DateTime.Now.AddDays(37).ToShortDateString())
                .Search.Click<DepartureChoicePage>()
                .Session.End();
        }
    }
}
