using AcceptanceTesting.SpecFlow.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTesting.SpecFlow
{
    [Binding]
    public class VerticalDataTableSteps
    {
        [Given(@"a person")]
        public void GivenAPerson(Table table)
        {
            var person = table.CreateInstance<Person>();
            Person = person;
        }

        [When(@"I change the person's first name to ""(.*)""")]
        public void WhenIPersonSFirstNameTo(string newFirstName)
        {
            Person.FirstName = newFirstName;
        }
        
        [Then(@"the person should be like the following")]
        public void ThenThePersonShouldBeLikeTheFollowing(Table table)
        {
            var person = table.CreateInstance<Person>();

            Person.FirstName.Should().Be(person.FirstName);
            Person.LastName.Should().Be(person.LastName);
            Person.Age.Should().Be(person.Age);
        }

        public Person Person
        {
            get
            {
                return ScenarioContext.Current["Person"] as Person;
            }
            set { ScenarioContext.Current["Person"] = value; }
        }
    }
}
