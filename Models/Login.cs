using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Login
    {
        public decimal Id { get; set; }
        public string UserName { get; set; }
        public string Passwordd { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Customerid { get; set; }

        public virtual Userr Customer { get; set; }
        public virtual Rolee Role { get; set; }
    }
}
