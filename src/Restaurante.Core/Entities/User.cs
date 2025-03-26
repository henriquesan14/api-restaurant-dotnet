using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public  class User : Entity
    {
        public User()
        {
            Addresses = new List<Address>();
        }

        public User(string firstName, string lastName, string document, string email, string phoneNumber, string password, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            RoleId = roleId;
            Addresses = new List<Address>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public string Document { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }
        [JsonIgnore]
        public string Password { get; private set; }
        public virtual Role Role { get; private set; }
        public int RoleId { get; private set; }
        public virtual IEnumerable<Address> Addresses { get; private set; }
        [JsonIgnore]
        public virtual IEnumerable<Order> Orders { get; private set; }

        public void AddAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            // Inicializa a coleção como uma lista mutável caso esteja vazia
            if (Addresses is not List<Address> addressList)
            {
                addressList = Addresses.ToList();
                Addresses = addressList;
            }

            addressList.Add(address);
        }
    }
}
