using Bumblebee.Extensions;
using Bumblebee.Setup;
using InnovationDay.AcceptanceTesting.Pages;
using TechTalk.SpecFlow;

namespace InnovationDay.AcceptanceTesting.Specs
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
                .Username.EnterText(Scenario.ValidUsername)
                .Password.EnterText(Scenario.ValidPassword)
                .Login.Click<LoggedInPage>();
        }

        [Given]
        public void Given_I_enter_a_invalid_username_and_password()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(Scenario.ValidUsername)
                .Password.EnterText(Scenario.InvalidPassword)
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
