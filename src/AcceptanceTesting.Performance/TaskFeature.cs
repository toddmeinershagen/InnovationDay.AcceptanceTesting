using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AcceptanceTesting.Common.Pages;
using AcceptanceTesting.Performance.Infrastructure;
using AcceptanceTesting.Specs.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace AcceptanceTesting.Performance
{
    /// <summary>
    /// Summary description for AddingATask
    /// </summary>
    [TestClass]
    public class TaskFeature
    {
        private readonly Settings _settings = new Settings();

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize]
        public void SetUp()
        {
            Threaded<Session>
                .With<LocalChromeEnvironment>()
                .NavigateTo<LoggedOutPage>(_settings.BaseUrl);
        }

        [TestCleanup]
        public void TearDown()
        {
            Threaded<Session>
                .End();
        }

        [TestMethod]
        [DeploymentItem("chromedriver.exe")]
        public void AddingATask()
        {
            var taskInfo = new {Name = "Task_" + Guid.NewGuid(), Note = "Note for task."};

            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .LoginArea
                .Username.EnterText(_settings.ValidUserName)
                .Password.EnterText(_settings.ValidPassword)
                .Login.Click<LoggedInPage>()
                .ToolBar
                .NewTask.Click()
                .Name.EnterText(taskInfo.Name)
                .Note.EnterText(taskInfo.Note)
                .Save.Click()
                .TaskRows.First(row => row.Name.Text == taskInfo.Name)
                .Verify("that row should exist", row => row != null)
                .Delete();
        }
    }
}
