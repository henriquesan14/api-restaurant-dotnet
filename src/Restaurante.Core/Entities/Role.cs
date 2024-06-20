using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<User> Users { get; set; }
    }
}
