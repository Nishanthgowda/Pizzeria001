using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class Cart
    {
        public int Cartid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
