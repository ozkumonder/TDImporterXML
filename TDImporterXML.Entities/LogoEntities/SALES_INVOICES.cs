using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

/// 
namespace TDImporterXML.Entities.LogoEntities
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SALES_INVOICES
    {
        public SALES_INVOICE INVOICE { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SALES_INVOICE
    {
       


        public byte TYPE { get; set; }

        public string NUMBER { get; set; }
        
        public string DATE { get; set; }

        
        public uint TIME { get; set; }

        
        public string DOC_NUMBER { get; set; }

        
        public string ARP_CODE { get; set; }

        
        public ushort SOURCE_WH { get; set; }

        
        public string GL_CODE { get; set; }

        
        public ushort SOURCE_COST_GRP { get; set; }

        
        public string NOTES1 { get; set; }

        
        public object PROJECT_CODE { get; set; }

        
        public short DIVISION { get; set; }

        
        public decimal TOTAL_DISCOUNTED { get; set; }

        public double NETTOTAL { get; set; }

        
        [System.Xml.Serialization.XmlArrayItemAttribute("TRANSACTION", IsNullable = false)]
        public SALES_INVOICES_INVOICE_TRANSACTION[] TRANSACTIONS { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SALES_INVOICES_INVOICE_TRANSACTION
    {
        
        public byte TYPE { get; set; }

        
        public byte VAT_INCLUDED { get; set; }

        
        public string MASTER_CODE { get; set; }

        
        public byte DETAIL_LEVEL { get; set; }

        
        public byte DISCEXP_CALC { get; set; }

        
        public ushort SOURCEINDEX { get; set; }

        
        public ushort SOURCECOSTGRP { get; set; }

        
        public decimal QUANTITY { get; set; }

        
        public decimal TOTAL { get; set; }

        
        public string GL_CODE1 { get; set; }

        
        public string GL_CODE2 { get; set; }

        
        public decimal PRICE { get; set; }
        

        
        public string UNIT_CODE { get; set; }

        
        public byte VAT_RATE { get; set; }
    }


}