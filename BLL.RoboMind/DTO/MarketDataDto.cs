using BLL.RoboMind.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RoboMind.DTO
{
    public  class MarketDataDto
    {
        public int MarketCode { get; set; }
        [Display(Name = nameof(CommonRes.NameLabel), ResourceType = typeof(CommonRes))]
        public string Name { get; set; }
        [Display(Name = nameof(CommonRes.ArabicNamelabel), ResourceType = typeof(CommonRes))]
        public string ArabicName { get; set; }
        [Display(Name = nameof(CommonRes.AddressLabel), ResourceType = typeof(CommonRes))]
        public string Address { get; set; }

        //  الرقم الضريبي 
        public string MarketSerialCode { get; set; }
        //  رقم المحل  

        public string ShopNumber  { get; set; }

        public string Telephone { get; set; }
    }
}
