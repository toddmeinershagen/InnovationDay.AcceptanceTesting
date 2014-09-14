using AcceptanceTesting.SpecFlow.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow
{
    [Binding]
    public class SimpleDataFeatureSteps
    {
        [Given(@"a person with a first name of ""(.*)""")]
        public void GivenAPersonWithAFirstNameOf(string p0)
        {
            Person.FirstName = p0;
        }
        
        [Given(@"a person with a last name of ""(.*)""")]
        public void GivenAPersonWithALastNameOf(string p0)
        {
            Person.LastName = p0;
        }
        
        [When(@"I change the first name to ""(.*)""")]
        public void WhenIChangeTheFirstNameTo(string p0)
        {
            Person.FirstName = p0;
        }
        
        [Then(@"the first name should be ""(.*)""")]
        public void ThenTheFirstNameShouldBe(string p0)
        {
            Person.FirstName.Should().Be(p0);
        }
        
        [Then(@"the last name should be ""(.*)""")]
        public void ThenTheLastNameShouldBe(string p0)
        {
            Person.LastName.Should().Be(p0);
        }

        public Person Person
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("Person"))
                    ScenarioContext.Current["Person"] = new Person();

                return ScenarioContext.Current["Person"] as Person;
            }
            set { ScenarioContext.Current["Person"] = value; }
        }
    }
}
