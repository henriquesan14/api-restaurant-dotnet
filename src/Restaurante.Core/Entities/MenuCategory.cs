using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class MenuCategory : Entity
    {
        public MenuCategory()
        {
            
        }

        public MenuCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; } // Nome da categoria, como "Appetizers", "Main Courses", "Desserts"
        public string Description { get; private set; }

        // Lista de itens na categoria
        [JsonIgnore]
        public List<MenuItem> Items { get; private set; }
    }
}
