using AcceptanceTesting.Common.Blocks;
using AcceptanceTesting.Common.Infrastructure;
using AcceptanceTesting.Specs.Infrastructure;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Specs.Hooks
{
    [Binding]
    public class WebScenarios
    {
        private readonly Settings _settings = new Settings();

        [BeforeScenario("autoLogin")]
        public void BeforeScenario()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<LoggedOutPage>(_settings.BaseUrl);
        }

        [BeforeScenario("autoLogin")]
        public void BeforeAutoLoginScenario()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Username.EnterText(_settings.ValidUserName)
                .Password.EnterText(_settings.ValidPassword)
                .Login.Click<LoggedInPage>();
        }

        [AfterScenario("autoLogin")]
        public void AfterScenario()
        {
            Threaded<Session>
                .End();
        }
    }
}
