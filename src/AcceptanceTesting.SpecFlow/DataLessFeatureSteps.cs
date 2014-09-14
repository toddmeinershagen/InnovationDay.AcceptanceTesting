using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow
{
    [Binding]
    public class DataLessFeatureSteps
    {
        [Given(@"some existing context")]
        public void GivenSomeExistingContext()
        {
            ExistingContext = string.Empty;
        }

        [When(@"I perform some action")]
        public void WhenIPerformSomeAction()
        {
            ExistingContext = "Todd Meinershagen is presenting.";
        }

        [Then(@"I expect some outcome")]
        public void ThenIExpectSomeOutcome()
        {
            ExistingContext.Should().Be("Todd Meinershagen is presenting.");
        }

        public string ExistingContext
        {
            get { return ScenarioContext.Current["ExistingContext"] as string; }
            set { ScenarioContext.Current["ExistingContext"] = value; }
        }
}
}
