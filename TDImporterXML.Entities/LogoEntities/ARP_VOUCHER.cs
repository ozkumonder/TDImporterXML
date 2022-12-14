using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TDImporterXML.Entities.LogoEntities
{
    [XmlRoot(ElementName = "ARP_VOUCHERS")]
    public class ARP_VOUCHERS
    {
        [XmlElement(ElementName = "ARP_VOUCHER")]
        public ARP_VOUCHER ARP_VOUCHER { get; set; }
    }

    [XmlRoot(ElementName = "ARP_VOUCHER")]
    public class ARP_VOUCHER
    {
        public string NUMBER { get; set; }
        public string DATE { get; set; }
        public byte TYPE { get; set; }
        public short DIVISION { get; set; }
        public string NOTES1 { get; set; }
        public double TOTAL_CREDIT { get; set; }
        public string GL_CODE1 { get; set; }
        public string GL_CODE2 { get; set; }
        public byte GL_POSTED { get; set; }
        public uint ACCFICHEREF { get; set; }
        public ushort DATA_REFERENCE { get; set; }
        public TRANSACTIONS TRANSACTIONS { get; set; }
        public byte AFFECT_RISK { get; set; }
        public object DEFNFLDSLIST { get; set; }
        public string DBOP { get; set; }
        public string BANKACC_CODE { get; set; }
        public string GENEXP1 { get; set; }
    }

    [XmlRoot(ElementName = "TRANSACTIONS")]
    public class TRANSACTIONS
    {
        [XmlElement(ElementName = "TRANSACTION")]
        public List<TRANSACTION> TRANSACTION { get; set; }
    }

    [XmlRoot(ElementName = "TRANSACTION")]

    public class TRANSACTION
    {
        public string ARP_CODE { get; set; }
        public string GL_CODE1 { get; set; }
        public string GL_CODE2 { get; set; }
        public string TRANNO { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal CREDIT { get; set; }
        public byte TC_XRATE { get; set; }
        public decimal TC_AMOUNT { get; set; }
        public PAYMENT_LIST PAYMENT_LIST { get; set; }
        public uint DATA_REFERENCE { get; set; }
        public byte MONTH { get; set; }
        public ushort YEAR { get; set; }
        public byte AFFECT_RISK { get; set; }
        public object ORGLOGOID { get; set; }
        public byte DISTRIBUTION_TYPE_FNO { get; set; }
        public object DEFNFLDSLIST { get; set; }
    }

    [XmlRoot(ElementName = "PAYMENT_LIST")]
    public class PAYMENT_LIST
    {
        [XmlElement(ElementName = "PAYMENT")]
        public PAYMENT PAYMENT { get; set; }
    }

    [XmlRoot(ElementName = "PAYMENT")]
    public class PAYMENT
    {
        public string DATE { get; set; }
        public byte MODULENR { get; set; }
        public byte SIGN { get; set; }
        public byte TRCODE { get; set; }
        public decimal TOTAL { get; set; }
        public string PROCDATE { get; set; }
        public byte TRRATE { get; set; }
        public byte DATA_REFERENCE { get; set; }
        public string DISCOUNT_DUEDATE { get; set; }
        public byte PAY_NO { get; set; }
        public object DISCTRLIST { get; set; }
        public byte DISCTRDELLIST { get; set; }
    }
}