using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}
