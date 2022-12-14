using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using log4net;
using MBUretim.Mvc.Models;
using Quartz;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Core.CrossCuttingConcern.Logger;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.Entities;
using TDImporterXML.RobotPosService.Abstract;

namespace TDImporterXML.Business.Scheduler
{
    public class ImporterJob : IJob
    {
        private readonly IBranchPairingService _branchPairingService;
        private readonly IDocumentTypeService _documentTypeService;
        private readonly ILoggingService _loggingService;
        private readonly ILogoService _logoService;
        private readonly IRobotposService _robotposService;
        private readonly IUnTransferredDataService _unTransferredDataService;
        private readonly IUsersService _usersService;

        public ImporterJob(IRobotposService robotposService, ILogoService logoService, IUsersService usersService,
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
            Logger.Log("Job Execute Başltıldı");
           // _loggingService.Log("execute başladı");
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
            {
                Logger.Log("-------------------------"+branch.LogoBranchNr + " " + branch.BranchName + " verileri aktarılıyor" + "------------------------\n\n");
                foreach (var item in documentType){
                    var sube = _branchPairingService.GetByLogoNr(branch.LogoBranchNr);
                    var xml = _robotposService.GetXmlDataString(securityKey, item.DataTypeId, "LOGO",
                        sube.RobotposBranchNr,
                        sDate, eDate, "1");
                    if (!xml.Contains("error"))
                    {
                        var document = new XmlDocument();
                        document.LoadXml(xml);
                        if (document.DocumentElement != null)
                            result.Add(_logoService.ImportXmlStr(document.DocumentElement.Name, xml,
                                DocumentType.SatisIrsaliye,item.DataTypeName));
                    }
                    else
                    {
                        //_loggingService.Log(sDate + " " + item + " : " + branch.LogoBranchNr + " " +
                        //                    branch.BranchName + item + " : " + "HATA: " + xml +
                        //                    "Kayıt Logoya Aktarılamadı.");
                        Logger.LogError("| Execute Methos |"+sDate + " " + item.DataTypeId + " " + item.DataTypeName + " : " + branch.LogoBranchNr + " " + branch.BranchName + " : " + "HATA: " + xml + "Kayıt Logoya Aktarılamadı.");
                        _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                        {
                            UnTransBranchNumber = branch.LogoBranchNr + " " + branch.BranchName,
                            DataTypeId = item.DataTypeId,
                            DataTypeName = item.DataTypeName,
                            UnTransDate = sDate,
                            UnTransError = xml
                        });
                    }
                    //foreach (var error in result)
                    //    if (error.ErrorMessage == "")
                    //        Logger.Log("İşlem Başarılı:" + " " + error.Result);
                    //    else
                    //        Logger.LogError("Hata: " + error.ErrorMessage);
                }
            }
            Logger.Log("-----------------------------------"+sDate + " tarihli aktarımlar sonu----------------------------------\n");
        }
    }
}