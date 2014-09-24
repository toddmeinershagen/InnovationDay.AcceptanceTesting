using System.Linq;
using AcceptanceTesting.Common.Blocks;
using AcceptanceTesting.Common.Infrastructure;
using AcceptanceTesting.Specs.Infrastructure;
using AcceptanceTesting.Specs.Models;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTesting.Specs
{
    [Binding]
    public class AddingTasksSteps
    {
        private readonly Settings _settings = new Settings();

        [AfterScenario]
        public void AfterScenario()
        {
            Threaded<Session>
                .End();
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<LoggedOutPage>(_settings.BaseUrl)
                .Username.EnterText(_settings.ValidUserName)
                .Password.EnterText(_settings.ValidPassword)
                .Login.Click<LoggedInPage>();
        }

        [Given(@"I enter info for a new task")]
        public void GivenIEnterInfoForANewTask(Table table)
        {
            var taskInfo = table.CreateInstance<TaskInfo>();

            Threaded<Session>
                .CurrentBlock<LoggedInPage>()
                .ToolBar
                .NewTask.Click()
                .Name.EnterText(taskInfo.Name)
                .Note.EnterText(taskInfo.Note);
        }

        [When(@"I save the task")]
        public void WhenISaveTheTask()
        {
            Threaded<Session>
                 .CurrentBlock<NewTaskForm>()
                 .Save.Click();
        }

        [Then(@"the task with title ""(.*)"" should appear in my list of tasks")]
        public void ThenTheTaskWithTitleShouldAppearInMyListOfTasks(string name)
        {
            Threaded<Session>
                .CurrentBlock<MainArea>()
                .TaskRows.First(row => row.Name.Text == name)
                .Verify("that row should exist", row => row != null)
                .Delete();
        }
    }
}
