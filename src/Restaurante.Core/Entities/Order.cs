using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Core.Entities
{
    public class Order : Entity
    {
        public Order(OrderStatus status, User client, IEnumerable<OrderItem> items, IEnumerable<Payment> payments)
        {
            Status = status;
            Client = client;
            Items = items;
            Payments = payments;
        }

        public Order()
        {
        }

        public string Type { get; set; }
        public OrderStatus Status { get; set; }
        public User Client { get; set; }
        public int ClientId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public IEnumerable<Payment> Payments { get; set; }

        public decimal ValueTotal { get; set; }

        public bool IsPaid {
            get { return Payments != null ? Payments.Sum(p => p.AmountReceived) >= ValueTotal : false; }
        }
    }
}
