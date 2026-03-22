using NUnit.Framework;
using DemoShop.Infrastructure.Factories;

namespace DemoShop.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        /// <summary>
        /// Steps: 1. Go to Login. 2. Enter valid user. 3. Submit.
        /// Expected Result: Header shows user email.
        /// </summary>
        [Test]
        public void Login_Valid_Success()
        {
            var user = UserFactory.CreateValidUser();
            LoginP.Login(user);
            Assert.That(LoginP.GetUserEmail(), Is.EqualTo(user.Email), "Login failed for valid user.");
        }

        /// <summary>
        /// Steps: 1. Go to Login. 2. Enter wrong pass. 3. Submit.
        /// Expected Result: Error message appears.
        /// </summary>
        [Test]
        public void Login_Invalid_Error()
        {
            var user = UserFactory.CreateValidUser();
            user.Password = "Wrong!";
            LoginP.Login(user);
            Assert.That(LoginP.GetError(), Does.Contain("unsuccessful"), "No error message for wrong password.");
        }
    }
}