
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;

namespace Restaurant.Application.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public OrderItemStatus Status { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }
    }
}
