using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class ProductCategory : Entity
    {
        public ProductCategory(string name, IEnumerable<Product> products)
        {
            Name = name;
            Products = products;
        }

        public ProductCategory()
        {
        }

        public string Name { get; set; }


        [JsonIgnore]
        public virtual IEnumerable<Product> Products { get; set; }
    }
}