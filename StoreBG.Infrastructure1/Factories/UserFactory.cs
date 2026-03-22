using System;
using DemoShop.Infrastructure.DTOs;

namespace DemoShop.Infrastructure.Factories
{
    public static class UserFactory
    {
        public static UserDTO CreateValidUser()
        {
            return new UserDTO
            {
                Email = Environment.GetEnvironmentVariable("TEST_USER_EMAIL") ?? "auto_student_123@test.com",
                Password = Environment.GetEnvironmentVariable("TEST_USER_PASSWORD") ?? "Password123!",
                FirstName = "Test",
                LastName = "User"
            };
        }

        public static UserDTO CreateDynamicNewUser()
        {
            return new UserDTO
            {
                Email = $"newuser_{Guid.NewGuid().ToString().Substring(0, 5)}@test.com",
                Password = "Password123!",
                FirstName = "Automation",
                LastName = "Student"
            };
        }
    }
}