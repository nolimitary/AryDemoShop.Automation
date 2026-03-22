using NUnit.Framework;
using DemoShop.Infrastructure.Factories;

namespace DemoShop.Tests
{
    [TestFixture]
    public class RegistrationTests : BaseTest
    {
        /// <summary>
        /// Steps: 1. Go to Register. 2. Fill random user. 3. Submit.
        /// Expected Result: Success message shown.
        /// </summary>
        [Test]
        public void Reg_NewUser_Success()
        {
            RegP.Register(UserFactory.CreateDynamicNewUser());
            Assert.That(RegP.GetMessage(), Is.EqualTo("Your registration completed"), "Reg failed.");
        }

        /// <summary>
        /// Steps: 1. Go to Register. 2. Leave email blank. 3. Submit.
        /// Expected Result: Validation error.
        /// </summary>
        [Test]
        public void Reg_NoEmail_Fail()
        {
            var u = UserFactory.CreateDynamicNewUser(); u.Email = "";
            RegP.Register(u);
            Assert.That(Driver.PageSource, Does.Contain("Email is required"), "Email validation missing.");
        }

        /// <summary>
        /// Steps: 1. Go to Register. 2. Use existing email. 3. Submit.
        /// Expected Result: Duplicate error.
        /// </summary>
        [Test]
        public void Reg_Duplicate_Fail()
        {
            RegP.Register(UserFactory.CreateValidUser());

            RegP.Register(UserFactory.CreateValidUser());

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, System.TimeSpan.FromSeconds(5));
            bool errorFound = wait.Until(d => d.PageSource.Contains("The specified email already exists"));

            Assert.That(errorFound, Is.True, "The duplicate email error message never appeared.");
        }
    }
}