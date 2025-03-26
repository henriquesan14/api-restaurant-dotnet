using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class City : Entity
    {
        public City()
        {
            
        }

        public City(string name, State state, int stateId)
        {
            Name = name;
            State = state;
            StateId = stateId;
        }

        public string Name { get; private set; }
        public virtual State State { get; private set; }
        public int StateId { get; private set; }

        [JsonIgnore]
        public virtual IEnumerable<Address> Addresses { get; private set; }
    }
}
