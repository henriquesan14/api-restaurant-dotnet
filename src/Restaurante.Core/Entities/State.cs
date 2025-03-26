using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class State : Entity
    {
        public State()
        {
            
        }

        public State(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        [JsonIgnore]
        public virtual IEnumerable<City> Cities { get; private set; }
    }
}
