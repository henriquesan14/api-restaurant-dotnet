using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Address : Entity
    {
        public Address()
        {
            
        }

        public Address(string street, string number, string district, string zipCode, string complement,
            int cityId)
        {
            Street = street;
            Number = number;
            District = district;
            ZipCode = zipCode;
            Complement = complement;
            CityId = cityId;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; private set; }
        public virtual City City { get; private set; }
        public int CityId { get; private set; }

        [JsonIgnore]
        public virtual User User { get; private set; }
        public int UserId { get; private set; }

        [JsonIgnore]
        public virtual IEnumerable<DeliveryOrder> Orders { get; private set; }

    }
}
