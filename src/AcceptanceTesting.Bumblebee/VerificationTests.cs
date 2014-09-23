using AcceptanceTesting.Common.Blocks;
using AcceptanceTesting.Common.Infrastructure;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AcceptanceTesting.Bumblebee
{
    [TestFixture]
    public class VerificationTests
    {
        [Test]
        public void given_a_number()
        {
            1
                .Verify(x => x == 1);
        }

        [Test]
        public void given_a_string()
        {
            "Todd Meinershagen"
                .Verify(x => x.Contains("Meiner"));
        }

        [Test]
        public void given_an_object()
        {
            var person = new Person {FirstName = "Todd", LastName = "Meinershagen"};

            person
                .Verify(x => x.FirstName == "Todd");
        }

        [Test]
        public void given_message()
        {
            "Ellie Meinershagen"
                .Verify("that string contains 'Todd'", x => x.Contains("Todd"));
        }

        [Test]
        public void given_page_when_verifying_the_presence_of_element_should_find()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<GoogleSearch>("http://www.google.com")
                .VerifyPresence(By.Id("gbqfq"))
                .Session.End();
        }

        [Test]
        public void given_page_when_verifying_the_absence_of_element_should_not_find()
        {
            Threaded<Session>
                .With<LocalFirefoxEnvironment>()
                .NavigateTo<GoogleSearch>("http://www.google.com")
                .VerifyAbsence(By.Id("q"))
                .Session.End();
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
