using System.Linq;
using Bumblebee.Setup;
using InnovationDay.AcceptanceTesting.Pages;
using InnovationDay.AcceptanceTesting.Specs.Infrastructure;
using TechTalk.SpecFlow;

namespace InnovationDay.AcceptanceTesting.Specs
{
    [Binding]
    public static class Scenario
    {
        [BeforeScenario]
        public static void before_each()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<LoggedOutPage>("https://www.nirvanahq.com/account/login");

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("autoLogin"))
            {
                Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(ValidUsername)
                .Password.EnterText(ValidPassword)
                .Login.Click<LoggedInPage>();
            }
        }

        [AfterScenario]
        public static void after_each()
        {
            Threaded<Session>
                .End();
        }

        #region "properties"

        public static string ValidUsername
        {
            get { return "todd@meinershagen.net"; }
        }

        public static string ValidPassword
        {
            get { return "jesusislord"; }
        }

        public static string InvalidPassword
        {
            get { return "jjjjjjj"; }
        }

        #endregion
    }
}
