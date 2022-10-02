using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class Productt
    {
        public Productt()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StorProducts = new HashSet<StorProduct>();
        }
        
        public decimal Id { get; set; }
        public string Imagepath { get; set; }
        public string Namee { get; set; }
        public decimal? Sale { get; set; }
        public decimal? Price { get; set; }
        public decimal? ProductCategoryId { get; set; }

        [NotMapped] // not map the prop with the table in DB , cause no col with this name 
        public IFormFile ImageFile { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StorProduct> StorProducts { get; set; }
    }
}
