using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Grade { get; set; }
        public int? Pizzaid { get; set; }
        public int? Usersid { get; set; }

        public virtual Pizza? Pizza { get; set; }
        public virtual User? Users { get; set; }
    }
}
