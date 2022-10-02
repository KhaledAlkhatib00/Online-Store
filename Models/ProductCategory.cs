using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Productts = new HashSet<Productt>();
        }

        public decimal Id { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        [NotMapped] // not map the prop with the table in DB , cause no col with this name 
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<Productt> Productts { get; set; }
    }
}
