using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class MenuItem : Entity
    {
        public MenuItem()
        {
            
        }

        public MenuItem(string name, string description, decimal price, string imageUrl, int menuCategoryId, int menuId)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            MenuCategoryId = menuCategoryId;
            MenuId = menuId;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<MenuItemProduct> NeededProducts { get; set; } = new List<MenuItemProduct>();

        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }

        public MenuCategory MenuCategory { get; set; }
        public int MenuCategoryId { get; set; }

        [JsonIgnore]
        public virtual Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}
