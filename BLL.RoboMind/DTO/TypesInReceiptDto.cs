using BLL.RoboMind.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RoboMind.DTO
{
    public  class TypesInReceiptDto
    {
        public int typesCode { get; set; }
        [Display(Name = nameof(CommonRes.NameLabel), ResourceType = typeof(CommonRes))]

        public string Name { get; set; }
        [Display(Name = nameof(CommonRes.ArabicNamelabel), ResourceType = typeof(CommonRes))]

        public string Arabic_Name { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = nameof(CommonRes.PriceLabel), ResourceType = typeof(CommonRes))]

        public decimal Price { get; set; }
        public  decimal Count { get; set; }
    }
}
