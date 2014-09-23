using System.Collections.Generic;
using System.Linq;
using AcceptanceTesting.SpecFlow.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTesting.SpecFlow.DataSamples
{
    [Binding]
    public class DataTableSteps
    {
        [Given(@"a set of persons")]
        public void GivenASetOfPersons(Table table)
        {
            Persons = table.CreateSet<Person>();
        }
        
        [When(@"I update first name for each person to ""(.*)""")]
        public void WhenIUpdateFirstNameForEachPersonTo(string newFirstName)
        {
            Persons.ToList().ForEach(x => x.FirstName = newFirstName);
        }
        
        [Then(@"the set should look like the following")]
        public void ThenTheSetShouldLookLikeTheFollowing(Table table)
        {
            table.CompareToSet(Persons);
        }

        IEnumerable<Person> Persons
        {
            get { return ScenarioContext.Current.Get<IEnumerable<Person>>(); }
            set { ScenarioContext.Current.Set(value); }
        }
    }
}
