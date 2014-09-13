using AcceptanceTesting.Common.Pages;
using AcceptanceTesting.Specs.Infrastructure;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Specs
{
    [Binding]
    public static class WebScenarios
    {
        private static readonly Settings Settings = new Settings();

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<LoggedOutPage>(Settings.BaseUrl);
        }

        [BeforeScenario("autoLogin")]
        public static void BeforeAutoLoginScenario()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(Settings.ValidUserName)
                .Password.EnterText(Settings.ValidPassword)
                .Login.Click<LoggedInPage>();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Threaded<Session>
                .End();
        }
    }
}
