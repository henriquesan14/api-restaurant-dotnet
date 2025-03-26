using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Table : Entity
    {
        

        public Table()
        {
        }

        public Table(string name, TableStatusEnum status, int capacity)
        {
            Name = name;
            Status = status;
            Capacity = capacity;
        }

        public string Name { get; private set; }
        public TableStatusEnum Status { get; private set; }
        public int Capacity { get; private set; }
        [JsonIgnore]
        public virtual IEnumerable<CommonOrder> Orders { get; private set; }

        public void UpdateStatus(TableStatusEnum status)
        {
            Status = status;
        }

    }
}
