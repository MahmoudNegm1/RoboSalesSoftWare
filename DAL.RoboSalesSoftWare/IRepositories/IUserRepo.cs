using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.IRepositories
{
    public  interface IUserRepo
    {
        List<User> GetAll();
        User GetById(int id);
        bool CheckUser(User entity);
        bool Save(User user);
        void Remove(int id);
        public bool Edit(User user);
    }
}
