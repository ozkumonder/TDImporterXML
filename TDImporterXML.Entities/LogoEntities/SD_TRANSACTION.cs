using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TDImporterXML.Entities.LogoEntities
{

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SD_TRANSACTIONS
    {
        
        public SD_TRANSACTION SD_TRANSACTION { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SD_TRANSACTION
    {
        
        public string NUMBER { get; set; }

        
        public string DATE { get; set; }

        
        public byte TYPE { get; set; }

        
        public short DIVISION { get; set; }

        
        public byte HOUR { get; set; }

        
        public byte MINUTE { get; set; }

        
        public string SD_CODE { get; set; }

        
        public string MASTER_TITLE { get; set; }

        
        public string DESCRIPTION { get; set; }

        
        public byte GL_POSTED { get; set; }

        
        public double AMOUNT { get; set; }

        
        public SD_TRANSACTION_ATTACHMENT_ARP ATTACHMENT_ARP { get; set; }

        
        public string DOC_DATE { get; set; }

        public string LINEEXP { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DBOP { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SD_TRANSACTION_ATTACHMENT_ARP
    {
        
        public SD_TRANSACTION_ATTACHMENT_ARP_TRANSACTION TRANSACTION { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SD_TRANSACTION_ATTACHMENT_ARP_TRANSACTION
    {
        
        public string ARP_CODE { get; set; }

        
        public string GL_CODE1 { get; set; }

        
        public string GL_CODE2 { get; set; }

        
        public string TRANNO { get; set; }

        
        public string DESCRIPTION { get; set; }

        
        public decimal CREDIT { get; set; }

        
        public SD_TRANSACTION_ATTACHMENT_ARP_TRANSACTION_PAYMENT_LIST PAYMENT_LIST { get; set; }

        
        public byte MONTH { get; set; }

        
        public ushort YEAR { get; set; }

        
        public byte AFFECT_RISK { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SD_TRANSACTION_ATTACHMENT_ARP_TRANSACTION_PAYMENT_LIST
    {
        
        public SD_TRANSACTION_ATTACHMENT_ARP_TRANSACTION_PAYMENT_LIST_PAYMENT PAYMENT { get; set; }
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SD_TRANSACTION_ATTACHMENT_ARP_TRANSACTION_PAYMENT_LIST_PAYMENT
    {
        
        public string DATE { get; set; }

        
        public byte MODULENR { get; set; }

        
        public byte SIGN { get; set; }

        
        public byte TRCODE { get; set; }

        
        public decimal TOTAL { get; set; }

        
        public string PROCDATE { get; set; }

        
        public byte PAY_NO { get; set; }
    }


}   