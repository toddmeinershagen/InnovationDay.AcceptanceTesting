using AcceptanceTesting.SpecFlow.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow.DataSamples
{
    [Binding]
    public class DataExamplesSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Person = new Person();
        }

        [Given(@"a person with first name of '(.*)' and last name of '(.*)'")]
        public void GivenAPersonWithFirstNameOfAndLastNameOf(string firstName, string lastName)
        {
            Person.FirstName = firstName;
            Person.LastName = lastName;
        }
        
        [When(@"I change person's first name to '(.*)'")]
        public void WhenIChangePersonSFirstNameTo(string newFirstName)
        {
            Person.FirstName = newFirstName;
        }
        
        [Then(@"the person should have first name of '(.*)' and last name of '(.*)'")]
        public void ThenThePersonShouldHaveFirstNameOfAndLastNameOf(string expectedFirstName, string expectedLastName)
        {
            Person.FirstName.Should().Be(expectedFirstName);
            Person.LastName.Should().Be(expectedLastName);
        }

        public Person Person
        {
            get { return ScenarioContext.Current.Get<Person>(); }
            set { ScenarioContext.Current.Set(value); }
        }
    }
}
