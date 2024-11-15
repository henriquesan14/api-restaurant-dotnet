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

        public Table(string name, TableStatusEnum status)
        {
            Name = name;
            Status = status;
        }

        public string Name { get; private set; }
        public TableStatusEnum Status { get; private set; }
        [JsonIgnore]
        public virtual IEnumerable<CommonOrder> Orders { get; private set; }

        public void UpdateStatus(TableStatusEnum status)
        {
            Status = status;
        }

    }
}
