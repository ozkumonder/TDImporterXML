using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using MBUretim.Mvc.Models;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Core.CrossCuttingConcern.Logger;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.Core.Utilities.ExtensionMethods;
using TDImporterXML.Core.Utilities.XmlSerilizer;
using TDImporterXML.Entities;
using TDImporterXML.Entities.LogoEntities;
using TDImporterXML.MvcUI.Extensions;
using TDImporterXML.MvcUI.Notification;
using TDImporterXML.MvcUI.ViewModel;
using TDImporterXML.RobotPosService.Abstract;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class ManageImporterController : Controller
    {
        private readonly IBranchPairingService _branchPairingService;
        private readonly IDocumentTypeService _documentTypeService;
        private readonly ILoggingService _loggingService;
        private readonly ILogoService _logoService;
        private readonly IRobotposService _robotposService;
        private readonly IUsersService _usersService;
        private readonly IUnTransferredDataService _unTransferredDataService;


        public ManageImporterController(IRobotposService robotposService, ILogoService logoService,
            IUsersService usersService, IBranchPairingService branchPairingService,
            IDocumentTypeService documentTypeService, ILoggingService loggingService, IUnTransferredDataService unTransferredDataService)
        {
            _robotposService = robotposService;
            _logoService = logoService;
            _usersService = usersService;
            _branchPairingService = branchPairingService;
            _documentTypeService = documentTypeService;
            _loggingService = loggingService;
            _unTransferredDataService = unTransferredDataService;
        }

        // GET: ManageImporter
        public ActionResult Importer()
        {
            var branchs = _branchPairingService.GetAllBrachPairings();
            var documentType = _documentTypeService.GetAllDocumentTypes();
            ViewData["branchs"] = branchs;
            ViewData["types"] = documentType;
            return View();
        }

        [HttpPost]
        public ActionResult Importer(string startDate, string endDate, ImporterViewModel model)
        {
            var result = new List<ResultType>();
            Session["branch"] = model.CapiDivNr;
            Session["dataType"] = model.DataType;
            Session["startDate"] = startDate;
            Session["endDate"] = endDate;
            ViewData["branchs"] = _branchPairingService.GetAllBrachPairings();
            ViewData["types"] = _documentTypeService.GetAllDocumentTypes();
            var userses = _usersService.GetAllUsers().Take(1);
            var securityKey = userses.AsQueryable().Select(x => x.RobotposSecurityKey).FirstOrDefault();
            var documentType = _documentTypeService.GetAllDocumentTypes();
            var sDate = DateTime.Parse(startDate).AddHours(0).AddMinutes(0).AddSeconds(0)
                .ToString("MM/dd/yyyy HH:mm:ss");
            var eDate = DateTime.Parse(endDate).AddHours(23).AddMinutes(59).AddSeconds(59)
                .ToString("MM/dd/yyyy HH:mm:ss");
            var viewModel = new ImporterViewModel();
            var branchs = model.CapiDivNr;
            //var branchArray = string.Join(",", branchs).Trim().Remove(1, 2);

            foreach (var branch in branchs)
            foreach (var item in model.DataType)
            {
                var sube = _branchPairingService.GetByLogoNr(branch);
                var typeName = _documentTypeService.GetAllDocumentTypes().FirstOrDefault(x=>x.DataTypeId==item);
                var xml = _robotposService.GetXmlDataString(securityKey, item, "LOGO", sube.RobotposBranchNr, sDate, eDate, "1");
                var rootKey = string.Empty;
                if (!xml.Contains("error"))
                {
                    var document = new XmlDocument();
                    document.LoadXml(xml);
                    if (document.DocumentElement != null)
                    {
                        rootKey = document.DocumentElement.Name;
                      result.Add( _logoService.ImportXmlStr(document.DocumentElement.Name, xml, DocumentType.SatisIrsaliye, typeName.DataTypeName));

                    }
                }
                else
                {
                    var branchName = string.Empty;
                    var date = string.Empty;
                        if (rootKey == FicheType.SALES_DISPATCHES.ToString())
                    {
                        var dispatches = SerializerXml.Deserialize<SALES_DISPATCHES>(xml);
                        branchName = dispatches.DISPATCH.DIVISION.ToString();
                        date = dispatches.DISPATCH.DATE;
                    }
                    else if (rootKey == FicheType.SALES_INVOICES.ToString())
                    {
                        var invoices = SerializerXml.Deserialize<SALES_INVOICES>(xml);
                        branchName = invoices.INVOICE.DIVISION.ToString();
                        date = invoices.INVOICE.DATE;
                    }
                    else if (rootKey == FicheType.SD_TRANSACTIONS.ToString())
                    {
                        var sdTransactions = SerializerXml.Deserialize<SD_TRANSACTIONS>(xml);
                        branchName = sdTransactions.SD_TRANSACTION.DIVISION.ToString();
                        date = sdTransactions.SD_TRANSACTION.DATE;
                    }
                    else if (rootKey == FicheType.ARP_VOUCHERS.ToString())
                    {
                        var arpVouchers = SerializerXml.Deserialize<ARP_VOUCHERS>(xml);
                        branchName = arpVouchers.ARP_VOUCHER.DIVISION.ToString();
                        date = arpVouchers.ARP_VOUCHER.DATE;
                    }
                    _loggingService.Log(date + " : " + branchName + item + " : " + "HATA: " + xml +
                                        "Kayıt Logoya Aktarılamadı.");
                    Logger.LogError(date + " : " + branchName + item + " : " + "HATA: " + xml +
                                    "Kayıt Logoya Aktarılamadı.");
                    _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                    {
                        UnTransBranchNumber = branchName,
                        DataTypeId = item,
                        UnTransDate = sDate,
                        UnTransError = xml
                    });
                    }
                    
                }
            foreach (var item in result)
            {
                if (item.ErrorMessage == "")
                {
                    this.AddToastMessage("İşlem Başarılı", item.Result.ToString(), ToastType.Success);

                }
                else
                {
                    this.AddToastMessage("Hata", item.ErrorMessage, ToastType.Error);
                }}
            

            return RedirectToAction("TransferredData","ManageTransferredData");
        }
       
    }
}

