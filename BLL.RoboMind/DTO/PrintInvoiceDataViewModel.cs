using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RoboMind.DTO
{
    public  class PrintInvoiceDataViewModel
    {
        public MarketDataDto MarketNavigation { get; set; }
        public List<ReceiptDetailsDto> ReceiptDetailsNavigation { get; set; }

    }
}
