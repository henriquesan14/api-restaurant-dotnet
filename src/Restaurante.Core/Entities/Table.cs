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

        public Table(string name, TableStatusEnum status, IEnumerable<CommonOrder> orders)
        {
            Name = name;
            Status = status;
            Orders = orders;
        }

        public string Name { get; set; }
        public TableStatusEnum Status { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CommonOrder> Orders { get; set; }

    }
}
