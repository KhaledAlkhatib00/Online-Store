using System;
using System.Collections.Generic;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Rolee
    {
        public Rolee()
        {
            Logins = new HashSet<Login>();
        }

        public decimal Id { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
