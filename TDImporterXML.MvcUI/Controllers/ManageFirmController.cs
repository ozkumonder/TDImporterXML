using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Entities;
using TDImporterXML.MvcUI.ViewModel;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class ManageFirmController : Controller
    {
        private readonly IFirmsService _firmsService;

        public ManageFirmController(IFirmsService firmsService)
        {
            _firmsService = firmsService;
        }

        // GET: FirmManager
        public ActionResult Firms(int? page)
        {
            var result = new FirmsViewModel
            {
                Firms = _firmsService.GetAllFirms()
            };
            result.Firms.ToPagedList(page ?? 1, 5);
            return View(result);
        }

        public ActionResult AddFirm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFirm(FirmsViewModel model)
        {
            _firmsService.AddFirm(model.Firm);
            return RedirectToAction("Firms");
        }
        public ActionResult EditFirm(int id)
        {
            var result = new FirmsViewModel
            {
                Firm = _firmsService.GetFirm(id)
            };
            return PartialView("EditFirm", result);
        }
        [HttpPost]
        public ActionResult EditFirm(MBI_Firms firm)
        {
            _firmsService.UpdateFirm(firm);
            return RedirectToAction("Firms");
        }

        public ActionResult DeleteFirm(int id)
        {
            _firmsService.DeleteFirm(_firmsService.GetFirm(id));
            return RedirectToAction("Firms");
        }
        
    }
}