using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.IRepositories
{
    public  interface IReceiptRepo
    {
        List<Receipt> GetAll();
        IQueryable<Receipt> GetAllqueryable();
        MarketData GetMarket();

        List<SelectListItem> GetSelectList();
        //List<SelectListItem> GetSelectListMonth();
      void SaveReceiptDetails(List<ReceiptDetails> receiptDetails);

        Receipt GetById(int id);
        bool Save(Receipt receipt);
        List<ReceiptDetails> GetReceiptDetails(int id);
        void SoftDelete(int id);
        List<ReceiptDetails> GetReceiptDetailsById(int id);


        void Remove(int id);
        public bool Edit(Receipt receipt);
    }
}
