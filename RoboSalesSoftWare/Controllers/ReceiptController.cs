using AutoMapper;
using BLL.RoboMind.DTO;
using BLL.RoboMind.IAppServices;
using BLL.RoboMind.Resources;
using DAL.RoboSalesSoftWare.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NToastNotify;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
namespace RoboSalesSoftWare.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptServices appService;
        private readonly IToastNotification toastNotification;
        private readonly IMapper mapper;
        private List<ReceiptDto> receiptdto;

        public ReceiptController(IReceiptServices appService, IToastNotification toastNotification, IMapper mapper)
        {
            this.appService = appService;
            this.toastNotification = toastNotification;
            this.mapper = mapper;
        }
        public ActionResult Index()
        {
            var model = appService.GetReceipt();

            TempData["TableData"] = model;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ReceiptDto()
            {
                TypesInReceiptList = appService.GetSelectListItemTypes(),
                VegatablesType = appService.GetAllTypes()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ReceiptDto receipt)
        {
            try
            {
                var Addition = false;
                if (receipt != null)
                {
                    receipt.CreationDate = DateTime.Now;
                    Addition = appService.AddReceipt(receipt);
                }
                if (Addition)
                {
                    toastNotification.AddSuccessToastMessage(CommonRes.SavedSuccessfullyLabel);
                    return View();
                }
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
            }
            catch (Exception ex)
            {
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
            }
            return View();
        }
        [HttpPost]
        public ActionResult SaveReceipt([FromBody] List<ReceiptDto> tableData)
        {
            try
            {
                List<ReceiptDetails> details = new List<ReceiptDetails>();
                var Addition = false;
                var lastOrder = 0;
                if (tableData != null)
                {

                    var receipt = new ReceiptDto();
                    receipt.Total = tableData.Sum(x => x.price * x.Quantity.GetValueOrDefault());
                    receipt.CreationDate = (DateTime.UtcNow.AddHours(+4));
                    appService.AddReceipt(receipt);
                    lastOrder = appService.GetReceipt().LastOrDefault().ReceiptCode;
                    tableData.ForEach(x => x.ReceiptCode = lastOrder);

                    details = mapper.Map<List<ReceiptDetails>>(tableData);

                    Addition = appService.AddReceiptDetails(details);
                }
                if (Addition)
                {
                    toastNotification.AddSuccessToastMessage(CommonRes.SavedSuccessfullyLabel);
                    var model = appService.GetReceipt().Where(p => p.ReceiptCode == lastOrder);
                    return View("PrintInvoice");
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
            var receipt = appService.GetReceiptById(id);
            if (receipt != null)
            {

                appService.SoftDelete(receipt.ReceiptCode);
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
            var receipt = appService.GetReceiptById(id);
            return View(receipt);
        }
        [HttpPost]
        // [Authorize]
        public ActionResult Edit(ReceiptDto receipt)
        {
            try
            {
                receipt.ModificationDate = DateTime.Now;
                var result = appService.EditReceipt(receipt);
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
            }
            catch (Exception ex)
            {
                toastNotification.AddErrorToastMessage(CommonRes.SaveFailedLabel);
                return View();
            }

        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var receipt = appService.GetDetailsFor(id);
                return View(receipt);
            }
            catch (Exception ex) { return View(); }

        }
        [HttpGet]
        public ActionResult PrintInvoice()
        {
            PrintInvoiceDataViewModel model = new PrintInvoiceDataViewModel();

            try
            {
                var market = appService.GetMarket();
                var lastorder = appService.GetReceipt().LastOrDefault().ReceiptCode;

                var model1 = appService.GetDetails(lastorder);

                model.MarketNavigation = market;
                model.ReceiptDetailsNavigation = model1;
            }
            catch (Exception ex)
            {
            }

            return View(model);


        }

        [HttpGet]
        public ActionResult PrintReceipt (int ReceiptCode)
        {
            PrintInvoiceDataViewModel model = new PrintInvoiceDataViewModel();

            try
            {
                var market = appService.GetMarket();

                var model1 = appService.GetDetails(ReceiptCode);
                model.MarketNavigation = market;
                model.ReceiptDetailsNavigation = model1;
            }
            catch (Exception ex)
            {
            }

            return View("PrintInvoice", model);


        }

        [HttpGet]
        public ActionResult GetAllReceipt(SearchFromDateToDateDto model )
        {
            SearchFromDateToDateDto totalIncome = new();  
            try
            {
              totalIncome = appService.GetReceiptPrices(model);
            }
            catch (Exception ex)
            {
            }
            return View(totalIncome);
        }





    }
}
