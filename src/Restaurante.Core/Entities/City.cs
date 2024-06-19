using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public virtual State State { get; set; }
        public int StateId { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Address> Addresses { get; set; }
    }
}
