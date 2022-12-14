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
    public class FirmsService : IFirmsService
    {
        private readonly IFirmsDal _firmsDal;

        public FirmsService(IFirmsDal firmsDal)
        {
            _firmsDal = firmsDal;
        }

        public List<MBI_Firms> GetAllFirms()
        {
            return _firmsDal.GetList();
        }

        public MBI_Firms GetFirm(int firmId)
        {
            return _firmsDal.Get(t => t.FirmId == firmId);
        }

        public MBI_Firms AddFirm(MBI_Firms firm)
        {
            return _firmsDal.Add(firm);
        }

        public MBI_Firms UpdateFirm(MBI_Firms firm)
        {
            return _firmsDal.Update(firm);
        }

        public bool DeleteFirm(MBI_Firms firm)
        {
            return _firmsDal.Delete(firm);
        }
    }
}
