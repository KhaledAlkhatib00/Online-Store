using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Storee
    {
        public Storee()
        {
            StorProducts = new HashSet<StorProduct>();

        }

        public decimal Id { get; set; }
        public string StoreName { get; set; }
        public string ImagePath { get; set; }

        public decimal? CategoryId { get; set; }
        [NotMapped] // not map the prop with the table in DB , cause no col with this name 
        public IFormFile ImageFile { get; set; }

        public virtual Categoryy Category { get; set; }
        public virtual ICollection<StorProduct> StorProducts { get; set; }

    }
}
