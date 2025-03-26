using Restaurant.Core.Entities;

namespace Restaurant.Application.ViewModels
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<MenuItemProduct> NeededProducts { get; set; } = new List<MenuItemProduct>();

        public virtual MenuCategory MenuCategory { get; set; }
        public int MenuCategoryId { get; set; }

        public virtual Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}
