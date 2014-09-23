using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow.DataSamples
{
    [Binding]
    public class TransformationsSteps
    {
        [When(@"I set birthdate to (.*) days from now")]
        public void WhenISetBirthdateToDaysFromNow(int numberOfDays)
        {
            Birthdate = DateTime.Today.AddDays(numberOfDays);
        }
        
        [Then(@"the birthdate should be (in \d+ days)")]
        public void ThenTheBirthdateShouldBeInXDays(DateTime expectedDate)
        {
            Birthdate.Should().Be(expectedDate);
        }

        [StepArgumentTransformation(@"in (\d+) days")]
        public DateTime InXDaysTransform(int days)
        {
            return DateTime.Today.AddDays(days);
        }

        public DateTime Birthdate
        {
            get { return ScenarioContext.Current.Get<DateTime>(); }
            set { ScenarioContext.Current.Set(value); }
        }
    }
}
