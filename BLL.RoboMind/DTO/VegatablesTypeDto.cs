using BLL.RoboMind.Resources;
using DAL.RoboSalesSoftWare;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BLL.RoboMind.DTO
{
    public class VegatablesTypeDto : IAudit
    {
        public int TypeCode { get; set; }
        [Display(Name = nameof(CommonRes.ArabicNamelabel), ResourceType = typeof(CommonRes))]
        public string? Arabic_Name { get; set; }
        [Display(Name = nameof(CommonRes.NameLabel), ResourceType = typeof(CommonRes))]

        public string? Name { get; set; }
        [Display(Name = nameof(CommonRes.PriceLabel), ResourceType = typeof(CommonRes))]

        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [Display(Name = nameof(CommonRes.CoverLabel), ResourceType = typeof(CommonRes))]

        public IFormFile Cover { get; set; }

    }
    public class VegatablesTypeViewDto : IAudit
    {
        public int TypeCode { get; set; }
        [Display(Name = nameof(CommonRes.ArabicNamelabel), ResourceType = typeof(CommonRes))]
        public string? Arabic_Name { get; set; }
        [Display(Name = nameof(CommonRes.NameLabel), ResourceType = typeof(CommonRes))]
        public string? Name { get; set; }
        [Display(Name = nameof(CommonRes.PriceLabel), ResourceType = typeof(CommonRes))]
        public decimal Price { get; set; }
        public decimal? Quantity { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [Display(Name = nameof(CommonRes.CoverLabel), ResourceType = typeof(CommonRes))]
        public string Cover { get; set; }

    }
    public class VegatablesTypeViewDetailsDto : IAudit
    {
        public int TypeCode { get; set; }
        [Display(Name = nameof(CommonRes.ArabicNamelabel), ResourceType = typeof(CommonRes))]

        public string? Arabic_Name { get; set; }
        [Display(Name = nameof(CommonRes.NameLabel), ResourceType = typeof(CommonRes))]

        public string? Name { get; set; }
        [Display(Name = nameof(CommonRes.PriceLabel), ResourceType = typeof(CommonRes))]

        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
