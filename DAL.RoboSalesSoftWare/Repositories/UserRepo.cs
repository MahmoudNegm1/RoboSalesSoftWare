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
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext dbContext;

        public UserRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CheckUser(User entity)
        {
         var checke =    dbContext.Users.Any(p => p.UserName == entity.UserName && p.PassWord == entity.PassWord);
            return checke; 
            }

        public bool Edit(User User)
        {
            try
            {
                if (User is not null)
                {
                    dbContext.Entry(User).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public List<User> GetAll()
        {
            var entities = dbContext.Users.ToList();
            return entities;
        }

        public IQueryable<User> GetAllqueryable()
        {
            var entities = dbContext.Users.AsQueryable();
            return entities;
        }

        public User GetById(int id)
        {
            return dbContext.Users.SingleOrDefault(p => p.UserCode == id);
        }

        public List<SelectListItem> GetSelectList()
        {
            return dbContext.Users
                      .Select(c => new SelectListItem { Value = c.UserCode.ToString(), Text = c.UserName })
                      .OrderBy(c => c.Text)
                      .AsNoTracking()
                      .ToList();
        }

   

        public void Remove(int id)
        {
            var Users = dbContext.Users.FirstOrDefault(p => p.UserCode == id);
            dbContext.Users.Remove(Users);
            dbContext.SaveChanges();
        }

        public bool Save(User User)
        {
            try
            {
                dbContext.Users.Add(User);
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
