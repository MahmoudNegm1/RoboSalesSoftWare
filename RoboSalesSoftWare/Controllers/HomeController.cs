using AspNetCore.Reporting;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using RoboSalesSoftWare.Models;
using System.Data;
using System.Diagnostics;

namespace RoboSalesSoftWare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUserService appservice;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment,IUserService appservice)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.appservice = appservice;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult LogIn()
        {

            if (DateTime.Now.Month == 6)
            {
                //  return message; 
                return View("UnAuthorized");
            }

            if (DateTime.Now.Year >=2025)
            {
                //  return message; 
                return View("UnAuthorized");
            }
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(UserDto model)
         {
            string message = "Please Contact Support";
  
            try { var result = appservice.CheckUser(model);
                if (result) {
                    return RedirectToAction(nameof(Index)); 
                }
             } catch (Exception ex )
             {
            
            
            }
            return View();
        }


        public IActionResult Print()
        {
            var dt = new DataTable();
            dt = GetTypesInReceipt();
            string mimeType = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\ReportInvoice.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "rdlc");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("InvoiceDataSet", dt); 
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
            return File(result.MainStream, "application/pdf");
        }
        public DataTable GetTypesInReceipt() {
            List<Type> types = new List<Type>(); 
            var dt = new DataTable();
            dt.Columns.Add("TypeCode");
            dt.Columns.Add("TypeName");
            dt.Columns.Add("price");
            dt.Columns.Add("Total");
            DataRow row;
            for (int i = 0; i <10; i++)
            {
                row = dt.NewRow();
                row["TypeCode"] = "Ahmed ";
                row["TypeName"] = "Ahmed ";
                row["price"] = 121;

                dt.Rows.Add(row);


            }
            return dt; 
        }
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
