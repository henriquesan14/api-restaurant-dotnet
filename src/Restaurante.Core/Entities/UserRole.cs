using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public  class UserRole : Entity
    {
        [JsonIgnore]
        public User User { get; set; }

        public Role Role { get; set; }
    }
}
