using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TDImporterXML.Business.Abstract;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class ManageUnTransferredDataController : Controller
    {
        private readonly IUnTransferredDataService _unTransferredDataService;

        public ManageUnTransferredDataController(IUnTransferredDataService unTransferredDataService)
        {
            _unTransferredDataService = unTransferredDataService;
        }

        // GET: ManageUnTransferredData
        public ActionResult UnTransferredData(int? page)
        {
            var result = _unTransferredDataService.GetAllUnTransferredData().OrderByDescending(t => t.UnTransDataId).ToPagedList(page ?? 1, 30);
            return View(result);
        }
    }
}