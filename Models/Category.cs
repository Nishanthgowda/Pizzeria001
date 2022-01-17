using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class Category
    {
        public Category()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
