namespace Restaurant.Application.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<MenuItemViewModel> Items { get; set; } = new List<MenuItemViewModel>();
    }
}
