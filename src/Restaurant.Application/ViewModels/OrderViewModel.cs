using Restaurant.Core.Entities;
using Restaurant.Core.Enums;

namespace Restaurant.Application.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public OrderStatusEnum Status { get; set; }
        public UserViewModel Client { get; set; }
        public TableViewModel Table { get; set; }

        public Address  Address { get; set; }
        public IEnumerable<OrderItemViewModel> Items { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal ValueTotal { get; set; }

        public UserViewModel CreatedByUser { get; set; }

    }
}
