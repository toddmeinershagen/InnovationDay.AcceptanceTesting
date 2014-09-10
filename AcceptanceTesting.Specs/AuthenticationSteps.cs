using AcceptanceTesting.Common.Pages;
using AcceptanceTesting.Specs.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Specs
{
    [Binding]
    public class AuthenticationSteps
    {
        private readonly Settings _settings = new Settings();

        [Given(@"I enter a valid username and password")]
        public void GivenIEnterAValidUsernameAndPassword()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(_settings.ValidUserName)
                .Password.EnterText(_settings.ValidPassword)
                .Login.Click<LoggedInPage>();
        }

        [When(@"I login")]
        public void WhenILogin()
        {}

        [Given(@"I enter a invalid username and password")]
        public void GivenIEnterAInvalidUsernameAndPassword()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(_settings.ValidUserName)
                .Password.EnterText("jjjjjj")
                .Login.Click<LoggedOutPage>();
        }

        [Then(@"I should be taken to the home page with username ""(.*)"" displayed")]
        public void ThenIShouldBeTakenToTheHomePageWithUsernameDisplayed(string username)
        {
            Threaded<Session>
                .CurrentBlock<LoggedInPage>()
                .ToolBar
                .Verify(t => t.Account.Text == username);
        }


        [Then(@"I should be taken to the login page with title ""(.*)""")]
        public void ThenIShouldBeTakenToTheLoginPageWithTitle(string title)
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify(x => x.Session.Driver.Title == title);
        }


        [Then(@"error message with ""(.*)"" text should be displayed")]
        public void ThenErrorMessageWithTextShouldBeDisplayed(string errorText)
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify(x => x.Error.Text == errorText);
        }

    }
}
