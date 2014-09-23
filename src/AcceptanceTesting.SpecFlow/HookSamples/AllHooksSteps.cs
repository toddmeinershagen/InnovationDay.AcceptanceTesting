using System.Diagnostics;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.SpecFlow.HookSamples
{
    [Binding]
    //[Binding, Scope(Feature="AllHooks")]
    //[Binding, Scope(Tag="run")]
    public class AllHooksSteps
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Log("BeforeTestRun");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Log("BeforeFeature");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Log("BeforeScenario");
        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            Log("BeforeScenarioBlock");
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            Log("AfterScenarioBlock");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Log("AfterScenario");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Log("AfterFeature");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log("AfterTestRun");
        }

        private static void Log(string message)
        {
            Debug.Print("-->{0}", message);
        }

        [Given(@"I have hooks")]
        public void GivenIHaveHooks()
        {
            Debug.Print("Given");
        }
        
        [When(@"I execute")]
        public void WhenIExecute()
        {
            Debug.Print("When");
        }
        
        [Then(@"hooks execute")]
        public void ThenHooksExecute()
        {
            Debug.Print("Then");
        }
    }
}
