using System.Linq;
using AcceptanceTesting.Common.Pages;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTesting.Specs
{
    [Binding]
    public class AddingTasksSteps
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {}

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

        public class TaskInfo
        {
            public string Name { get; set; }
            public string Note { get; set; }
        }

        [When(@"I save the task")]
        public void WhenISaveTheTask()
        {
            Threaded<Session>
                 .CurrentBlock<NewTaskForm>()
                 .Save.Click();
        }

        [When(@"I cancel the task")]
        public void WhenICancelTheTask()
        {
            Threaded<Session>
                .CurrentBlock<NewTaskForm>()
                .Cancel.Click();
        }

        [Then(@"the task with title ""(.*)"" should not appear in my list of tasks")]
        public void ThenTheTaskWithTitleShouldNotAppearInMyListOfTasks(string name)
        {
            Threaded<Session>
                .CurrentBlock<MainArea>()
                .TaskRows.FirstOrDefault(row => row.Name.Text == name)
                .Verify("that row should not exist", row => row == null);
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
