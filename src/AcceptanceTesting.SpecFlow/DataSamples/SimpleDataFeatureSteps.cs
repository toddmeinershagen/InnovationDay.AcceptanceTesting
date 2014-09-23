using AcceptanceTesting.SpecFlow.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow.DataSamples
{
    [Binding]
    public class SimpleDataFeatureSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Person = new Person();
        }

        [Given(@"a person with a first name of ""(.*)""")]
        public void GivenAPersonWithAFirstNameOf(string firstName)
        {
            Person.FirstName = firstName;
        }
        
        [Given(@"a person with a last name of ""(.*)""")]
        public void GivenAPersonWithALastNameOf(string lastName)
        {
            Person.LastName = lastName;
        }

        [Given(@"a person with age of (.*)")]
        public void GivenAPersonWithAgeOf(int age)
        {
            Person.Age = age;
        }

        [When(@"I change the first name to ""(.*)""")]
        public void WhenIChangeTheFirstNameTo(string newFirstName)
        {
            Person.FirstName = newFirstName;
        }
        
        [Then(@"the first name should be ""(.*)""")]
        public void ThenTheFirstNameShouldBe(string expectedFirstName)
        {
            Person.FirstName.Should().Be(expectedFirstName);
        }
        
        [Then(@"the last name should be ""(.*)""")]
        public void ThenTheLastNameShouldBe(string expectedLastName)
        {
            Person.LastName.Should().Be(expectedLastName);
        }

        [Then(@"the age should be (.*)")]
        public void ThenTheAgeShouldBe(int expectedAge)
        {
            Person.Age.Should().Be(41);
        }

        public Person Person
        {
            get { return ScenarioContext.Current.Get<Person>(); }
            set { ScenarioContext.Current.Set(value); }
        }
    }
}
