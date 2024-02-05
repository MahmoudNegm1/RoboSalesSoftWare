using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RoboMind.DTO
{
    public class MonthDto
    {
       public int MonthCode { get; set; }
        public string? MonthName { get; set; }
        public string? MonthArabic_Name { get; set; }

    }
}
