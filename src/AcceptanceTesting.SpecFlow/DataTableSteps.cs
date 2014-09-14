using System;
using AcceptanceTesting.SpecFlow.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTesting.SpecFlow
{
    [Binding]
    public class DataTableSteps
    {
        [Given(@"a person")]
        public void GivenAPerson(Table table)
        {
            var person = table.CreateInstance<Person>();
            Person = person;
        }

        [When(@"I person's first name to ""(.*)""")]
        public void WhenIPersonSFirstNameTo(string p0)
        {
            Person.FirstName = p0;
        }
        
        [Then(@"the person should be like the following")]
        public void ThenThePersonShouldBeLikeTheFollowing(Table table)
        {
            var person = table.CreateInstance<Person>();

            Person.FirstName.Should().Be(person.FirstName);
            Person.LastName.Should().Be(person.LastName);
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
