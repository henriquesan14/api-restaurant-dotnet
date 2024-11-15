using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class ProductCategory : Entity
    {
        public ProductCategory(string name)
        {
            Name = name;
        }

        public ProductCategory()
        {
        }

        public string Name { get; private set; }


        [JsonIgnore]
        public virtual IEnumerable<Product> Products { get; private set; }
    }
}