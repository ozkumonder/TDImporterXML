using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Core.Utilities.ExtensionMethods;
using TDImporterXML.Entities;
using TDImporterXML.MvcUI.Extensions;
using TDImporterXML.MvcUI.Notification;
using TDImporterXML.MvcUI.ViewModel;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class ManageBranchPairingController : Controller
    {
        private readonly IBranchPairingService _branchPairingService;
        private readonly ILogoService _logoService;

        public ManageBranchPairingController(IBranchPairingService branchPairingService, ILogoService logoService)
        {
            _branchPairingService = branchPairingService;
            _logoService = logoService;
        }

        // GET: BranchPairing
        public ActionResult BranchPairing()
        {
            var result = new BranchPairingViewModel
            {
                BrachPairings = _branchPairingService.GetAllBrachPairings()
            };
            result.BrachPairings.ToPagedList(1, 20).OrderByDescending(x=>x.BranchPairingId);
            return View(result);
        }

        public ActionResult AddBranchPairing(MBI_BrachPairing brachPairing)
        {
            if (!string.IsNullOrEmpty(brachPairing.LogoBranchNr))
            {
                var brancName = _logoService.GetCapiDivName(_logoService.GetFirmNr(),
                    brachPairing.LogoBranchNr.ToInt32());
                if (brancName!=null)
                {
                    _branchPairingService.AddBrachPairing(new MBI_BrachPairing
                    {
                        LogoBranchNr = brachPairing.LogoBranchNr,
                        BranchName = brancName.ToString(),
                        RobotposBranchNr = brachPairing.RobotposBranchNr
                    });
                }
                else
                {
                    this.AddToastMessage("Hata", brachPairing.LogoBranchNr+" nolu bayi bulunamadı", ToastType.Error);
                }
                
            }
            return RedirectToAction("BranchPairing");
        }

        public ActionResult EditBranchPairing(int id)
        {
            var result = new BranchPairingViewModel
            {
                BrachPairing = _branchPairingService.GetBrachPairing(id)
            };

            return PartialView("_EditBranchPairing", result);
        }
        [HttpPost]
        public ActionResult EditBranchPairing(MBI_BrachPairing brachPairing)
        {
            _branchPairingService.UpdateBranchPairing(brachPairing);
            return RedirectToAction("BranchPairing");
        }

        public ActionResult DeleteBranchPairng(int id)
        {
            _branchPairingService.DeleteBranchPairing(_branchPairingService.GetBrachPairing(id));
            return RedirectToAction("BranchPairing");
        }
    }
}