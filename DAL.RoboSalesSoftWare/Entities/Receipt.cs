using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.Entities
{
    public class Receipt : IAudit
    {
        [Key]
        public int ReceiptCode { get; set; }

        public decimal price { get; set; }
        public int? marketCode { get; set; }
        public bool IsDeleted { get; set; }
        public List<VegatablesType> VegatablesType { get; set; }
        public decimal Total { get; set; }

        public DateTime CreationDate { get; set ; }
        public DateTime? ModificationDate { get; set; }
    }
}
