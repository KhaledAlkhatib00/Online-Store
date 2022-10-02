using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUITY_STORE.Models
{
    public class ReportTable
    {
        public Login userLogin { get; set; }
        public Userr userr { get; set; }
        public Orderr order { get; set; }
        public OrderProduct orderProduct { get; set; }
        public Productt productt { get; set; }
        public ProductCategory productCategory { get; set; }
    
    }
}
