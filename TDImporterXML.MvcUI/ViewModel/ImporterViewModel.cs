using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MBUretim.Mvc.Models;
using TDImporterXML.Entities;
using TDImporterXML.Entities.LogoEntities;

namespace TDImporterXML.MvcUI.ViewModel
{
    public class ImporterViewModel
    {
        //public List<MBGOP_ProductOrder> ProductOrders { get; set; }
        public CapiDiv CapiDiv { get; set; }
        public string[] CapiDivNr { get; set; }
        public MBI_DocumentType DocumentType { get; set; }
        public int[] DataType { get; set; }
        public string Sube { get; set; }
        public string Tutar { get; set; }
        public string Tarih { get; set; }
        public List<SALES_DISPATCHES> SalesDispatchess { get; set; }
        public List<SALES_DISPATCHES_DISPATCH_TRANSACTION> SalesDispatchesDispatchs { get; set; }
        public List<SALES_DISPATCHES_DISPATCH_TRANSACTION> SalesDispatchesDispatchTransactions { get; set; }

        public SALES_DISPATCH SalesDispatch { get; set; }
        public SALES_DISPATCH SalesDispatchesDispatch { get; set; }
        public SALES_DISPATCHES_DISPATCH_TRANSACTION SalesDispatchesDispatchTransaction { get; set; }
    }
}