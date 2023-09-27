using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Application.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public OrderStatus Status { get; set; }
        public User Client { get; set; }
        public Table Table { get; set; }
        public User Employee { get; set; }

        public Address Address { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public IEnumerable<Payment> Payments { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Total
        {
            get { return Items != null ? Items.Sum(i => i.SubTotal) : 0; }
        }

        public bool IsPaid
        {
            get { return Payments != null ? Payments.Sum(p => p.AmountReceived) >= Total : false; }
        }
    }
}
