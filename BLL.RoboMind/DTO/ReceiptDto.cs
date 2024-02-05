using DAL.RoboSalesSoftWare;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BLL.RoboMind.Resources;

namespace BLL.RoboMind.DTO 
{
    public  class ReceiptDto : IAudit
    {
        public int ReceiptCode { get; set; }
        public int MarketCode { get; set; }

        public int TypeCode { get; set; }
        [Display(Name = nameof(CommonRes.NameLabel), ResourceType = typeof(CommonRes))]

        public string Name { get; set; }
        [Display(Name = nameof(CommonRes.ArabicNamelabel), ResourceType = typeof(CommonRes))]

        public string Arabic_Name { get; set; }
        public bool  IsDeleted { get; set; }
        public decimal price { get; set; }
        public decimal? Quantity { get; set; }

        public decimal Count { get; set; }
        public List<VegatablesTypeViewDto> VegatablesType { get; set; }
        public IEnumerable<SelectListItem> TypesInReceiptList { get; set; } = Enumerable.Empty<SelectListItem>();
        public decimal Total { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        //   public IEnumerable<SelectListItem> MonthsList { get; set; } = Enumerable.Empty<SelectListItem>();

    }


    public class ReceiptDetailsDto
    {
        public int ReceiptDetailsCode { get; set; }
        [ForeignKey("VegatablesTypeNavigation")]
        public int typeCode { get; set; }
        public int Price { get; set; }
        [ForeignKey("ReceiptNavigation")]
        public int ReceiptCode { get; set; }
        public decimal? Quantity { get; set; }


        public ReceiptDto ReceiptNavigation { get; set; }
        public VegatablesTypeViewDetailsDto VegatablesTypeNavigation { get; set; }

    }
    public class ReceiptDetailsViewDto
    {
        public int ReceiptDetailsCode { get; set; }
        [ForeignKey("VegatablesTypeNavigation")]
        public int typeCode { get; set; }
        public decimal? Quantity { get; set; }

        public int Price { get; set; }
        public int ReceiptCode { get; set; }
        public VegatablesTypeViewDetailsDto VegatablesTypeNavigation { get; set; }

    }

}
