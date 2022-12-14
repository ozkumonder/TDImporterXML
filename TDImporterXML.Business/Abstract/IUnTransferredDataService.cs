using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Abstract
{
 public   interface IUnTransferredDataService
    {
        List<MBI_UnTransferredData> GetAllUnTransferredData();
        MBI_UnTransferredData GetUnTransferredData(int unTransferredData);
        MBI_UnTransferredData AddUnTransferredData(MBI_UnTransferredData unTransferredData);
        MBI_UnTransferredData UpdateUnTransferredData(MBI_UnTransferredData unTransferredData);
        bool DeleteUnTransferredData(MBI_UnTransferredData unTransferredData);
    }
}
