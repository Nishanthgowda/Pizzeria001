using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class Pizza
    {
        public int Pizzaid { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
