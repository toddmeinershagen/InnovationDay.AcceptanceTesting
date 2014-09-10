using AcceptanceTesting.Common.Pages;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Specs
{
    [Binding]
    public class AuthenticationSteps
    {
        [Given]
        public void Given_I_enter_a_valid_username_and_password()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(WebScenarios.ValidUsername)
                .Password.EnterText(WebScenarios.ValidPassword)
                .Login.Click<LoggedInPage>();
        }

        [Given]
        public void Given_I_enter_a_invalid_username_and_password()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(WebScenarios.ValidUsername)
                .Password.EnterText(WebScenarios.InvalidPassword)
                .Login.Click<LoggedOutPage>();
        }
        
        [When]
        public void When_I_login()
        {
        }
        
        [Then]
        public void Then_I_should_be_taken_to_the_home_page()
        {
            Threaded<Session>
                .CurrentBlock<LoggedInPage>()
                .ToolBar
                .Verify(t => t.Account.Text == "Todd Meinershagen");
        }

        [Then]
        public void Then_I_should_be_taken_to_the_login_page()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify(x => x.Error.Text == "incorrect password, please try again");
        }
    }
}
