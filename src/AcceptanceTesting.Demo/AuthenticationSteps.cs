using AcceptanceTesting.Demo.Blocks;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Demo
{
    [Binding]
    public class AuthenticationSteps
    {
        [Given(@"a username of ""(.*)""")]
        public void GivenAUsernameOf(string userName)
        {
            UserName = userName;
        }
        
        [Given(@"a password of ""(.*)""")]
        public void GivenAPasswordOf(string password)
        {
            Password = password;
        }
       
        [When(@"I login")]
        public void WhenILogin()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<LoggedOutPage>("https://www.nirvanahq.com/account/login")
                .UserName.EnterText(UserName)
                .Password.EnterText(Password)
                .Submit.Click<LoggedOutPage>();
        }
        
        [Then(@"I should get an error message of ""(.*)""")]
        public void ThenIShouldGetAnErrorMessageOf(string message)
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Verify(x => x.Error.Text == message)
                .Session.End();
        }

        public string UserName
        {
            get { return ScenarioContext.Current["UserName"] as string; }
            set { ScenarioContext.Current["UserName"] = value; }
        }

        public string Password
        {
            get { return ScenarioContext.Current["Password"] as string; }
            set { ScenarioContext.Current["Password"] = value; }
        }
    }
}
