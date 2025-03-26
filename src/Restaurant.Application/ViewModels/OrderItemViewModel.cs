
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;

namespace Restaurant.Application.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public OrderItemStatusEnum Status { get; set; }

        public int Quantity { get; set; }

        public MenuItem MenuItem { get; set; }

        public int OrderId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
