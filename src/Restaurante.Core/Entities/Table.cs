using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Table : Entity
    {
        public Table(string name, TableStatusEnum status, IEnumerable<Order> orders)
        {
            Name = name;
            Status = status;
            Orders = orders;
        }

        public Table()
        {
        }

        public string Name { get; set; }
        public TableStatusEnum Status { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Order> Orders { get; set; }

    }
}
