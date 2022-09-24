using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Category : Entity
    {
        public Category(string name, CategoryType categoryType, IEnumerable<Product> products)
        {
            Name = name;
            CategoryType = categoryType;
            Products = products;
        }

        public Category()
        {
        }

        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}