using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Core.DataAccess;
using TDImporterXML.Entities;

namespace TDImporterXML.DataLayer.Abstract
{
    public interface IFirmsDal : IEntityRepository<MBI_Firms>
    {
    }
}
