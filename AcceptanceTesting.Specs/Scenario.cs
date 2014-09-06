using System.Configuration;
using System.Linq;
using AcceptanceTesting.Common;
using AcceptanceTesting.Common.Pages;
using AcceptanceTesting.Specs.Infrastructure;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Specs
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
            get { return ConfigurationManager.AppSettings["encrypted"].Decrypt(); }
        }

        public static string InvalidPassword
        {
            get { return "jjjjjjj"; }
        }

        #endregion
    }
}
