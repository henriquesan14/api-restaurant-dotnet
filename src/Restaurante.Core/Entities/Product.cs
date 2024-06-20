using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Product : Entity
    {
        

        public Product()
        {
        }

        public Product(string name, string description, decimal price, string imageUrl, Category category, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            Category = category;
            CategoryId = categoryId;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
