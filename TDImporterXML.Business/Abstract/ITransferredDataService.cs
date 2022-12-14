using System.Collections.Generic;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Abstract
{
    public interface ITransferredDataService
    {
        List<MBI_TransferredData> GetAllTransferredData();
        MBI_TransferredData GetTransferredData(int transferredDataId);
        MBI_TransferredData AddTransferredData(MBI_TransferredData transferredData);
        MBI_TransferredData UpdateTransferredData(MBI_TransferredData transferredData);
        bool DeleteTransferredData(MBI_TransferredData transferredData);
    }
}