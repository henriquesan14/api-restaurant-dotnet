using Restaurant.Core.Entities;

namespace Restaurant.Application.ViewModels
{
    public  class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal QuantityInStock { get; set; }
        public string UnitOfMeasure { get; set; }

        public ProductCategory Category { get; set; }

        public int CreatedByUserId { get; set; }

        public int? UpdateByUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
