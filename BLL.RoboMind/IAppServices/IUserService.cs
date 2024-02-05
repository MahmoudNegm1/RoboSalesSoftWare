using BLL.RoboMind.DTO;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.IAppServices
{
    public  interface IUserService
    {
        //List<SelectListItem> GetSelectListItem();
        //List<SelectListItem> GetSelectListItemMonth();
        // List<UserDto> GeUserSearch(PaidOutSideSearchModel search);

        UserDto GetUserById(int id);
       List<UserDto> GetUser();
        void Remove(int id);
        bool EditUser(UserDto course);
        bool CheckUser(UserDto model);

        bool AddUser(UserDto course);
    }
}
