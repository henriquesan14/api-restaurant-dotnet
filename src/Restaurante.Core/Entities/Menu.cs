using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Menu : Entity
    {

        public Menu()
        {
            
        }

        public Menu(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public List<MenuItem> Items { get; private set; }
    }
}
