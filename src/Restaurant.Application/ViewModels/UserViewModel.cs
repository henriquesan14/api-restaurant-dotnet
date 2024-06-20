using Restaurant.Core.Entities;

namespace Restaurant.Application.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public Role Role { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
