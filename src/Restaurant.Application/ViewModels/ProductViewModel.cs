using Restaurant.Core.Entities;
using System;

namespace Restaurant.Application.ViewModels
{
    public  class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public Category Category { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
