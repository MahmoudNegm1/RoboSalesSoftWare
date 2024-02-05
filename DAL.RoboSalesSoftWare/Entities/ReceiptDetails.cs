using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.Entities
{
    public class ReceiptDetails
    {
        [Key]
        public int ReceiptDetailsCode { get; set; }
        [ForeignKey("VegatablesTypeNavigation")]
        public int typeCode { get; set; }
        public decimal? Quantity { get; set; }

        public int Price { get; set; }
        [ForeignKey("ReceiptNavigation")]
        public int ReceiptCode { get; set; }
        public Receipt ReceiptNavigation { get; set; }
        public VegatablesType VegatablesTypeNavigation { get; set; }

    }
}
