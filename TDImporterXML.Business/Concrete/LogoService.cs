using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using log4net;
using MBUretim.Mvc.Models;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Business.UnityObject;
using TDImporterXML.Core.CrossCuttingConcern.Logger;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.Core.Utilities.ExtensionMethods;
using TDImporterXML.Core.Utilities.XmlSerilizer;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;
using TDImporterXML.Entities.LogoEntities;
using TDImporterXML.RobotPosService.Abstract;
using UnityObjects;

namespace TDImporterXML.Business.Concrete
{
    public class LogoService : ILogoService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogoService));
        private readonly IBranchPairingService _branchPairingService;
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IFirmsService _firmsService;
        private readonly ILoggingService _loggingService;
        private readonly ILogoDal _logoDal;
        private readonly IRobotposService _robotposService;
        private readonly ITransferredDataService _transferredDataService;
        private readonly IUnTransferredDataService _unTransferredDataService;
        private readonly IUsersService _usersService;


        public LogoService(ILogoDal logoDal, IUnTransferredDataService unTransferredDataService,
            ITransferredDataService transferredDataService, IUsersService usersService, IFirmsService firmsService,
            ILoggingService loggingService, IBranchPairingService branchPairingService,
            IDocumentTypeService documentTypeService, IRobotposService robotposService)
        {
            _logoDal = logoDal;
            _unTransferredDataService = unTransferredDataService;
            _transferredDataService = transferredDataService;
            _usersService = usersService;
            _firmsService = firmsService;
            _loggingService = loggingService;
            _branchPairingService = branchPairingService;
            _documentTypeService = documentTypeService;
            _robotposService = robotposService;
        }

        public ResultType ImportXmlStr(string rootKey, string xml, DocumentType type, string typeName)
        {
            //if (log.IsInfoEnabled) log.Info("Logoya Aktarılamaya Çalışılıyor");
            var result = new ResultType();
            //_loggingService.Log("Logoya Aktarılamaya Çalışılıyor");
            var userses = _usersService.GetAllUsers().Take(1);
            var securityKey = userses.AsQueryable().Select(x => x.RobotposSecurityKey).FirstOrDefault();
            var user = _usersService.GetAllUsers().SingleOrDefault();
            var firm = _firmsService.GetAllFirms().FirstOrDefault(x => x.IsDefault);
            var documentType = _documentTypeService.GetAllDocumentTypes();
            var sDate = DateTime.Now.Date.AddHours(0).AddMinutes(0).AddSeconds(0).ToString("MM/dd/yyyy HH:mm:ss");
            var eDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("MM/dd/yyyy HH:mm:ss");
            var branchs = _branchPairingService.GetAllBrachPairings();
            var branchArray = string.Join(",", branchs).Trim().Remove(1, 2);

            try
            {
                //var unityApp = new UnityApplication();
                UnityApp.unityApp =
                    (UnityApplication)Activator.CreateInstance(
                        Marshal.GetTypeFromCLSID(new Guid("72DB412A-6BF5-4920-A002-2AAC679951DF")));
                Logger.Log("CREATE NEW INSTANCE UNITYAPPLICATION");
                if (UnityApp.unityApp.Login(user.LogoUserName, user.LogoPassword, firm.FirmNr, 0))
                {
                    Logger.Log("LOBJECT LOGIN BAŞARILI");
                    //foreach (var branch in branchs)
                    //{
                    //    foreach (var item in documentType)
                    //    {
                    //var sube = _branchPairingService.GetByLogoNr(branch.LogoBranchNr);
                    //var xml = _robotposService.GetXmlDataString(securityKey, item.DataTypeId, "LOGO",sube.RobotposBranchNr,sDate, eDate, "1");
                    if (!xml.Contains("error"))
                    {
                        var document = new XmlDocument();
                        document.LoadXml(xml);
                        if (document.DocumentElement != null)
                        {
                            //var rootKey = document.DocumentElement.Name;
                            //var result = ImportXmlStr(document.DocumentElement.Name, xml, DocumentType.SatisIrsaliye);

                            #region İrsaliye

                            if (rootKey == FicheType.SALES_DISPATCHES.ToString())
                            {
                                //IData dispatch = unityApp.NewDataObject(DataObjectType.doSalesDispatch);


                                //var salesDispatches = SerializerXml.Deserialize<SALES_DISPATCHES>(xml);
                                //if (dispatch.ImportFromXmlStr("SALES_DISPATCHES", xml))
                                //{
                                //    dispatch.Post();
                                //    var ficheRef = dispatch.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                                //    result.Result = ficheRef;
                                //    if (ficheRef > 0)
                                //    {
                                //        _transferredDataService.AddTransferredData(new MBI_TransferredData
                                //        {
                                //            TransBranchNumber = salesDispatches.DISPATCH.DIVISION.ToString(),
                                //            TransFicheref = ficheRef,
                                //            TransactionDate = salesDispatches.DISPATCH.DATE.ToDateTime(),
                                //            TransData = xml
                                //        });
                                //    }
                                //    else
                                //    {
                                //        _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                //        {
                                //            UnTransBranchNumber = salesDispatches.DISPATCH.DIVISION.ToString(),
                                //            DataTypeId = item.DataTypeId,
                                //            UnTransDate = salesDispatches.DISPATCH.DATE,
                                //            UnTransError =
                                //                "XML Error:(" + dispatch.ValidateErrors.ToString() + ") -" +
                                //                dispatch.ValidateErrors.ToString()
                                //        });
                                //    }
                                //}
                                //else
                                //{
                                //    if (dispatch.ValidateErrors.Count > 0)
                                //    {
                                //        for (int i = 0; i < dispatch.ValidateErrors.Count - 1; i++)
                                //        {
                                //            result.ErrorId = i;
                                //            result.State = false;
                                //            result.ErrorMessage =
                                //                "XML Error:(" + dispatch.ValidateErrors.ToString() + ") -" +
                                //                dispatch.ValidateErrors.ToString();
                                //        }
                                //    }
                                //    _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                //    {
                                //        UnTransBranchNumber = salesDispatches.DISPATCH.DIVISION.ToString(),
                                //        DataTypeId = (int) DocumentType.SatisIrsaliye,
                                //        UnTransDate = salesDispatches.DISPATCH.DATE,
                                //        UnTransError = "XML Error:(" + dispatch.ValidateErrors.ToString() + ") -" +
                                //                       dispatch.ValidateErrors.ToString()
                                //    });
                                //}
                            }

                            #endregion

                            #region  Fatura

                            else if (rootKey == FicheType.SALES_INVOICES.ToString())
                            {
                                var salesInvoices = SerializerXml.Deserialize<SALES_INVOICES>(xml);
                                if (InvoiceIsUniq(salesInvoices.INVOICE.DATE.ToDateTime(), salesInvoices.INVOICE.DOC_NUMBER, salesInvoices.INVOICE.DIVISION.ToString()))
                                {
                                    IData invoice = UnityApp.unityApp.NewDataObject(DataObjectType.doSalesInvoice);
                                    Logger.Log(salesInvoices.INVOICE.DATE + " " + salesInvoices.INVOICE.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılmaya çalışılıyor");
                                    //Logger.Log("Gelen " + rootKey + " Logoya Aktarılmaya Çalışılıyor");
                                    //if (log.IsInfoEnabled) log.Info("Gelen " + rootKey + " Logoya Aktarılmaya Çalışılıyor");
                                    if (invoice.ImportFromXmlStr("SALES_INVOICES", xml))
                                    {
                                        invoice.Post();
                                        var ficheRef = invoice.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                                        result.Result = ficheRef;

                                        if (ficheRef > 0)
                                        {
                                            Logger.Log(ficheRef + " " + "Referanslı" + " " + "Gelen " +
                                                       typeName +
                                                       " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.");
                                            SALES_INVOICE invoiceCheck = GetInvoice(ficheRef);
                                            if (invoiceCheck != null)
                                            {
                                                _transferredDataService.AddTransferredData(new MBI_TransferredData
                                                {
                                                    TransBranchNumber = invoiceCheck.DIVISION.ToString(),
                                                    TransFicheref = ficheRef,
                                                    FicheNo = invoiceCheck.NUMBER,
                                                    TransactionDate = invoiceCheck.DATE,
                                                    Description = invoiceCheck.DOC_NUMBER,
                                                    NetTotal = invoiceCheck.NETTOTAL,
                                                    TransData = xml
                                                });
                                                result.State = true;
                                                result.Result = ficheRef + " " + "Referanslı" + " " + "Gelen " + typeName + " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.";
                                                result.ErrorMessage = "";
                                                result.ErrorId = 0;
                                            }

                                        }else
                                        {
                                            Logger.LogError(salesInvoices.INVOICE.DATE + " " + salesInvoices.INVOICE.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılamadı. Aktarılamayan kayıtlara işlendi.");
                                            var hata = "XML Error:(" + invoice.ValidateErrors + ") -" + invoice.ValidateErrors;
                                            _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                            {
                                                UnTransBranchNumber = salesInvoices.INVOICE.DIVISION.ToString(),
                                                DataTypeId = (int)type,
                                                DataTypeName = typeName,
                                                UnTransDate = salesInvoices.INVOICE.DATE,
                                                UnTransError = typeName + " " + "XML Error:(" + invoice.ValidateErrors + ") -" +
                                                               invoice.ValidateErrors
                                            });
                                            result.State = false;
                                            result.Result = null;
                                            result.ErrorMessage = "Gelen" + " " + rootKey + " " + " Kaydı Logoya Aktarılamadı. Aktarılamayan Kayıtlara İşlendi";
                                            result.ErrorId = 100;
                                        }
                                    }
                                    else
                                    {
                                        if (invoice.ValidateErrors.Count > 0)
                                        {
                                            for (var i = 0; i < invoice.ValidateErrors.Count - 1; i++)
                                            {
                                                result.ErrorId = i;
                                                result.State = false;
                                                result.ErrorMessage =
                                                    "XML Error:(" + invoice.ValidateErrors + ") -" +
                                                    invoice.ValidateErrors;

                                                Logger.LogError(result.ErrorMessage);
                                            }
                                            _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                            {
                                                UnTransBranchNumber = salesInvoices.INVOICE.DIVISION.ToString(),
                                                DataTypeId = (int)type,
                                                DataTypeName = typeName,
                                                UnTransDate = salesInvoices.INVOICE.DATE,
                                                UnTransError = typeName + " " +
                                                               "XML Error:(" + invoice.ValidateErrors + ") -" +
                                                               invoice.ValidateErrors
                                            });
                                            result.State = false;
                                            result.Result = null;
                                            result.ErrorMessage = "XML Error:(" + invoice.ValidateErrors + ") -" + invoice.ValidateErrors;
                                            result.ErrorId = 101;
                                        }
                                    }
                                }
                                else
                                {
                                    result.State = false;
                                    result.ErrorMessage = salesInvoices.INVOICE.DATE + " " + salesInvoices.INVOICE.DIVISION + " " + salesInvoices.INVOICE.DOC_NUMBER + " " + "ait kayıtlar daha önce aktarılmış";
                                    Logger.LogError(typeName + " " + salesInvoices.INVOICE.DATE + " " + salesInvoices.INVOICE.DIVISION + " " + salesInvoices.INVOICE.DOC_NUMBER + " " + "ait kayıtlar daha önce aktarılmış");
                                }
                            }

                            #endregion

                            #region Kasa işlemleri

                            else if (rootKey == FicheType.SD_TRANSACTIONS.ToString())
                            {
                                var salesSdTransactions = SerializerXml.Deserialize<SD_TRANSACTIONS>(xml);
                                if (SdTransactionIsUniq(salesSdTransactions.SD_TRANSACTION.DATE.ToDateTime(),
                                    salesSdTransactions.SD_TRANSACTION.AMOUNT,
                                    salesSdTransactions.SD_TRANSACTION.DIVISION.ToString()))
                                {
                                    IData deposit = UnityApp.unityApp.NewDataObject(DataObjectType.doSafeDepositTrans);
                                    Logger.Log(salesSdTransactions.SD_TRANSACTION.DATE + " " + salesSdTransactions.SD_TRANSACTION.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılmaya çalışılıyor");
                                    if (deposit.ImportFromXmlStr("SD_TRANSACTIONS", xml))
                                    {
                                        deposit.Post();
                                        var ficheRef = deposit.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                                        result.Result = ficheRef;
                                        if (ficheRef > 0)
                                        {
                                            Logger.Log(ficheRef + " " + "Referanslı" + " " + "Gelen " + typeName + " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.");
                                            //Logger.Log(ficheRef + " " + "Referanslı" + " " + "Gelen " + rootKey + " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.");
                                            //if (log.IsInfoEnabled) log.Info("Gelen " + rootKey + " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.");
                                            SD_TRANSACTION ksLine = GetKsLine(ficheRef);
                                            if (ksLine != null)
                                            {
                                                _transferredDataService.AddTransferredData(new MBI_TransferredData
                                                {
                                                    TransBranchNumber = ksLine.DIVISION.ToString(),
                                                    TransFicheref = ficheRef,
                                                    FicheNo = ksLine.NUMBER,
                                                    TransactionDate = ksLine.DATE,
                                                    Description = ksLine.LINEEXP,
                                                    NetTotal = ksLine.AMOUNT,
                                                    TransData = xml
                                                });
                                                result.State = true;
                                                result.Result =
                                                    ficheRef + " " + "Referanslı" + " " + "Gelen " + typeName +
                                                    " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.";
                                                result.ErrorMessage = "";
                                                result.ErrorId = 0;
                                            }

                                        }
                                        else
                                        {
                                            Logger.LogError(salesSdTransactions.SD_TRANSACTION.DATE + " " + salesSdTransactions.SD_TRANSACTION.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılamadı. Aktarılamayan kayıtlara işlendi.");
                                            _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                            {
                                                UnTransBranchNumber =
                                                    salesSdTransactions.SD_TRANSACTION.DIVISION.ToString(),
                                                DataTypeId = (int)type,
                                                DataTypeName = typeName,
                                                UnTransDate = salesSdTransactions.SD_TRANSACTION.DATE,
                                                UnTransError = typeName + " " +
                                                               "XML Error:(" + deposit.ValidateErrors + ") -" +
                                                               deposit.ValidateErrors
                                            });
                                            result.State = false;
                                            result.Result = null;
                                            result.ErrorMessage = "Gelen" + " " + typeName + " " + " Kaydı Logoya Aktarılamadı. Aktarılamayan Kayıtlara İşlendi";
                                            result.ErrorId = 102;
                                        }
                                    }
                                    else
                                    {
                                        if (deposit.ValidateErrors.Count > 0)
                                            for (var i = 0; i < deposit.ValidateErrors.Count - 1; i++)
                                            {
                                                result.ErrorId = i;
                                                result.State = false;
                                                result.ErrorMessage = rootKey + " " +
                                                                      "XML Error:(" + deposit.ValidateErrors + ") -" +
                                                                      deposit.ValidateErrors;
                                                Logger.LogError(result.ErrorMessage);
                                            }
                                        _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                        {
                                            UnTransBranchNumber =
                                                salesSdTransactions.SD_TRANSACTION.DIVISION.ToString(),
                                            DataTypeId = (int)type,
                                            DataTypeName = typeName,
                                            UnTransDate = salesSdTransactions.SD_TRANSACTION.DATE,
                                            UnTransError = typeName + " " +
                                                           "XML Error:(" + deposit.ValidateErrors + ") -" +
                                                           deposit.ValidateErrors
                                        });
                                        result.State = false;
                                        result.Result = null;
                                        result.ErrorMessage = "XML Error:(" + deposit.ValidateErrors + ") -" + deposit.ValidateErrors;
                                        result.ErrorId = 103;
                                    }
                                }
                                else
                                {
                                    result.State = false;
                                    result.ErrorMessage = typeName + " Seçilen tarih ve belge tipine ait kayıtlar daha önce aktarılmış";
                                    Logger.LogError(typeName + " " + salesSdTransactions.SD_TRANSACTION.DATE + " " + salesSdTransactions.SD_TRANSACTION.DIVISION + " " + salesSdTransactions.SD_TRANSACTION.AMOUNT + " " + "ait kayıtlar daha önce aktarılmış");
                                }
                            }

                            #endregion

                            #region Cari Hesap Fişi
                            else if (rootKey == FicheType.ARP_VOUCHERS.ToString())
                            {
                                var salesArpVoucher = SerializerXml.Deserialize<ARP_VOUCHERS>(xml);
                                if (salesArpVoucher.ARP_VOUCHER.TOTAL_CREDIT <= 0)
                                {
                                    #region Cari Hesap Fişi Kredi Kartı Hareletleri

                                    if (ArpVoucherWithoutCreditIsUniq(salesArpVoucher.ARP_VOUCHER.DATE.ToDateTime(),
                                        salesArpVoucher.ARP_VOUCHER.BANKACC_CODE,
                                        salesArpVoucher.ARP_VOUCHER.DIVISION.ToString()))
                                    {
                                        IData voucher = UnityApp.unityApp.NewDataObject(DataObjectType.doARAPVoucher);
                                        Logger.Log(salesArpVoucher.ARP_VOUCHER.DATE + " " + salesArpVoucher.ARP_VOUCHER.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılmaya çalışılıyor");
                                        if (voucher.ImportFromXmlStr("ARP_VOUCHERS", xml))
                                        {
                                            voucher.Post();
                                            var ficheRef = voucher.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                                            result.Result = ficheRef;
                                            if (ficheRef > 0)
                                            {
                                                Logger.Log(ficheRef + " " + "Referanslı" + " " + "Gelen " + rootKey + " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.");
                                                ARP_VOUCHER clfiche = GetArpVoucher(ficheRef);
                                                if (clfiche != null)
                                                {
                                                    _transferredDataService.AddTransferredData(new MBI_TransferredData
                                                    {
                                                        TransBranchNumber = clfiche.DIVISION.ToString(),
                                                        TransFicheref = ficheRef,
                                                        FicheNo = clfiche.NUMBER,
                                                        Description = clfiche.GENEXP1,
                                                        NetTotal = clfiche.TOTAL_CREDIT,
                                                        TransactionDate = salesArpVoucher.ARP_VOUCHER.DATE,
                                                        TransData = xml
                                                    });

                                                    result.State = true;
                                                    result.Result =
                                                        ficheRef + " " + "Referanslı" + " " + "Gelen " + rootKey +
                                                        " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.";
                                                    result.ErrorMessage = "";
                                                    result.ErrorId = 0;
                                                }
                                            }
                                            else
                                            {
                                                Logger.LogError(salesArpVoucher.ARP_VOUCHER.DATE + " " + salesArpVoucher.ARP_VOUCHER.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılamadı. Aktarılamayan kayıtlara işlendi.");
                                                _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                                {
                                                    UnTransBranchNumber =
                                                        salesArpVoucher.ARP_VOUCHER.DIVISION.ToString(),
                                                    DataTypeId = (int)type,
                                                    DataTypeName = typeName,
                                                    UnTransDate = salesArpVoucher.ARP_VOUCHER.DATE,
                                                    UnTransError =
                                                        "XML Error:(" + voucher.ValidateErrors + ") -" +
                                                        voucher.ValidateErrors
                                                });
                                                result.State = false;
                                                result.Result = null;
                                                result.ErrorMessage = "Gelen" + " " + rootKey + " " + " Kaydı Logoya Aktarılamadı. Aktarılamayan Kayıtlara İşlendi";
                                                result.ErrorId = 104;
                                            }
                                        }
                                        else
                                        {
                                            if (voucher.ValidateErrors.Count > 0)
                                                for (var i = 0; i < voucher.ValidateErrors.Count - 1; i++)
                                                {
                                                    result.ErrorId = i;
                                                    result.State = false;
                                                    result.ErrorMessage =
                                                        "XML Error:(" + voucher.ValidateErrors + ") -" +
                                                        voucher.ValidateErrors;
                                                    Logger.LogError(result.ErrorMessage);
                                                    //Logger.LogError(result.ErrorMessage);
                                                    //if (log.IsErrorEnabled) log.Error(result.ErrorMessage);
                                                }
                                            _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                            {
                                                UnTransBranchNumber = salesArpVoucher.ARP_VOUCHER.DIVISION.ToString(),
                                                DataTypeId = (int)type,
                                                DataTypeName = typeName,
                                                UnTransDate = salesArpVoucher.ARP_VOUCHER.DATE,
                                                UnTransError = typeName + " " +
                                                               "XML Error:(" + voucher.ValidateErrors + ") -" +
                                                               voucher.ValidateErrors
                                            });
                                            result.State = false;
                                            result.Result = null;
                                            result.ErrorMessage = "XML Error:(" + voucher.ValidateErrors + ") -" + voucher.ValidateErrors;
                                            result.ErrorId = 105;
                                        }
                                    }
                                    else
                                    {
                                        result.State = false;
                                        result.ErrorMessage =
                                            "Seçilen tarih ve belge tipine ait kayıtlar daha önce aktarılmış";
                                        Logger.LogError(typeName + " " + salesArpVoucher.ARP_VOUCHER.DATE + " " + salesArpVoucher.ARP_VOUCHER.DIVISION + " " + salesArpVoucher.ARP_VOUCHER.TOTAL_CREDIT + " " + "ait kayıtlar daha önce aktarılmış");
                                    }
                                    #endregion
                                }

                                else
                                {
                                    #region Cari Hesap Fişleri Sodexo,Tıcket,SetCard

                                    if (ArpVoucherIsUniq(salesArpVoucher.ARP_VOUCHER.DATE.ToDateTime(),
                                        salesArpVoucher.ARP_VOUCHER.TOTAL_CREDIT,
                                        salesArpVoucher.ARP_VOUCHER.DIVISION.ToString()))
                                    {
                                        IData voucher = UnityApp.unityApp.NewDataObject(DataObjectType.doARAPVoucher);
                                        Logger.Log(salesArpVoucher.ARP_VOUCHER.DATE + " " + salesArpVoucher.ARP_VOUCHER.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılmaya çalışılıyor");
                                        if (voucher.ImportFromXmlStr("ARP_VOUCHERS", xml))
                                        {
                                            voucher.Post();
                                            var ficheRef = voucher.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                                            result.Result = ficheRef;
                                            if (ficheRef > 0)
                                            {
                                                Logger.Log(ficheRef + " " + "Referanslı" + " " + "Gelen " +
                                                           rootKey +
                                                           " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.");

                                                ARP_VOUCHER clfiche = GetArpVoucher(ficheRef);
                                                if (clfiche != null)
                                                {
                                                    _transferredDataService.AddTransferredData(new MBI_TransferredData
                                                    {
                                                        TransBranchNumber = clfiche.DIVISION.ToString(),
                                                        TransFicheref = ficheRef,
                                                        FicheNo = clfiche.NUMBER,
                                                        Description = clfiche.GENEXP1,
                                                        NetTotal = clfiche.TOTAL_CREDIT,
                                                        TransactionDate = salesArpVoucher.ARP_VOUCHER.DATE,
                                                        TransData = xml
                                                    });

                                                    result.State = true;
                                                    result.Result =
                                                        ficheRef + " " + "Referanslı" + " " + "Gelen " + rootKey +
                                                        " Logoya Aktarıldı. Aktarılan Kayıtlara İşlendi.";
                                                    result.ErrorMessage = "";
                                                    result.ErrorId = 0;
                                                }
                                            }
                                            else
                                            {
                                                Logger.LogError(salesArpVoucher.ARP_VOUCHER.DATE + " " + salesArpVoucher.ARP_VOUCHER.DIVISION + "için gelen " + typeName + " kaydı logoya aktarılamadı. Aktarılamayan kayıtlara işlendi.");
                                                
                                                _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                                {
                                                    UnTransBranchNumber =
                                                        salesArpVoucher.ARP_VOUCHER.DIVISION.ToString(),
                                                    DataTypeId = (int)type,
                                                    DataTypeName = typeName,
                                                    UnTransDate = salesArpVoucher.ARP_VOUCHER.DATE,
                                                    UnTransError = typeName + " " +
                                                                   "XML Error:(" + voucher.ValidateErrors + ") -" +
                                                                   voucher.ValidateErrors
                                                });
                                                result.State = false;
                                                result.Result = null;
                                                result.ErrorMessage =
                                                    "Gelen" + " " + typeName + " " +
                                                    " Kaydı Logoya Aktarılamadı. Aktarılamayan Kayıtlara İşlendi";
                                                result.ErrorId = 106;
                                            }
                                        }
                                        else
                                        {
                                            if (voucher.ValidateErrors.Count > 0)
                                                for (var i = 0; i < voucher.ValidateErrors.Count - 1; i++)
                                                {
                                                    result.ErrorId = i;
                                                    result.State = false;
                                                    result.ErrorMessage =
                                                        "XML Error:(" + voucher.ValidateErrors + ") -" +
                                                        voucher.ValidateErrors;
                                                    Logger.LogError(result.ErrorMessage);
                                                }
                                            _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                                            {
                                                UnTransBranchNumber = salesArpVoucher.ARP_VOUCHER.DIVISION.ToString(),
                                                DataTypeId = (int)type,
                                                DataTypeName = typeName,
                                                UnTransDate = salesArpVoucher.ARP_VOUCHER.DATE,
                                                UnTransError =
                                                    "XML Error:(" + voucher.ValidateErrors + ") -" +
                                                    voucher.ValidateErrors
                                            });
                                            result.State = false;
                                            result.Result = null;
                                            result.ErrorMessage = "XML Error:(" + voucher.ValidateErrors + ") -" + voucher.ValidateErrors;
                                            result.ErrorId = 107;
                                        }
                                    }
                                    else
                                    {
                                        result.State = false;
                                        result.ErrorMessage =
                                            "Seçilen tarih ve belge tipine ait kayıtlar daha önce aktarılmış";
                                        Logger.LogError(typeName + " " + salesArpVoucher.ARP_VOUCHER.DATE + " " + salesArpVoucher.ARP_VOUCHER.DIVISION + " " + salesArpVoucher.ARP_VOUCHER.TOTAL_CREDIT + " " + "ait kayıtlar daha önce aktarılmış");
                                    }

                                    #endregion
                                }
                            }

                            #endregion
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
                        //_loggingService.Log(date + " : " + branchName + (int)type + " : " + "HATA: " + xml +
                        //                    "Kayıt Logoya Aktarılamadı.");
                        //Logger.LogError(date + " : " + branchName + (int)type + " : " + "HATA: " + xml +
                        //                "Kayıt Logoya Aktarılamadı.");
                        //if (log.IsErrorEnabled)
                        //    log.Error(date + " : " + branchName + (int)type + " : " + "HATA: " + xml +
                        //              "Kayıt Logoya Aktarılamadı.");
                        _unTransferredDataService.AddUnTransferredData(new MBI_UnTransferredData
                        {
                            UnTransBranchNumber = branchName,
                            DataTypeId = (int)type,
                            DataTypeName = typeName,
                            UnTransDate = sDate,
                            UnTransError = xml
                        });
                        result.ErrorId = 1;
                        result.State = false;
                        result.ErrorMessage = xml;

                    }


                    //    }
                    //}
                }
                else
                {
                    Logger.LogError("LOBJECT LOGIN HATA" + UnityApp.unityApp.GetLastError() + ":" + UnityApp.unityApp.GetLastErrorString());
                    result.ErrorId = 1;
                    result.State = false;
                    result.ErrorMessage = UnityApp.unityApp.GetLastError() + ":" + UnityApp.unityApp.GetLastErrorString();
                    Logger.LogError(result.ErrorMessage);
                    }
                UnityApp.unityApp.Disconnect();
                UnityApp.unityApp = null;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);}
            
            
            return result;
        }

        public string GetCapiDivName(int firmNr, int branchNr)
        {
            return _logoDal.GetCapiDivName(firmNr, branchNr);
        }


        public List<CapiDiv> GetCapiDivs(int firmNr)
        {
            return _logoDal.GetCapiDivs(firmNr);
        }

        public int GetFirmNr()
        {
            return _logoDal.GetFirmNr();
        }

        public ResultType DeleteFiche(int ficheRef, DataObjectType objectType)
        {
            var result = new ResultType();
            var user = _usersService.GetAllUsers().SingleOrDefault();
            var firm = _firmsService.GetAllFirms().FirstOrDefault(x => x.IsDefault);
            var unityApp = new UnityApplication();
            if (unityApp.Login(user.LogoUserName, user.LogoPassword, firm.FirmNr, 0))
            {
                var fiche = unityApp.NewDataObject(objectType);
                if (fiche.Delete(ficheRef))
                {
                    result.ErrorId = 0;
                    result.State = true;
                }
                else
                {
                    result.ErrorId = 1;
                    result.State = false;
                    result.ErrorMessage = "Kayıt Silinemedi";
                }
            }
            else
            {
                result.ErrorId = 2;
                result.State = false;
                result.ErrorMessage = unityApp.GetLastError() + ":" + unityApp.GetLastErrorString();
            }
            unityApp.Disconnect();
            unityApp = null;
            return result;
        }

        public bool InvoiceIsUniq(DateTime date, string doCode, string division)
        {
            return _logoDal.InvoiceIsUniq(date, doCode, division);
        }

        public bool DispatchIsUniq(DateTime date, string doCode, string division)
        {
            return _logoDal.DispatchIsUniq(date, doCode, division);
        }

        public bool SdTransactionIsUniq(DateTime date, double netTotal, string division)
        {
            return _logoDal.SdTransactionIsUniq(date, netTotal, division);
        }

        public bool ArpVoucherIsUniq(DateTime date, double netTotal, string division)
        {
            return _logoDal.ArpVoucherIsUniq(date, netTotal, division);
        }

        public bool ArpVoucherWithoutCreditIsUniq(DateTime date, string bankCode, string division)
        {
            return _logoDal.ArpVoucherWithoutCreditIsUniq(date, bankCode, division);
        }

        public SALES_INVOICE GetInvoice(int logicalRef)
        {
            return _logoDal.GetInvoice(logicalRef);
        }

        public SALES_DISPATCH GetDispatch(int logicalRef)
        {
            return _logoDal.GetDispatch(logicalRef);
        }

        public ARP_VOUCHER GetArpVoucher(int logicalRef)
        {
            return _logoDal.GetArpVoucher(logicalRef);
        }

        public SD_TRANSACTION GetKsLine(int logicalRef)
        {
            return _logoDal.GetKsLine(logicalRef);
        }
    }
}