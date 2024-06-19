using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;

namespace Restaurant.Application.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public OrderStatusEnum Status { get; set; }
        public User Client { get; set; }
        public Table Table { get; set; }
        public User Employee { get; set; }

        public Address Address { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal ValueTotal { get; set; }

    }
}
