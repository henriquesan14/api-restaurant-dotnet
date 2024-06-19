using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Category : Entity
    {
        public Category(string name, CategoryTypeEnum categoryType, IEnumerable<Product> products)
        {
            Name = name;
            CategoryType = categoryType;
            Products = products;
        }

        public Category()
        {
        }

        public string Name { get; set; }

        public CategoryTypeEnum CategoryType { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Product> Products { get; set; }
    }
}