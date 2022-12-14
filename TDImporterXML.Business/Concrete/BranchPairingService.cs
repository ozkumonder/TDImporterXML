using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Business.Abstract;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Concrete
{
    public class BranchPairingService : IBranchPairingService
    {
        private readonly IBranchPairingDal _branchPairingDal;

        public BranchPairingService(IBranchPairingDal branchPairingDal)
        {
            _branchPairingDal = branchPairingDal;
        }


        public List<MBI_BrachPairing> GetAllBrachPairings()
        {
            return _branchPairingDal.GetList();
        }

        public MBI_BrachPairing GetBrachPairing(int branchPairingId)
        {
            return _branchPairingDal.Get(t=>t.BranchPairingId==branchPairingId);
        }

        public MBI_BrachPairing GetByLogoNr(string branchNr)
        {
            return _branchPairingDal.Get(t => t.LogoBranchNr == branchNr);
        }


        public MBI_BrachPairing AddBrachPairing(MBI_BrachPairing brachPairing)
        {
            return _branchPairingDal.Add(brachPairing);
        }

        public MBI_BrachPairing UpdateBranchPairing(MBI_BrachPairing brachPairing)
        {
          return  _branchPairingDal.Update(brachPairing);
        }

        public bool DeleteBranchPairing(MBI_BrachPairing brachPairing)
        {
          return  _branchPairingDal.Delete(brachPairing);
        }
    }
}
