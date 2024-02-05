using AutoMapper;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace BLL.RoboMind.AppServices
{
    public class ReceiptServices : IReceiptServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReceiptServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public List<ReceiptDetailsDto> GetDetails(int id)
        {
            List<ReceiptDetailsDto> dto = new List<ReceiptDetailsDto>();
            try
            {
                var entities = unitOfWork.ReceiptRepo.GetReceiptDetails(id);

                dto = mapper.Map<List<ReceiptDetailsDto>>(entities);
                return dto;
            }
            catch (Exception ex)

            { return dto; }

        }
        public List<ReceiptDetailsViewDto> GetDetailsFor(int id)
        {
            List<ReceiptDetailsViewDto> dto = new List<ReceiptDetailsViewDto>();
            try
            {
                var entities = unitOfWork.ReceiptRepo.GetReceiptDetails(id);

                dto = mapper.Map<List<ReceiptDetailsViewDto>>(entities);
                return dto;
            }
            catch (Exception ex)

            { return dto; }

        }

        public bool AddReceipt(ReceiptDto vegatablesType)
        {
            try
            {
                if (vegatablesType is not null)
                {
                    var entity = mapper.Map<Receipt>(vegatablesType);
                    var result = unitOfWork.ReceiptRepo.Save(entity);
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddReceiptDetails(List<ReceiptDetails> receiptDetails)
        {
            try
            {
                var receipt = unitOfWork.ReceiptRepo.GetAll().LastOrDefault().ReceiptCode;
                unitOfWork.ReceiptRepo.SaveReceiptDetails(receiptDetails);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool EditReceipt(ReceiptDto vegatablesType)
        {
            try
            {
                var entity = mapper.Map<Receipt>(vegatablesType);
                var sucess = unitOfWork.ReceiptRepo.Edit(entity);
                return sucess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SelectListItem> GetSelectListItem()
        {
            var entities = unitOfWork.ReceiptRepo.GetSelectList();

            return entities;
        }

        public List<SelectListItem> GetSelectListItemTypes()
        {
            var entities = unitOfWork.VegetablesRepo.GetSelectList();
            return entities;
        }
        public List<ReceiptDto> GetReceipt()
        {
            var entity = unitOfWork.ReceiptRepo.GetAll();
            var model = mapper.Map<List<ReceiptDto>>(entity);
            return model;
        }
        public SearchFromDateToDateDto GetReceiptPrices(SearchFromDateToDateDto Srch)
        {
            var entity = unitOfWork.ReceiptRepo.GetAll();
            var model = mapper.Map<List<ReceiptDto>>(entity);

            List<ReceiptDto> model1 = new List<ReceiptDto>();
             
            if (Srch != null)
            {
                if (Srch.FromDate.HasValue)
                {
                    model1 = model.Where(p => p.CreationDate >= Srch.FromDate).ToList();
                    if (Srch.ToDate.HasValue)
                    {
                        model1 = model.Where(p => p.CreationDate <= Srch.ToDate).ToList();
                    }

                }
                else if (Srch.ToDate.HasValue)
                {
                    model1 = model1.Where(p => p.CreationDate <= Srch.ToDate).ToList();

                    if (Srch.FromDate.HasValue)
                    {
                        model1 = model.Where(p => p.CreationDate >= Srch.FromDate).ToList();
                    }

                }else
                {
                    model1 = model; 
                }



            }

            Srch.Total = model1.Sum(p => p.Total); 
            return Srch;
        }
        public MarketDataDto GetMarket()
        {
            var entity = unitOfWork.ReceiptRepo.GetMarket();
            var model = mapper.Map<MarketDataDto>(entity);
            return model;
        }

        public ReceiptDto GetReceiptById(int id)
        {
            var entity = unitOfWork.ReceiptRepo.GetById(id);
            var model = mapper.Map<ReceiptDto>(entity);
            return model;
        }
        public ReceiptDetailsViewDto GetReceiptDetailsById(int id)
        {
            var entity = unitOfWork.ReceiptRepo.GetReceiptDetailsById(id);
            var model = mapper.Map<ReceiptDetailsViewDto>(entity);
            return model;
        }
        public ReceiptDto GetTypeNameAndPrice(ReceiptDto dto)
        {
            ReceiptDto re = new ReceiptDto();

            var item = unitOfWork.VegetablesRepo.GetById(dto.TypeCode);
            re.Arabic_Name = item.Arabic_Name;
            re.Name = item.Name;
            re.TypeCode = item.TypeCode;

            return re;
        }

        public void Remove(int id)
        {
            unitOfWork.ReceiptRepo.Remove(id);
        }

        public void SoftDelete(int id)
        {
            unitOfWork.ReceiptRepo.Remove(id);
        }

        public List<VegatablesTypeViewDto> GetAllTypes()
        {
            var entities = unitOfWork.VegetablesRepo.GetAll();
            var models = mapper.Map<List<VegatablesTypeViewDto>>(entities);
            return models;
        }
    }
}
