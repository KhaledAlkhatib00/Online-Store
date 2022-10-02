using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TUITY_STORE.Models
{
    public partial class HomeImage
    {
        public decimal Id { get; set; }
        public string ImagePath { get; set; }
        public string name { get; set; }
        [NotMapped] // not map the prop with the table in DB , cause no col with this name 
        public IFormFile ImageFile { get; set; }
    }
}
