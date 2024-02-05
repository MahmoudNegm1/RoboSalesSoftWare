using BLL.RoboMind.DTO;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.IAppServices
{
    public  interface IVegatablesTypeServices
    {
        List<VegatablesTypeViewDto> GetVegatableType();
        List<SelectListItem> GetSelectListItem();
        //List<SelectListItem> GetSelectListItemMonth();
        // List<VegatablesTypeDto> GeVegatableTypeSearch(PaidOutSideSearchModel search);

        VegatablesTypeViewDto GeVegatableTypeById(int id);
        void Remove(int id);
        bool EditVegatableType(VegatablesTypeDto course);

        bool AddVegatableType(VegatablesType course);
    }
}
