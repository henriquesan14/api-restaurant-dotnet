using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class State : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<City> Cities { get; set; }
    }
}
