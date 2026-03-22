using System;

namespace DemoShop.Infrastructure.DTOs
{
    public class UserDTO : IEquatable<UserDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Equals(UserDTO other)
        {
            if (other == null) return false;
            return Email == other.Email && FirstName == other.FirstName && LastName == other.LastName;
        }
    }
}