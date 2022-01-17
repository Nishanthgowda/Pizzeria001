using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class PizzaReview
    {
        public int Reviewid { get; set; }
        public string? Username { get; set; }
        public string? Pizzaname { get; set; }
        public string? Review { get; set; }
        public int? Stars { get; set; }
    }
}
