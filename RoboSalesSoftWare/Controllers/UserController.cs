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
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly IUserService appService;
        private readonly IToastNotification toastNotification;
        private readonly string _imagPath;

        public UserController(IWebHostEnvironment webHostEnvironment ,IMapper mapper,IUserService appService, IToastNotification toastNotification)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
            this.appService = appService;
            this.toastNotification = toastNotification;
          _imagPath = $"{webHostEnvironment.WebRootPath}/Assets/VegetablesIMG"; 
        }
        public ActionResult Index()
        {
            var model = appService.GetUser();
          
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new UserDto() { };
          
            return View(model);
        }
        [HttpPost]
        // [Authorize] 
        [ValidateAntiForgeryToken]
        public async Task< ActionResult>  Create(UserDto User)
        {
            try
            {
                var Addition = false;
                if (User != null)
                {
                    Addition = appService.AddUser(User);
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
            var user = appService.GetUserById(id);
            if (user != null)
            {
                appService.Remove(user.UserCode);
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
            var user = appService.GetUserById(id);
            return View(user);
        }
        [HttpPost]
        // [Authorize]
        public ActionResult Edit(UserDto user)
        {
            try {
                   var result = appService.EditUser(user);
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
            var user = appService.GetUserById(id);
            return View(user);
        }
  

    }
}
