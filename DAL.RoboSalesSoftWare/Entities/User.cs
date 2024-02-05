using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.Entities
{
    public  class User
    {
        [Key]
        public int UserCode { get; set; }
        public string UserName  { get; set; }
        public string PassWord { get; set; }

    }
}
