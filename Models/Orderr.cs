using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Orderr
    {
        public Orderr()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public decimal Id { get; set; }
        public decimal? UserId { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }

        public virtual Userr User { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
