using Restaurant.Core.Entities.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string district, string zipCode, User user, IEnumerable<DeliveryOrder> orders)
        {
            Street = street;
            Number = number;
            District = district;
            ZipCode = zipCode;
            User = user;
            Orders = orders;
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

        [JsonIgnore]
        public IEnumerable<DeliveryOrder> Orders { get; set; }
    }
}
