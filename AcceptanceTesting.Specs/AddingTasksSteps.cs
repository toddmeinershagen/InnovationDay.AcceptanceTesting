using System.Linq;
using AcceptanceTesting.Common.Pages;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using TechTalk.SpecFlow;

namespace AcceptanceTesting.Specs
{
    [Binding]
    public class AddingTasksSteps
    {
        [Given]
        public void Given_I_am_logged_in()
        {
            
        }

        public string ExpectedName
        {
            get { return "Test Task"; }
        }

        [Given]
        public void Given_I_enter_info_for_a_new_task()
        {
            Threaded<Session>
                .CurrentBlock<LoggedInPage>()
                .ToolBar
                .NewTask.Click()
                .Name.EnterText(ExpectedName)
                .Note.EnterText("This is a test note.");
        }
        
        [When]
        public void When_I_save_the_task()
        {
            Threaded<Session>
                .CurrentBlock<NewTaskForm>()
                .Save.Click();
        }

        [When]
        public void When_I_cancel_the_task()
        {
            Threaded<Session>
                .CurrentBlock<NewTaskForm>()
                .Cancel.Click();
        }
        
        [Then]
        public void Then_the_task_should_appear_in_my_list_of_tasks()
        {
            Threaded<Session>
                .CurrentBlock<MainArea>()
                .TaskRows.First(row => row.Name.Text == ExpectedName)
                .Verify("that row should exist", row => row != null)
                .Delete();            
        }

        [Then]
        public void Then_the_task_should_not_appear_in_my_list_of_tasks()
        {
            Threaded<Session>
                .CurrentBlock<MainArea>()
                .TaskRows.FirstOrDefault(row => row.Name.Text == ExpectedName)
                .Verify("that row should not exist", row => row == null);
        }

    }
}
