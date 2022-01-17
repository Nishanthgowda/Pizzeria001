using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class User
    {
        public User()
        {
            OrderPizzas = new HashSet<OrderPizza>();
        }

        public int Usersid { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public string? Usersrole { get; set; }

        public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
    }
}
