using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TDImporterXML.WinUI
{
   

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class SALES_DISPATCHES
        {

            private SALES_DISPATCHES_DISPATCH dISPATCHField;

            /// <remarks/>
            public SALES_DISPATCHES_DISPATCH DISPATCH
            {
                get
                {
                    return this.dISPATCHField;
                }
                set
                {
                    this.dISPATCHField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SALES_DISPATCHES_DISPATCH
        {

            private byte tYPEField;

            private string nUMBERField;

            private string dATEField;

            private uint tIMEField;

            private ulong dOC_NUMBERField;

            private string aRP_CODEField;

            private ushort sOURCE_WHField;

            private string gL_CODEField;

            private ushort sOURCE_COST_GRPField;

            private string nOTES1Field;

            private object pROJECT_CODEField;

            private ushort dIVISIONField;

            private decimal tOTAL_DISCOUNTEDField;

            private SALES_DISPATCHES_DISPATCH_TRANSACTION[] tRANSACTIONSField;

            /// <remarks/>
            public byte TYPE
            {
                get
                {
                    return this.tYPEField;
                }
                set
                {
                    this.tYPEField = value;
                }
            }

            /// <remarks/>
            public string NUMBER
            {
                get
                {
                    return this.nUMBERField;
                }
                set
                {
                    this.nUMBERField = value;
                }
            }

            /// <remarks/>
            public string DATE
            {
                get
                {
                    return this.dATEField;
                }
                set
                {
                    this.dATEField = value;
                }
            }

            /// <remarks/>
            public uint TIME
            {
                get
                {
                    return this.tIMEField;
                }
                set
                {
                    this.tIMEField = value;
                }
            }

            /// <remarks/>
            public ulong DOC_NUMBER
            {
                get
                {
                    return this.dOC_NUMBERField;
                }
                set
                {
                    this.dOC_NUMBERField = value;
                }
            }

            /// <remarks/>
            public string ARP_CODE
            {
                get
                {
                    return this.aRP_CODEField;
                }
                set
                {
                    this.aRP_CODEField = value;
                }
            }

            /// <remarks/>
            public ushort SOURCE_WH
            {
                get
                {
                    return this.sOURCE_WHField;
                }
                set
                {
                    this.sOURCE_WHField = value;
                }
            }

            /// <remarks/>
            public string GL_CODE
            {
                get
                {
                    return this.gL_CODEField;
                }
                set
                {
                    this.gL_CODEField = value;
                }
            }

            /// <remarks/>
            public ushort SOURCE_COST_GRP
            {
                get
                {
                    return this.sOURCE_COST_GRPField;
                }
                set
                {
                    this.sOURCE_COST_GRPField = value;
                }
            }

            /// <remarks/>
            public string NOTES1
            {
                get
                {
                    return this.nOTES1Field;
                }
                set
                {
                    this.nOTES1Field = value;
                }
            }

            /// <remarks/>
            public object PROJECT_CODE
            {
                get
                {
                    return this.pROJECT_CODEField;
                }
                set
                {
                    this.pROJECT_CODEField = value;
                }
            }

            /// <remarks/>
            public ushort DIVISION
            {
                get
                {
                    return this.dIVISIONField;
                }
                set
                {
                    this.dIVISIONField = value;
                }
            }

            /// <remarks/>
            public decimal TOTAL_DISCOUNTED
            {
                get
                {
                    return this.tOTAL_DISCOUNTEDField;
                }
                set
                {
                    this.tOTAL_DISCOUNTEDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("TRANSACTION", IsNullable = false)]
            public SALES_DISPATCHES_DISPATCH_TRANSACTION[] TRANSACTIONS
            {
                get
                {
                    return this.tRANSACTIONSField;
                }
                set
                {
                    this.tRANSACTIONSField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SALES_DISPATCHES_DISPATCH_TRANSACTION
        {

            private byte tYPEField;

            private byte vAT_INCLUDEDField;

            private bool vAT_INCLUDEDFieldSpecified;

            private string mASTER_CODEField;

            private byte dETAIL_LEVELField;

            private bool dETAIL_LEVELFieldSpecified;

            private byte dISCEXP_CALCField;

            private bool dISCEXP_CALCFieldSpecified;

            private ushort sOURCEINDEXField;

            private bool sOURCEINDEXFieldSpecified;

            private ushort sOURCECOSTGRPField;

            private bool sOURCECOSTGRPFieldSpecified;

            private decimal qUANTITYField;

            private decimal tOTALField;

            private bool tOTALFieldSpecified;

            private decimal pRICEField;

            private bool pRICEFieldSpecified;

            private string uNIT_CODEField;

            private byte vAT_RATEField;

            private bool vAT_RATEFieldSpecified;

            /// <remarks/>
            public byte TYPE
            {
                get
                {
                    return this.tYPEField;
                }
                set
                {
                    this.tYPEField = value;
                }
            }

            /// <remarks/>
            public byte VAT_INCLUDED
            {
                get
                {
                    return this.vAT_INCLUDEDField;
                }
                set
                {
                    this.vAT_INCLUDEDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool VAT_INCLUDEDSpecified
            {
                get
                {
                    return this.vAT_INCLUDEDFieldSpecified;
                }
                set
                {
                    this.vAT_INCLUDEDFieldSpecified = value;
                }
            }

            /// <remarks/>
            public string MASTER_CODE
            {
                get
                {
                    return this.mASTER_CODEField;
                }
                set
                {
                    this.mASTER_CODEField = value;
                }
            }

            /// <remarks/>
            public byte DETAIL_LEVEL
            {
                get
                {
                    return this.dETAIL_LEVELField;
                }
                set
                {
                    this.dETAIL_LEVELField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool DETAIL_LEVELSpecified
            {
                get
                {
                    return this.dETAIL_LEVELFieldSpecified;
                }
                set
                {
                    this.dETAIL_LEVELFieldSpecified = value;
                }
            }

            /// <remarks/>
            public byte DISCEXP_CALC
            {
                get
                {
                    return this.dISCEXP_CALCField;
                }
                set
                {
                    this.dISCEXP_CALCField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool DISCEXP_CALCSpecified
            {
                get
                {
                    return this.dISCEXP_CALCFieldSpecified;
                }
                set
                {
                    this.dISCEXP_CALCFieldSpecified = value;
                }
            }

            /// <remarks/>
            public ushort SOURCEINDEX
            {
                get
                {
                    return this.sOURCEINDEXField;
                }
                set
                {
                    this.sOURCEINDEXField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SOURCEINDEXSpecified
            {
                get
                {
                    return this.sOURCEINDEXFieldSpecified;
                }
                set
                {
                    this.sOURCEINDEXFieldSpecified = value;
                }
            }

            /// <remarks/>
            public ushort SOURCECOSTGRP
            {
                get
                {
                    return this.sOURCECOSTGRPField;
                }
                set
                {
                    this.sOURCECOSTGRPField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SOURCECOSTGRPSpecified
            {
                get
                {
                    return this.sOURCECOSTGRPFieldSpecified;
                }
                set
                {
                    this.sOURCECOSTGRPFieldSpecified = value;
                }
            }

            /// <remarks/>
            public decimal QUANTITY
            {
                get
                {
                    return this.qUANTITYField;
                }
                set
                {
                    this.qUANTITYField = value;
                }
            }

            /// <remarks/>
            public decimal TOTAL
            {
                get
                {
                    return this.tOTALField;
                }
                set
                {
                    this.tOTALField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool TOTALSpecified
            {
                get
                {
                    return this.tOTALFieldSpecified;
                }
                set
                {
                    this.tOTALFieldSpecified = value;
                }
            }

            /// <remarks/>
            public decimal PRICE
            {
                get
                {
                    return this.pRICEField;
                }
                set
                {
                    this.pRICEField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool PRICESpecified
            {
                get
                {
                    return this.pRICEFieldSpecified;
                }
                set
                {
                    this.pRICEFieldSpecified = value;
                }
            }

            /// <remarks/>
            public string UNIT_CODE
            {
                get
                {
                    return this.uNIT_CODEField;
                }
                set
                {
                    this.uNIT_CODEField = value;
                }
            }

            /// <remarks/>
            public byte VAT_RATE
            {
                get
                {
                    return this.vAT_RATEField;
                }
                set
                {
                    this.vAT_RATEField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool VAT_RATESpecified
            {
                get
                {
                    return this.vAT_RATEFieldSpecified;
                }
                set
                {
                    this.vAT_RATEFieldSpecified = value;
                }
            }
        }


    
}
