using Restaurant.Core.Enums;
using System;

namespace Restaurant.Application.ViewModels
{
    public class CountOrderItemViewModel
    {
        public DateTime? Date { get; set; }
        public int Count { get; set; }
        public OrderItemStatus? Status { get; set; }
    }
}
