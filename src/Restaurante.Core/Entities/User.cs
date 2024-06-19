using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public  class User : Entity
    {
        public User()
        {
        }

        public User(string firstName, string lastName, string document, string email, string phoneNumber, string password, Role role,
            int roleId, IEnumerable<Address> addresses, IEnumerable<Order> orders)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
            RoleId = roleId;
            Addresses = addresses;
            Orders = orders;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
