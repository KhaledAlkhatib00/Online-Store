using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class BankAccount
    {
        public decimal Id { get; set; }
        public decimal? AccountNumber { get; set; }
        public decimal? AccountSnn { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Userr Customer { get; set; }
    }
}
