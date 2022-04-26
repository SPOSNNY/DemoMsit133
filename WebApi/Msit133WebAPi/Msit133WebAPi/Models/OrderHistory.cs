using System;
using System.Collections.Generic;

#nullable disable

namespace Msit133WebAPi.Models
{
    public partial class OrderHistory
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? Discount { get; set; }
    }
}
