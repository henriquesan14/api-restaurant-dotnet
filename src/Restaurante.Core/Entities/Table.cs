using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class Table : Entity
    {
        public Table(string name, TableStatus status, IEnumerable<Order> orders)
        {
            Name = name;
            Status = status;
            Orders = orders;
        }

        public Table()
        {
        }

        public string Name { get; set; }
        public TableStatus Status { get; set; }
        public IEnumerable<Order> Orders { get; set; }

    }
}
