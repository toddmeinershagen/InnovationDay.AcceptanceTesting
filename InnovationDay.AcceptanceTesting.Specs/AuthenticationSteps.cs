using System.Threading;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using InnovationDay.AcceptanceTesting.Pages;
using InnovationDay.AcceptanceTesting.Specs.Infrastructure;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace InnovationDay.AcceptanceTesting.Specs
{
    [Binding]
    public class AuthenticationSteps
    {
        [Given]
        public void Given_I_enter_a_valid_username_and_password()
        {
            Session<LocalFirefox>
                .Current
                .NavigateTo<LoggedOutPage>("https://www.nirvanahq.com/account/login")
                .LoginArea
                .Username.EnterText("todd@meinershagen.net")
                .Password.EnterText("jesusislord");
        }
        
        [When]
        public void When_I_login()
        {
            Session<LocalFirefox>
                .Current
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .LoginButton.Click();
        }
        
        [Then]
        public void Then_I_should_be_taken_to_the_home_page()
        {
            Session<LocalFirefox>
                .Current
                .CurrentBlock<LoggedInPage>()
                .Verify(x => x.Session.Driver.PageSource.Contains("Search"))
                .NorthArea
                .SearchField.EnterText("test" + Keys.Enter)
                .Session.End();
        }
    }
}
