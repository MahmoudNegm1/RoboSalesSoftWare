using DAL.RoboSalesSoftWare.ApplicationDbContext;
using DAL.RoboSalesSoftWare.Entities;
using DAL.RoboSalesSoftWare.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.Repositories
{
    public class MarketRepo : IMarketDataRepo
    {
        private readonly AppDbContext dbContext;

        public MarketRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Edit(MarketData marketData)
        {
            try
            {
                if (marketData is not null)
                {
                    dbContext.Entry(marketData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public List<MarketData> GetAll()
        {
            var entities = dbContext.MarketDatas.ToList();
            return entities;
        }

        public IQueryable<MarketData> GetAllqueryable()
        {
            var entities = dbContext.MarketDatas.AsQueryable();
            return entities;
        }

        public MarketData GetById(int id)
        {
            return dbContext.MarketDatas.SingleOrDefault(p => p.MarketCode == id);
        }

        public List<SelectListItem> GetSelectList()
        {
            return dbContext.MarketDatas
                      .Select(c => new SelectListItem { Value = c.MarketCode.ToString(), Text = c.ArabicName })
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
            var MarketDatas = dbContext.MarketDatas.FirstOrDefault(p => p.MarketCode == id);
            dbContext.MarketDatas.Remove(MarketDatas);
            dbContext.SaveChanges();
        }

        public bool Save(MarketData MarketData)
        {
            try
            {
                dbContext.MarketDatas.Add(MarketData);
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
