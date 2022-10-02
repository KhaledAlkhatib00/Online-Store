using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Categoryy
    {
        public Categoryy()
        {
            Storees = new HashSet<Storee>();
        }

        public decimal Id { get; set; }
        public string CategoryyName { get; set; }
        public string ImagePath { get; set; }
        [NotMapped] // not map the prop with the table in DB , cause no col with this name 
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<Storee> Storees { get; set; }
    }
}
