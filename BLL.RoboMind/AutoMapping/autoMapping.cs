using AutoMapper;
using BLL.RoboMind.DTO;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;

namespace BLL.RoboMind.AutoMapping
{
    public class autoMapping:Profile
    {
        public autoMapping()
       {
        //    CreateMap<VegatablesType, VegatablesTypeDto>()
        //        .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover)); // Ignore Cover during mapping

            CreateMap<VegatablesType, VegatablesTypeViewDto>().ReverseMap(); 

            CreateMap<VegatablesTypeDto, VegatablesType>()
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => $"{Guid.NewGuid()}{Path.GetExtension(src.Cover.FileName)}"));

            CreateMap<ReceiptDetails, ReceiptDetailsDto>().ReverseMap();
            CreateMap<ReceiptDetails, ReceiptDetailsViewDto>().ReverseMap();

            CreateMap<VegatablesType, VegatablesTypeViewDetailsDto>(); 


                            CreateMap<VegatablesTypeViewDetailsDto,VegatablesType >()

                .ForMember(dest => dest.Cover, opt => opt.Ignore()); // Ignore Cover during mapping
     
            CreateMap<Receipt, ReceiptDto>().ReverseMap();
            CreateMap<ReceiptDetails, ReceiptDto>().ReverseMap();
            CreateMap<MarketData, MarketDataDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();



        }

    }
}
