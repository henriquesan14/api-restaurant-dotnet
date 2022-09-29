using Restaurant.Core.Entities.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public  class User : Entity
    {
        public User(string firstName, string lastName, string document, string email, string phoneNumber, string password, IEnumerable<UserRole> roles, IEnumerable<Address> addresses, IEnumerable<Order> orders)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Roles = roles;
            Addresses = addresses;
            Orders = orders;
        }

        public User()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        [JsonIgnore]
        public IEnumerable<Order> Orders { get; set; }
    }
}
