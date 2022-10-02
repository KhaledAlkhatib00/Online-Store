using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class OrderProduct
    {
        public decimal Id { get; set; }
        public decimal? OrderId { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Orderr Order { get; set; }
        public virtual Productt Product { get; set; }
    }
}
