using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price, string imageUrl, Category category)
        {
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            Category = category;
        }

        public Product()
        {
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

    }
}
