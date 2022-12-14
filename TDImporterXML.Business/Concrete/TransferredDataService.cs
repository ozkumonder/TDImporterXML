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
    public class TransferredDataService : ITransferredDataService
    {
        private readonly ITransferredDataDal _transferredDataDal;

        public TransferredDataService(ITransferredDataDal transferredDataDal)
        {
            _transferredDataDal = transferredDataDal;
        }
        public List<MBI_TransferredData> GetAllTransferredData()
        {
            return _transferredDataDal.GetList();
        }

        public MBI_TransferredData GetTransferredData(int transferredDataId)
        {
            return _transferredDataDal.Get(t => t.TransferId == transferredDataId);
        }

        public MBI_TransferredData AddTransferredData(MBI_TransferredData transferredData)
        {
            return _transferredDataDal.Add(transferredData);
        }

        public MBI_TransferredData UpdateTransferredData(MBI_TransferredData transferredData)
        {
            return _transferredDataDal.Update(transferredData);
        }

        public bool DeleteTransferredData(MBI_TransferredData transferredData)
        {
            return _transferredDataDal.Delete(transferredData);
        }
    }
}
