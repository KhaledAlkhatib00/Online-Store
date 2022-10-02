using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUITY_STORE.Models
{
    public class StoresPrductTable
    {
        public Storee store { get; set; }
        public StorProduct storProduct { get; set; }
        public Productt productt { get; set; }
        public ProductCategory productCategory { get; set; }
    }
}
