using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUITY_STORE.Models
{
    public class UserHomeTable
    {
        public Categoryy categoryy { get; set; }
        public Storee storee { get; set; }
        public StorProduct storproduct { get; set; }
        public Productt product { get; set; }
        public ProductCategory productcategory { get; set; }
    }
}
