using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.RoboSalesSoftWare.Entities
{
    public class VegatablesType : IAudit
    {
        [Key]
        public int TypeCode { get; set; }
        public string? Arabic_Name { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        //[ForeignKey("Receipt")]
        //public int? ReceiptCode { get; set; }
        //public Receipt? Receipt { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string? Cover { get; set; }
        //[ForeignKey("MarketDataNavigation")]
        //public int? marketCode { get; set; }
        //public MarketData MarketDataNavigation { get; set; }

    }
}
