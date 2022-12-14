using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDImporterXML.Entities;

namespace TDImporterXML.MvcUI.ViewModel
{
    public class BranchPairingViewModel
    {
        public List<MBI_BrachPairing> BrachPairings { get; set; }
        public MBI_BrachPairing BrachPairing { get; set; }
    }
}