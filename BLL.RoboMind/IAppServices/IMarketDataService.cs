using BLL.RoboMind.DTO;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.IAppServices
{
    public  interface IMarketDataService
    {
        //List<SelectListItem> GetSelectListItem();
        //List<SelectListItem> GetSelectListItemMonth();
        // List<MarketDataDto> GeMarketDataSearch(PaidOutSideSearchModel search);

        MarketDataDto GetMarketDataById(int id);
       List<MarketDataDto> GetMarketData();
        void Remove(int id);
        bool EditMarketData(MarketDataDto course);

        bool AddMarketData(MarketDataDto course);
    }
}
