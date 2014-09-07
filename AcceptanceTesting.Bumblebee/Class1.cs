using System;
using AcceptanceTesting.Bumblebee.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTesting.Bumblebee
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void given()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<HomePage>("https://www.aa.com/homePage.do")
                .FindFlightArea
                .From.EnterText("DFW")
                .LeavingOn.EnterText("12/01/2014")
                .To.EnterText("LAS")
                .ReturningFrom.EnterText("12/08/2014")
                .Search.Click<DepartureChoicePage>()
                .Session.End();
        }
    }

    public class HomePage : WebBlock
    {
        public HomePage(Session session) : base(session)
        {}

        public FindFlightArea FindFlightArea
        {
            get { return new FindFlightArea(Session); }
        }
    }

    public class DepartureChoicePage : WebBlock
    {
        public DepartureChoicePage(Session session) : base(session)
        {
            Wait.Until(d => ExpectedConditions.ElementExists(By.ClassName("aa-summary")));
            Tag = Wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }

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

    public class WebBlock : Block
    {
        protected WebDriverWait Wait { get; private set; }

        public WebBlock(Session session)
            : base(session)
        {
            this.Pause(200);
            Wait = new WebDriverWait(Session.Driver, TimeSpan.FromSeconds(5));
            Tag = Wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }
}
