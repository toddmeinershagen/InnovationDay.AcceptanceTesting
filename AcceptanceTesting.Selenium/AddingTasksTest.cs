using System;
using System.Linq;
using AcceptanceTesting.Specs.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTesting.Selenium
{
    [TestFixture]
    public class AddingTasksTest
    {
        private readonly Settings _settings = new Settings();

        [Test]
        public void given_i_am_logged_in_and_i_enter_info_for_a_new_task_when_i_save_the_task_then_the_task_should_appear_in_my_list_of_tasks()
        {
            using (var driver = new FirefoxDriver())
            {
                LogIn(driver);

                var task = new
                {
                    Name = "Test Task",
                    Note = "This is a note for the task."
                };

                EnterInfoForNewTask(driver, task);
                var newTask = GetTaskFromList(driver, task);
                DeleteTask(driver, newTask);
            }
        }

        private void LogIn(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(_settings.BaseUrl);

            var username = driver.FindElement(By.Id("username"));
            username.Clear();
            username.SendKeys(_settings.ValidUserName);

            var password = driver.FindElement(By.Id("password"));
            password.Clear();
            password.SendKeys(_settings.ValidPassword);

            var submit = driver.FindElement(By.ClassName("submit"));
            submit.Click();
        }

        private static void EnterInfoForNewTask(IWebDriver driver, dynamic task)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var newTask = wait.Until(d => d.FindElement(By.ClassName("newtask")));
            newTask.Click();

            var form = driver.FindElement(By.ClassName("promptnewtask"));
            var name = form.FindElement(By.Name("name"));
            name.Clear();
            name.SendKeys(task.Name);

            var note = form.FindElement(By.ClassName("note"));
            note.Clear();
            note.SendKeys(task.Note);

            var save = form.FindElement(By.ClassName("save"));
            save.Click();
        }

        private static IWebElement GetTaskFromList(IWebDriver driver, dynamic task)
        {
            var tasks = driver
                .FindElement(By.ClassName("tasks"))
                .FindElements(By.ClassName("task"));
            return tasks.First(t => t.FindElement(By.CssSelector("span.name.edittask")).Text == task.Name);
        }

        private static void DeleteTask(IWebDriver driver, IWebElement task)
        {
            var drag = task.FindElement(By.CssSelector("span.i.drag.project"));
            var drop = driver.FindElement(By.ClassName("trash"));

            var builder = new Actions(driver);
            var dragAndDrop = builder.ClickAndHold(drag)
                .MoveToElement(drop)
                .Release(drag)
                .Build();
            dragAndDrop.Perform();
        }
    }
}
