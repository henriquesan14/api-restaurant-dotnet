using System;

namespace Restaurant.Application.ViewModels
{
    public class TotalOrderViewModel
    {
        public decimal Total { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
