using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class MenuCategory : Entity
    {
        public string Name { get; set; } // Nome da categoria, como "Appetizers", "Main Courses", "Desserts"
        public string Description { get; set; }

        // Lista de itens na categoria
        [JsonIgnore]
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}
