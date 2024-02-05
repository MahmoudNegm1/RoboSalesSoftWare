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
    public class VegatablesTypeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly IVegatablesTypeServices appService;
        private readonly IToastNotification toastNotification;
        private readonly string _imagPath;

        public VegatablesTypeController(IWebHostEnvironment webHostEnvironment ,IMapper mapper,IVegatablesTypeServices appService, IToastNotification toastNotification)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
            this.appService = appService;
            this.toastNotification = toastNotification;
          _imagPath = $"{webHostEnvironment.WebRootPath}/Assets/VegetablesIMG"; 
        }
        public ActionResult Index()
        {
            var model = appService.GetVegatableType();
          
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new VegatablesTypeDto() { };
          
            return View(model);
        }
        [HttpPost]
        // [Authorize] 
        [ValidateAntiForgeryToken]
        public async Task< ActionResult>  Create(VegatablesTypeDto vegatablesType)
        {
            try
            {
                var Addition = false;
                if (vegatablesType != null)
                {
                    vegatablesType.CreationDate = DateTime.Now;
                    var coverName = $"{Guid.NewGuid()}{Path.GetExtension(vegatablesType.Cover.FileName)}";
                    var path = Path.Combine(_imagPath, coverName);
                    using var stream = System.IO.File.Create(path);
                    await vegatablesType.Cover.CopyToAsync(stream);
                    stream.Dispose();

                    var entity = mapper.Map<VegatablesType>(vegatablesType);
                    entity.Cover = coverName;
                    Addition = appService.AddVegatableType(entity);
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
            var vegatablesType = appService.GeVegatableTypeById(id);
            if (vegatablesType != null)
            {
                appService.Remove(vegatablesType.TypeCode);
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
            var vegatablesType = appService.GeVegatableTypeById(id);
            return View(vegatablesType);
        }
        [HttpPost]
        // [Authorize]
        public async Task< ActionResult>  Edit(VegatablesTypeDto vegatablesType)
        {
            try {
                vegatablesType.ModificationDate = DateTime.Now; vegatablesType.CreationDate = DateTime.Now;
                var coverName = $"{Guid.NewGuid()}{Path.GetExtension(vegatablesType.Cover.FileName)}";
                var path = Path.Combine(_imagPath, coverName);
                using var stream = System.IO.File.Create(path);
                await vegatablesType.Cover.CopyToAsync(stream);
                stream.Dispose();

                var entity = mapper.Map<VegatablesType>(vegatablesType);
                entity.Cover = coverName;

                var result = appService.EditVegatableType(vegatablesType);
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
            var vegatablesType = appService.GeVegatableTypeById(id);
            return View(vegatablesType);
        }
        [HttpGet]
        public ActionResult GetTypesPriceById(int id)
        {
            var price = appService.GeVegatableTypeById(id).Price;
            return Json(price);
        }


    }
}
