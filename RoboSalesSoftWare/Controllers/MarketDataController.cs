using AutoMapper;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using BLL.RoboMind.Resources;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.IO; 
namespace RoboSalesSoftWare.Controllers
{
    public class MarketDataController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly IMarketDataService appService;
        private readonly IToastNotification toastNotification;
        private readonly string _imagPath;

        public MarketDataController(IWebHostEnvironment webHostEnvironment ,IMapper mapper,IMarketDataService appService, IToastNotification toastNotification)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
            this.appService = appService;
            this.toastNotification = toastNotification;
          _imagPath = $"{webHostEnvironment.WebRootPath}/Assets/VegetablesIMG"; 
        }
        public ActionResult Index()
        {
            var model = appService.GetMarketData();
          
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new MarketDataDto() { };
          
            return View(model);
        }
        [HttpPost]
        // [Authorize] 
        [ValidateAntiForgeryToken]
        public async Task< ActionResult>  Create(MarketDataDto marketData)
        {
            try
            {
                var Addition = false;
                if (marketData != null)
                {
                    if (marketData.MarketSerialCode == null)
                    {
                        marketData.MarketSerialCode = "";
                    }
                    Addition = appService.AddMarketData(marketData);
                }
                if (Addition)
                {
                    toastNotification.AddSuccessToastMessage(CommonRes.SavedSuccessfullyLabel);
                    return RedirectToAction(nameof(Index));
                }
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
            }
            catch (Exception ex)
            {
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
            }
            return View();
        }
        [HttpGet]
        // [Authorize]
        public ActionResult Delete(int id)
        {
            var vegatablesType = appService.GetMarketDataById(id);
            if (vegatablesType != null)
            {
                appService.Remove(vegatablesType.MarketCode);
                toastNotification.AddSuccessToastMessage(CommonRes.SavedSuccessfullyLabel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
                return View();

            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vegatablesType = appService.GetMarketDataById(id);
            return View(vegatablesType);
        }
        [HttpPost]
        // [Authorize]
        public ActionResult Edit(MarketDataDto vegatablesType)
        {
            try {
                   var result = appService.EditMarketData(vegatablesType);
            if (result)
            {
                toastNotification.AddSuccessToastMessage(CommonRes.SavedSuccessfullyLabel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
                return View();
            }
            } catch ( Exception ex ) {
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);

                return View();

            }

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vegatablesType = appService.GetMarketDataById(id);
            return View(vegatablesType);
        }
  

    }
}
