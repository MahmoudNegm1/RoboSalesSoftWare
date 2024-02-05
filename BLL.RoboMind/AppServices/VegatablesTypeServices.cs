using AutoMapper;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.AppServices
{
    public class VegatablesTypeServices : IVegatablesTypeServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VegatablesTypeServices(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
           this.mapper = mapper;
        }
        public bool AddVegatableType(VegatablesType vegatablesType)
        {
            try {
                if (vegatablesType is not null) {

                var result= unitOfWork.VegetablesRepo.Save(vegatablesType); 
                }
                return true; 
                 
            }
            catch(Exception ex)
            {
                return false; 
            } 

        }

        public bool EditVegatableType(VegatablesTypeDto vegatablesType)
        {
            try
            {
                var entity = mapper.Map<VegatablesType>(vegatablesType);
                var sucess = unitOfWork.VegetablesRepo.Edit(entity);
                return sucess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SelectListItem> GetSelectListItem()
        {
            var entities = unitOfWork.VegetablesRepo.GetSelectList();

            return entities;
        }

        public List<VegatablesTypeViewDto> GetVegatableType()
        {
            var entity = unitOfWork.VegetablesRepo.GetAll();

            var model = mapper.Map<List<VegatablesTypeViewDto>>(entity);
            return model;
        }
  
        public VegatablesTypeViewDto GeVegatableTypeById(int id)
        {
            var entity = unitOfWork.VegetablesRepo.GetById(id);
            var model = mapper.Map<VegatablesTypeViewDto>(entity);
            return model;
        }


        public void Remove(int id)
        {
            unitOfWork.VegetablesRepo.Remove(id);
        }
    }
}
