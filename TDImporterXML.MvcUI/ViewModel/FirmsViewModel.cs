using System.Collections.Generic;
using TDImporterXML.Entities;

namespace TDImporterXML.MvcUI.ViewModel
{
    public class FirmsViewModel
    {
        public List<MBI_Firms> Firms { get; set; }
        public MBI_Firms Firm { get; set; }
    }
}