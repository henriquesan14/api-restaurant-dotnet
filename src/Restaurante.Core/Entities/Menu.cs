using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Menu : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}
