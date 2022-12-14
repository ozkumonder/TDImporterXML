using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDImporterXML.Business.Abstract;
using PagedList;
using TDImporterXML.Entities;
using UnityObjects;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class ManageTransferredDataController : Controller
    {
        private readonly ITransferredDataService _tranferredDataService;
        private readonly ILogoService _logoService;
        public ManageTransferredDataController(ITransferredDataService tranferredDataService, ILogoService logoService)
        {
            _tranferredDataService = tranferredDataService;
            _logoService = logoService;
        }
        // GET: ManageTransferredData
        public ActionResult TransferredData(int? page)
        {
            var result = _tranferredDataService.GetAllTransferredData().OrderByDescending(t=>t.TransferId).ToPagedList(page ?? 1, 30);
            return View(result);
        }

        public ActionResult DeleteTransferredData(int id)
        {
            var result = _tranferredDataService.GetTransferredData(id);
            if (result.TransFicheref != null)
            {
                var ficheref = (int)result.TransFicheref;
                var deletedFiche = _logoService.DeleteFiche(ficheref, DataObjectType.doSalesDispatch).State;
                if (deletedFiche)
                {
                    _tranferredDataService.DeleteTransferredData(result);
                }
            }
            return RedirectToAction("TransferredData");
        }
    }
}