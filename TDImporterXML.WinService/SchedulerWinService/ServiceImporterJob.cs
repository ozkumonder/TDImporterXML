using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using log4net;
using MBUretim.Mvc.Models;
using Quartz;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Business.Scheduler;
using TDImporterXML.Core.CrossCuttingConcern.Logger;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.Core.Utilities.XmlSerilizer;
using TDImporterXML.Entities;
using TDImporterXML.Entities.LogoEntities;
using TDImporterXML.RobotPosService.Abstract;

namespace TDImporterXML.WinService.SchedulerWinService
{
    public class ServiceImporterJob : IJob
    {
        private static ILog log = LogManager.GetLogger(typeof(ImporterJob));
        private readonly IBranchPairingService _branchPairingService;
        private readonly IDocumentTypeService _documentTypeService;
        private readonly ILoggingService _loggingService;
        private readonly ILogoService _logoService;
        private readonly IRobotposService _robotposService;
        private readonly IUnTransferredDataService _unTransferredDataService;
        private readonly IUsersService _usersService;

        public ServiceImporterJob(IRobotposService robotposService, ILogoService logoService,
            IUsersService usersService,
            IBranchPairingService branchPairingService, IDocumentTypeService documentTypeService,
            ILoggingService loggingService, IUnTransferredDataService unTransferredDataService)
        {
            _robotposService = robotposService;
            _logoService = logoService;
            _usersService = usersService;
            _branchPairingService = branchPairingService;
            _documentTypeService = documentTypeService;
            _loggingService = loggingService;
            _unTransferredDataService = unTransferredDataService;
        }

        public void Execute(IJobExecutionContext context)
        {
            Logger.Log("start execute");
            _loggingService.Log("execute başladı");
            var result = new List<ResultType>();
            var userses = _usersService.GetAllUsers().Take(1);
            var securityKey = userses.AsQueryable().Select(x => x.RobotposSecurityKey).FirstOrDefault();
            var documentType = _documentTypeService.GetAllDocumentTypes();
            var sDate = DateTime.Now.Date.AddDays(-1).AddHours(0).AddMinutes(0).AddSeconds(0)
                .ToString("MM/dd/yyyy HH:mm:ss");
            var eDate = DateTime.Now.Date.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59)
                .ToString("MM/dd/yyyy HH:mm:ss");
            var branchs = _branchPairingService.GetAllBrachPairings();

            foreach (var branch in branchs)
            foreach (var item in documentType)
            {
                var sube = _branchPairingService.GetByLogoNr(branch.LogoBranchNr);
                var xml = _robotposService.GetXmlDataString(securityKey, item.DataTypeId, "LOGO", sube.RobotposBranchNr,
                    sDate, eDate, "1");
                var rootKey = string.Empty;
                if (!xml.Contains("error"))
                {
                    var document = new XmlDocument();
                    document.LoadXml(xml);
                    if (document.DocumentElement != null)
                    {
                        rootKey = document.DocumentElement.Name;
                        result.Add(_logoService.ImportXmlStr(document.DocumentElement.Name, xml,
                            DocumentType.SatisIrsaliye,item.DataTypeName));
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
                        DataTypeId = item.DataTypeId,
                        UnTransDate = sDate,
                        UnTransError = xml
                    });
                }
            }
            foreach (var item in result)
                if (item.ErrorMessage == "")
                    Logger.Log("İşlem Başarılı:" + " " + item.Result);
                else
                    Logger.LogError("Hata: " + "" + item.ErrorMessage);
        }
    }
}