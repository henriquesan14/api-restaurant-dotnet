using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Role : Entity
    {
        public Role()
        {

        }

        public Role(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        [JsonIgnore]
        public virtual IEnumerable<User> Users { get; private set; }
    }
}
