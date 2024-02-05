using AutoMapper;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.AppServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
           this.mapper = mapper;
        }
        public bool AddUser(UserDto User)
        {
            try {
                if (User is not null) {
                    var entity = mapper.Map<User>(User); 
                var result= unitOfWork.UserRepo.Save(entity); 
                }
                return true; 
                 
            }
            catch(Exception ex)
            {
                return false; 
            } 

        }

        public bool EditUser(UserDto User)
        {
            try
            {
                var entity = mapper.Map<User>(User);
                var sucess = unitOfWork.UserRepo.Edit(entity);
                return sucess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<UserDto> GetUser()
        {
            var entity = unitOfWork.UserRepo.GetAll();

            var model = mapper.Map<List<UserDto>>(entity);
            return model;
        }

        public UserDto GetUserById(int id)
        {
            var entity = unitOfWork.UserRepo.GetById(id);
            var model = mapper.Map<UserDto>(entity);
            return model;
        }

        public bool  CheckUser(UserDto model)
        {
            var result = false;
            try
            {
                var entity = mapper.Map<User>(model);

                result = unitOfWork.UserRepo.CheckUser(entity);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        public void Remove(int id)
        {
            unitOfWork.UserRepo.Remove(id);
        }
    }
}
