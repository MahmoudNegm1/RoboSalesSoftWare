using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare
{
    public  interface IAudit
    {
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate  { get; set; }

    }
}
