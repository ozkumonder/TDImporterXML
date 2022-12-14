using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Business.Abstract;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Concrete
{
    public class UnTransferredDataService : IUnTransferredDataService
    {
        private readonly IUnTransferredDataDal _unTransferredDataDal;

        public UnTransferredDataService(IUnTransferredDataDal unTransferredDataDal)
        {
            _unTransferredDataDal = unTransferredDataDal;
        }

        public List<MBI_UnTransferredData> GetAllUnTransferredData()
        {
            return _unTransferredDataDal.GetList();
        }

        public MBI_UnTransferredData GetUnTransferredData(int unTransferredData)
        {
            return _unTransferredDataDal.Get(t => t.UnTransDataId == unTransferredData);
        }

        public MBI_UnTransferredData AddUnTransferredData(MBI_UnTransferredData unTransferredData)
        {
            return _unTransferredDataDal.Add(unTransferredData);
        }

        public MBI_UnTransferredData UpdateUnTransferredData(MBI_UnTransferredData unTransferredData)
        {
            return _unTransferredDataDal.Update(unTransferredData);
        }

        public bool DeleteUnTransferredData(MBI_UnTransferredData unTransferredData)
        {
            return _unTransferredDataDal.Delete(unTransferredData);
        }
    }
}
