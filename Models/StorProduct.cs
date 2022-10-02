using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class StorProduct
    {
        public decimal Id { get; set; }
        public string StoreName { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? StoreId { get; set; }

        public virtual Productt Product { get; set; }
        public virtual Storee Store { get; set; }
    }
}
