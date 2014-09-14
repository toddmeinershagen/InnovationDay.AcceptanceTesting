using System;
using AcceptanceTesting.SpecFlow.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow
{
    [Binding]
    public class DataExamplesSteps
    {
        [Given(@"a person with first name of ""(.*)"" and last name of ""(.*)""")]
        public void GivenAPersonWithFirstNameOfAndLastNameOf(string p0, string p1)
        {
            Person.FirstName = p0;
            Person.LastName = p1;
        }
        
        [When(@"I change person's first name to ""(.*)""")]
        public void WhenIChangePersonSFirstNameTo(string p0)
        {
            Person.FirstName = p0;
        }
        
        [Then(@"the person should have first name of ""(.*)"" and last name of ""(.*)""")]
        public void ThenThePersonShouldHaveFirstNameOfAndLastNameOf(string p0, string p1)
        {
            Person.FirstName.Should().Be(p0);
            Person.LastName.Should().Be(p1);
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
