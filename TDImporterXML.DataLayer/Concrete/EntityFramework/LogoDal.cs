using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBUretim.Mvc.Models;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;
using TDImporterXML.Entities.LogoEntities;
using UnityObjects;

namespace TDImporterXML.DataLayer.Concrete.EntityFramework
{
    public class LogoDal : ILogoDal
    {
        private readonly ILoggingService _loggingService;
        private readonly IFirmsDal _firmsDal;
        private readonly IUsersDal _usersDal;
        public const string CapiDiv = @"SELECT CAPIDIV.LOGICALREF AS CAPIDIV_LOGICALREF, CAPIDIV.FIRMNR AS CAPIDIV_FIRMNR, CAPIDIV.NR AS CAPIDIV_NR, CAPIDIV.NAME AS CAPIDIV_NAME FROM L_CAPIDIV CAPIDIV WHERE CAPIDIV.FIRMNR = @FIRMNR AND CAPIDIV.NR NOT IN(0,5,10)";
        public const string GetBranchByNumber = @"SELECT NAME FROM L_CAPIDIV WHERE FIRMNR = @FIRMNR AND NR = @BRANCHNR";

        public const string InvoiceControl = @"SELECT LOGICALREF FROM LG_{0}_{1}_INVOICE WHERE TRCODE = 7 AND DATE_ = @DATE AND DOCODE = @DOCODE AND BRANCH = @BRANCH";
        public const string DispatchControl = @"SELECT LOGICALREF FROM LG_{0}_{1}_STFICHE WHERE TRCODE = 7 AND DATE_ = @DATE AND DOCODE = @DOCODE AND BRANCH = @BRANCH";
        public const string SdTransaction = @"SELECT LOGICALREF FROM LG_{0}_{1}_KSLINES WHERE DATE_ = @DATE AND BRANCH = @BRANCH AND AMOUNT = @AMOUNT";
        public const string ArpVoucher = @"SELECT LOGICALREF FROM LG_{0}_{1}_CLFICHE WHERE TRCODE = 70 AND DATE_ = @DATE AND BRANCH = @BRANCH AND CREDIT = @CREDIT";

        public const string ArpVoucherWithoutCredit =@"SELECT CLFLINE.LOGICALREF,CLFLINE.BANKACCREF,* FROM LG_{0}_{1}_CLFICHE CLFLINE LEFT OUTER JOIN LG_017_BANKACC BANKACC ON BANKACC.LOGICALREF = CLFLINE.BANKACCREF WHERE TRCODE = 70 AND CLFLINE.DATE_ = @DATE AND CLFLINE.BRANCH = @BRANCH AND BANKACC.CODE = @BANKCODE ";
        public const string InvoiceGetById =  @"SELECT CONVERT(VARCHAR,DATE_,105) AS DATE_,FICHENO,BRANCH,DOCODE,NETTOTAL FROM LG_{0}_{1}_INVOICE WHERE LOGICALREF = @LOGICALREF";
        public const string DispatchGetById = @"SELECT CONVERT(VARCHAR,DATE_,105) AS DATE_,FICHENO,BRANCH,DOCODE,NETTOTAL FROM LG_{0}_{1}_STFICHE WHERE LOGICALREF = @LOGICALREF";
        public const string ClFicheGetById =  @"SELECT CONVERT(VARCHAR,DATE_,105) AS DATE_,FICHENO,BRANCH,GENEXP1,CREDIT FROM LG_{0}_{1}_CLFICHE WHERE LOGICALREF = @LOGICALREF";
        public const string KsLinesGetById = @"SELECT CONVERT(VARCHAR,DATE_,105) AS DATE_,FICHENO,BRANCH,LINEEXP,AMOUNT FROM LG_{0}_{1}_KSLINES WHERE LOGICALREF = @LOGICALREF";
            private static string GetConnectionString => ConfigurationManager.ConnectionStrings["TDImporterXMLContext"].ConnectionString;
        public LogoDal(ILoggingService loggingService, IFirmsDal firmsDal, IUsersDal usersDal)
        {
            _loggingService = loggingService;
            _firmsDal = firmsDal;
            _usersDal = usersDal;
        }
        public string ToConvertFirms(string text)
        {
            string firm = GetFirmNr().ToString();//_unityApp.CurrentFirm.ToString();
            string period = "1"; //_unityApp.ActivePeriod.ToString();

            switch (firm.Length)
            {
                case 1: firm = "00" + firm; break;
                case 2: firm = "0" + firm; break;
                default: break;
            }
            switch (period.Length)
            {
                case 1: period = "0" + period; break;
                default: break;
            }


            if (text.Contains("{1}"))
            {
                return String.Format(text, firm, period);
            }
            else
            {
                return String.Format(text, firm);
            }
        }
        public int GetFirmNr()
        {
            return _firmsDal.Get(t => t.IsDefault == true).FirmNr;
        }

        public MBI_Users GetUser()
        {
            return _usersDal.Get();
        }
        public bool ImportXmlStr(string xml){
            var result = false;

            var unityApp = new UnityApplication();
            try
            {
                if (unityApp.Login(GetUser().LogoUserName, GetUser().LogoPassword, GetFirmNr(), 1))
                {
                    IData ms = unityApp.NewDataObject(DataObjectType.doSalesDispatch);
                    if (ms.ImportFromXmlStr("SALES_DISPATCHES", xml))
                    {
                        ms.Post();
                        var recordRef = ms.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                        _loggingService.Log("Başarılı" + recordRef + "LOGICALREF numaralı kayıt");
                        result = true;
                    }
                    else
                    {
                        if (ms.ValidateErrors.Count > 0)
                        {
                            for (int i = 0; i < ms.ValidateErrors.Count - 1; i++)
                            {

                                _loggingService.Log("XML Error:(" + ms.ValidateErrors.ToString() + ") -" + ms.ValidateErrors.ToString());
                            }
                        }
                    }
                }
                else
                {
                    var error = unityApp.GetLastError().ToString() + ":" + unityApp.GetLastErrorString().ToString();
                    _loggingService.Log(error);
                }
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex);
            }
            finally
            {
                unityApp.Disconnect();
                unityApp = null;
            }
            return result;
        }

        public string GetCapiDivName(int firmNr,int branchNr)
        {
            var dt = new DataTable();
            string result;
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(GetBranchByNumber), conn);
            adap.SelectCommand.Parameters.AddWithValue("@FIRMNR", firmNr);
            adap.SelectCommand.Parameters.AddWithValue("@BRANCHNR", branchNr);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
                result = dt.AsEnumerable()
                    .Select(s => s.Field<string>("NAME")).FirstOrDefault();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }

            return result;
        }
        public List<CapiDiv> GetCapiDivs(int firmNr)
        {
            var dt = new DataTable();
            List<CapiDiv> result;
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(CapiDiv), conn);
            adap.SelectCommand.Parameters.AddWithValue("@FIRMNR", firmNr);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
                result = dt.AsEnumerable()
                    .Select(s => new CapiDiv
                    {
                        CAPIDIV_LOGICALREF = s.Field<int>("CAPIDIV_LOGICALREF"),
                        CAPIDIV_FIRMNR = s.Field<short>("CAPIDIV_FIRMNR"),
                        CAPIDIV_NR = s.Field<short>("CAPIDIV_NR"),
                        CAPIDIV_NAME = s.Field<string>("CAPIDIV_NAME")


                    }).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }

            return result;
        }

        public bool InvoiceIsUniq(DateTime date, string doCode, string division)
        {
            var dt = new DataTable();
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(InvoiceControl), conn);
            adap.SelectCommand.Parameters.AddWithValue("@DATE", date);
            adap.SelectCommand.Parameters.AddWithValue("@DOCODE", doCode);
            adap.SelectCommand.Parameters.AddWithValue("@BRANCH", division);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }
            return dt.Rows.Count <= 0;
        }

        public bool DispatchIsUniq(DateTime date, string doCode,  string division)
        {
            var dt = new DataTable();
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(DispatchControl), conn);
            adap.SelectCommand.Parameters.AddWithValue("@DATE", date);
            adap.SelectCommand.Parameters.AddWithValue("@DOCODE", doCode);
            adap.SelectCommand.Parameters.AddWithValue("@BRANCH", division);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }
            return dt.Rows.Count <= 0;
        }

        public bool SdTransactionIsUniq(DateTime date, double netTotal, string division)
        {
            var dt = new DataTable();
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(SdTransaction), conn);
            adap.SelectCommand.Parameters.AddWithValue("@DATE", date);
            adap.SelectCommand.Parameters.AddWithValue("@AMOUNT", netTotal);
            adap.SelectCommand.Parameters.AddWithValue("@BRANCH", division);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }
            return dt.Rows.Count <= 0;
        }

        public bool ArpVoucherIsUniq(DateTime date,  double netTotal, string division)
        {
            var dt = new DataTable();
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(ArpVoucher), conn);
            adap.SelectCommand.Parameters.AddWithValue("@DATE", date);
            adap.SelectCommand.Parameters.AddWithValue("@CREDIT", netTotal);
            adap.SelectCommand.Parameters.AddWithValue("@BRANCH", division);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }
            return dt.Rows.Count <= 0;
        }

        public bool ArpVoucherWithoutCreditIsUniq(DateTime date, string bankCode, string division)
        {
            var dt = new DataTable();
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(ArpVoucherWithoutCredit), conn);
            adap.SelectCommand.Parameters.AddWithValue("@DATE", date);
            adap.SelectCommand.Parameters.AddWithValue("@BRANCH", division);
            adap.SelectCommand.Parameters.AddWithValue("@BANKCODE", bankCode);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }
            return dt.Rows.Count <= 0;
        }

        public SALES_INVOICE GetInvoice(int logicalRef)
        {
            var dt = new DataTable();
            SALES_INVOICE result;
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(InvoiceGetById), conn);
            adap.SelectCommand.Parameters.AddWithValue("@LOGICALREF", logicalRef);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
                result = dt.AsEnumerable().Select(s => new SALES_INVOICE
                {
                    
                    DATE = s.Field<string>("DATE_"),
                    NUMBER = s.Field<string>("FICHENO"),
                    DIVISION = s.Field<short>("BRANCH"),
                    DOC_NUMBER = s.Field<string>("DOCODE"),
                    NETTOTAL = s.Field<double>("NETTOTAL")
                }).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }

            return result;
        }

        public SALES_DISPATCH GetDispatch(int logicalRef)
        {
            var dt = new DataTable();
            SALES_DISPATCH result;
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(DispatchGetById), conn);
            adap.SelectCommand.Parameters.AddWithValue("@LOGICALREF", logicalRef);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
                result = dt.AsEnumerable().Select(s => new SALES_DISPATCH
                {

                    DATE = s.Field<string>("DATE_"),
                    NUMBER = s.Field<string>("FICHENO"),
                    DIVISION = s.Field<short>("BRANCH"),
                    DOC_NUMBER = s.Field<string>("DOCODE"),
                    NETTOTAL = s.Field<double>("NETTOTAL")
                }).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }

            return result;
        }

        public ARP_VOUCHER GetArpVoucher(int logicalRef)
        {
            var dt = new DataTable();
            ARP_VOUCHER result;
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(ClFicheGetById), conn);
            adap.SelectCommand.Parameters.AddWithValue("@LOGICALREF", logicalRef);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
                result = dt.AsEnumerable().Select(s => new ARP_VOUCHER
                {

                    DATE = s.Field<string>("DATE_"),
                    NUMBER = s.Field<string>("FICHENO"),
                    DIVISION = s.Field<short>("BRANCH"),
                    GENEXP1 = s.Field<string>("GENEXP1"),
                    TOTAL_CREDIT = s.Field<double>("CREDIT")
                }).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }

            return result;
        }

        public SD_TRANSACTION GetKsLine(int logicalRef)
        {
            var dt = new DataTable();
            SD_TRANSACTION result;
            var conn = new SqlConnection(GetConnectionString);
            var adap = new SqlDataAdapter(ToConvertFirms(KsLinesGetById), conn);
            adap.SelectCommand.Parameters.AddWithValue("@LOGICALREF", logicalRef);
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                adap.Fill(dt);
                result = dt.AsEnumerable().Select(s => new SD_TRANSACTION
                {
                    
                    DATE = s.Field<string>("DATE_"),
                    NUMBER = s.Field<string>("FICHENO"),
                    DIVISION = s.Field<short>("BRANCH"),
                    LINEEXP = s.Field<string>("LINEEXP"),
                    AMOUNT = s.Field<double>("AMOUNT")
                }).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                conn.Close();

                adap.Dispose();
                conn.Dispose();
                dt.Dispose();
            }

            return result;
        }
    }
}
