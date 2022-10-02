using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Userr
    {
        public Userr()
        {
            BankAccounts = new HashSet<BankAccount>();
            Logins = new HashSet<Login>();
            Orderrs = new HashSet<Orderr>();
            Testmonials = new HashSet<Testmonial>();
        }

        public decimal Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string Imagepath { get; set; }
        [NotMapped] // not map the prop with the table in DB , cause no col with this name 
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Orderr> Orderrs { get; set; }
        public virtual ICollection<Testmonial> Testmonials { get; set; }
    }
}
