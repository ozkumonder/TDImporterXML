using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Core.DataAccess.EntityFramework;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;

namespace TDImporterXML.DataLayer.Concrete.EntityFramework
{
    public class EfUnTranferredDataDal : EfEntityRepositoryBase<MBI_UnTransferredData, TDImporterXMLContext>, IUnTransferredDataDal
    {
    }
}
