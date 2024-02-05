using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.Entities
{
    public  class MarketData
    {
        [Key]
        public int MarketCode { get; set; }
        //  الرقم الضريبي 
        public string MarketSerialCode { get; set; }
        //  رقم المحل  
        public string ShopNumber { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }


    }
}
