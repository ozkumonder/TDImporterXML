using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDImporterXML.Entities;

namespace TDImporterXML.MvcUI.ViewModel
{
    public class DocumentTypeViewModel
    {
        public List<MBI_DocumentType> DocumentTypes { get; set; }
        public MBI_DocumentType DocumentType { get; set; }
    }
}