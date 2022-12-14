using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Abstract
{
    public interface IDocumentTypeService
    {
        List<MBI_DocumentType> GetAllDocumentTypes();
        MBI_DocumentType GetDocumentType(int documentTypeId);
        MBI_DocumentType AddDocumentType(MBI_DocumentType documentType);
        MBI_DocumentType UpdateDocumentType(MBI_DocumentType documentType);
        bool DeleteDocumentType(MBI_DocumentType documentType);
    }
}
