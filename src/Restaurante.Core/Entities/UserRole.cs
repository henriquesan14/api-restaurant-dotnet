using Restaurant.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core.Entities
{
    public  class UserRole : Entity
    {
        public User User { get; set; }

        public Role Role { get; set; }
    }
}
