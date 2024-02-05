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
    public class VegetablesRepo : IVegetablesRepo
    {
        private readonly AppDbContext dbContext;

        public VegetablesRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Edit(VegatablesType VegatablesType)
        {
            try
            {
                if (VegatablesType is not null)
                {
                    dbContext.Entry(VegatablesType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public List<VegatablesType> GetAll()
        {
            var entities = dbContext.VegatablesTypes.ToList();
            return entities;
        }

        public IQueryable<VegatablesType> GetAllqueryable()
        {
            var entities = dbContext.VegatablesTypes.AsQueryable();
            return entities;
        }

        public VegatablesType GetById(int id)
        {
            return dbContext.VegatablesTypes.SingleOrDefault(p => p.TypeCode == id);
        }

        public List<SelectListItem> GetSelectList()
        {
            return dbContext.VegatablesTypes
                      .Select(c => new SelectListItem { Value = c.TypeCode.ToString(), Text = c.Arabic_Name })
                      .OrderBy(c => c.Text)
                      .AsNoTracking()
                      .ToList();
        }
        public void Remove(int id)
        {
            var VegatablesTypes = dbContext.VegatablesTypes.FirstOrDefault(p => p.TypeCode == id);
            dbContext.VegatablesTypes.Remove(VegatablesTypes);
            dbContext.SaveChanges();
        }
        public bool Save(VegatablesType VegatablesType)
        {
            try
            {
                dbContext.VegatablesTypes.Add(VegatablesType);
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
