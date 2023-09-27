using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string district, string zipCode, User user)
        {
            Street = street;
            Number = number;
            District = district;
            ZipCode = zipCode;
            User = user;
        }

        public Address()
        {
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
