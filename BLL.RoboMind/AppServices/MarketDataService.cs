using AutoMapper;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.AppServices
{
    public class MarketDataService : IMarketDataService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MarketDataService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
           this.mapper = mapper;
        }
        public bool AddMarketData(MarketDataDto MarketData)
        {
            try {
                if (MarketData is not null) {
                    var entity = mapper.Map<MarketData>(MarketData); 
                var result= unitOfWork.MarketDataRepo.Save(entity); 
                }
                return true; 
                 
            }
            catch(Exception ex)
            {
                return false; 
            } 

        }

        public bool EditMarketData(MarketDataDto MarketData)
        {
            try
            {
                var entity = mapper.Map<MarketData>(MarketData);
                var sucess = unitOfWork.MarketDataRepo.Edit(entity);
                return sucess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public List<SelectListItem> GetSelectListItem()
        //{
        //    var entities = unitOfWork.MarketDataRepo.GetSelectList();

        //    return entities;
        //}

        public List<MarketDataDto> GetMarketData()
        {
            var entity = unitOfWork.MarketDataRepo.GetAll();

            var model = mapper.Map<List<MarketDataDto>>(entity);
            return model;
        }
  
        public MarketDataDto GetMarketDataById(int id)
        {
            var entity = unitOfWork.MarketDataRepo.GetById(id);
            var model = mapper.Map<MarketDataDto>(entity);
            return model;
        }


        public void Remove(int id)
        {
            unitOfWork.MarketDataRepo.Remove(id);
        }
    }
}
