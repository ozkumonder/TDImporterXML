using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Abstract
{
    public interface IBranchPairingService
    {
        List<MBI_BrachPairing> GetAllBrachPairings();
        MBI_BrachPairing GetBrachPairing(int branchPairingId);
        MBI_BrachPairing GetByLogoNr(string branchNr);
        MBI_BrachPairing AddBrachPairing(MBI_BrachPairing brachPairing);
        MBI_BrachPairing UpdateBranchPairing(MBI_BrachPairing brachPairing);
        bool DeleteBranchPairing(MBI_BrachPairing brachPairing);
    }
}