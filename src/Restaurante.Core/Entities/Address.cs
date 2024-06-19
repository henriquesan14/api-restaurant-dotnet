using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Address : Entity
    {
        

        public Address()
        {
        }

        public Address(string street, string number, string district, string zipCode, string complement, City city,
            int cityId, User user, int userId, IEnumerable<DeliveryOrder> orders)
        {
            Street = street;
            Number = number;
            District = district;
            ZipCode = zipCode;
            Complement = complement;
            City = city;
            CityId = cityId;
            User = user;
            UserId = userId;
            Orders = orders;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<DeliveryOrder> Orders { get; set; }

    }
}
