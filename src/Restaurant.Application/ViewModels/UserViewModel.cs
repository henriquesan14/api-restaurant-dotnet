using Restaurant.Core.Entities;
using System.Collections.Generic;

namespace Restaurant.Application.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
