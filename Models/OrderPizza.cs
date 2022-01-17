using System;
using System.Collections.Generic;

namespace Pizzeria001.Models
{
    public partial class OrderPizza
    {
        public int OrderId { get; set; }
        public int? OrderNumber { get; set; }
        public int? Usersid { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual User? Users { get; set; }
    }
}
