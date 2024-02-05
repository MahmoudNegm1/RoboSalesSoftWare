using BLL.RoboMind.DTO;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.RoboMind.IAppServices
{
    public  interface IReceiptServices
    {
        List<ReceiptDto> GetReceipt();
        List<SelectListItem> GetSelectListItem();
       List<SelectListItem> GetSelectListItemTypes();
        // List<VegatablesTypeDto> GereceiptSearch(PaidOutSideSearchModel search);
        List<VegatablesTypeViewDto> GetAllTypes();
        MarketDataDto GetMarket();

        ReceiptDto GetReceiptById(int id);
        ReceiptDetailsViewDto GetReceiptDetailsById(int id);

        ReceiptDto GetTypeNameAndPrice(ReceiptDto dto);
        SearchFromDateToDateDto GetReceiptPrices(SearchFromDateToDateDto model);

        void Remove(int id);
        void SoftDelete(int id);

        bool EditReceipt(ReceiptDto course);
        bool AddReceiptDetails(List<ReceiptDetails> receiptDetails);

        bool AddReceipt(ReceiptDto course);
        List<ReceiptDetailsDto> GetDetails(int  id);
        List<ReceiptDetailsViewDto> GetDetailsFor(int id);


    }
}
