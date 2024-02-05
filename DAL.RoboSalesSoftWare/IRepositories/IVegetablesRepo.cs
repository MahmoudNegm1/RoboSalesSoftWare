using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.IRepositories
{
    public  interface IVegetablesRepo
    {
        List<VegatablesType> GetAll();
        IQueryable<VegatablesType> GetAllqueryable();

        List<SelectListItem> GetSelectList();
        //List<SelectListItem> GetSelectListMonth();

        VegatablesType GetById(int id);
        bool Save(VegatablesType paidOutSide);
        void Remove(int id);
        public bool Edit(VegatablesType paidOutSide);
    }
}
