using TDImporterXML.Core.DataAccess.EntityFramework;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;

namespace TDImporterXML.DataLayer.Concrete.EntityFramework
{
    public class EfFirmsDal : EfEntityRepositoryBase<MBI_Firms, TDImporterXMLContext>, IFirmsDal
    {
    }
}