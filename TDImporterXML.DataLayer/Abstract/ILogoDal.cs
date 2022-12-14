using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBUretim.Mvc.Models;
using TDImporterXML.Entities.LogoEntities;

namespace TDImporterXML.DataLayer.Abstract
{
   public interface ILogoDal
   {
       bool ImportXmlStr(string xml);
       string GetCapiDivName(int firmNr, int branchNr);
        List<CapiDiv> GetCapiDivs(int firmNr);
       int GetFirmNr();
       bool InvoiceIsUniq(DateTime date, string doCode,  string division);
       bool DispatchIsUniq(DateTime date, string doCode,  string division);
       bool SdTransactionIsUniq(DateTime date, double netTotal, string division);
       bool ArpVoucherIsUniq(DateTime date, double netTotal, string division);
       bool ArpVoucherWithoutCreditIsUniq(DateTime date, string bankCode, string division);
       SALES_INVOICE GetInvoice(int logicalRef);
       SALES_DISPATCH GetDispatch(int logicalRef);
       ARP_VOUCHER GetArpVoucher(int logicalRef);
       SD_TRANSACTION GetKsLine(int logicalRef);

   }
}
