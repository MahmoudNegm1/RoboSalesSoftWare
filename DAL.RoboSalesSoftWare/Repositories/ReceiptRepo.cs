using DAL.RoboSalesSoftWare.ApplicationDbContext;
using DAL.RoboSalesSoftWare.Entities;
using DAL.RoboSalesSoftWare.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Receipt = DAL.RoboSalesSoftWare.Entities.Receipt;

namespace DAL.RoboSalesSoftWare.Repositories
{
    public class ReceiptRepo : IReceiptRepo
    {
        private readonly AppDbContext dbContext;

        public ReceiptRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Edit(Receipt receipt)
        {
            try
            {
                if (receipt is not null)
                {
                    dbContext.Entry(receipt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Receipt> GetAll()
        {
            var entities = dbContext.Receipts.Include(p => p.VegatablesType).Where (p=>p.IsDeleted==false).ToList();
            return entities;
        }
        public MarketData GetMarket()
        {
            var entities = dbContext.MarketDatas.FirstOrDefault();
            return entities;
        }


        public void  SaveReceiptDetails( List<ReceiptDetails> receiptDetails)
        {
             foreach (var receipt in receiptDetails)
            {
                var entities = dbContext.ReceiptDetailss.Add(receipt);
                dbContext.SaveChanges(); 
            }

        }
        public IQueryable<Receipt> GetAllqueryable()
        {
            var entities = dbContext.Receipts.Include(p=>p.VegatablesType).AsQueryable();
            return entities;
        }

        public Receipt GetById(int id)
        {
            return dbContext.Receipts.Include(p => p.VegatablesType).SingleOrDefault(p => p.ReceiptCode == id);
        }

        public List< ReceiptDetails> GetReceiptDetailsById(int id)
        {
            return dbContext.ReceiptDetailss.Include(p => p.VegatablesTypeNavigation).Where(p => p.ReceiptCode == id).ToList();
        }
        public List<SelectListItem> GetSelectList()
        {
            return dbContext.VegatablesTypes
                      .Select(c => new SelectListItem { Value = c.TypeCode.ToString(), Text = c.Arabic_Name })
                      .OrderBy(c => c.Text)
                      .AsNoTracking()
                      .ToList();
        }

        //public List<SelectListItem> GetSelectListMonth()
        //{
        //    return dbContext.Months
        //              .Select(c => new SelectListItem { Value = c.MonthCode.ToString(), Text = c.MonthArabic_Name })
        //              .OrderBy(c => c.Value)
        //              .AsNoTracking()
        //    .ToList();
        //}

        public void Remove(int id)
        {
            var receipt = dbContext.Receipts.Include(p => p.VegatablesType).FirstOrDefault(p => p.ReceiptCode == id);
            dbContext.Receipts.Remove(receipt);
            dbContext.SaveChanges();
        }
        public void SoftDelete(int id)
        {
            var receipt = dbContext.Receipts.FirstOrDefault(p => p.ReceiptCode == id);
            receipt.IsDeleted = true;
            dbContext.Entry(receipt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public List<ReceiptDetails> GetReceiptDetails(int id)
        {
            var list = dbContext.ReceiptDetailss.Include(p=>p.ReceiptNavigation)
                   .Include(p => p.VegatablesTypeNavigation).Where(p => p.ReceiptCode == id).ToList();

            return list; 
        }

        public bool Save(Receipt receipt)
        {
            try
            {
                dbContext.Receipts.Add(receipt);
                dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
