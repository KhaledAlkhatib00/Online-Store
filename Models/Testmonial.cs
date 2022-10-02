using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Testmonial
    {
        public decimal Id { get; set; }
        public string UserMassege { get; set; }
        public decimal? UserId { get; set; }

        public virtual Userr User { get; set; }
    }
}
