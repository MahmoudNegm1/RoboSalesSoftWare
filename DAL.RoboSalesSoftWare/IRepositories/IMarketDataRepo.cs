using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.IRepositories
{
    public  interface IMarketDataRepo
    {
        List<MarketData> GetAll();
        MarketData GetById(int id);
        bool Save(MarketData paidOutSide);
        void Remove(int id);
        public bool Edit(MarketData paidOutSide);
    }
}
