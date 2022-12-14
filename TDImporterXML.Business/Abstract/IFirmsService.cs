using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Abstract
{
  public  interface IFirmsService
  {
      List<MBI_Firms> GetAllFirms();
      MBI_Firms GetFirm(int firmId);
      MBI_Firms AddFirm(MBI_Firms firm);
      MBI_Firms UpdateFirm(MBI_Firms firm);
      bool DeleteFirm(MBI_Firms firm);
  }
}
