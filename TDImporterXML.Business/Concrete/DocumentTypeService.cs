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
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeDal _documentTypeService;

        public DocumentTypeService(IDocumentTypeDal documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        public List<MBI_DocumentType> GetAllDocumentTypes()
        {
            return _documentTypeService.GetList();
        }

        public MBI_DocumentType GetDocumentType(int documentTypeId)
        {
            return _documentTypeService.Get(t => t.DocumentTypeId == documentTypeId);
        }

        public MBI_DocumentType AddDocumentType(MBI_DocumentType documentType)
        {
            return _documentTypeService.Add(documentType);
        }

        public MBI_DocumentType UpdateDocumentType(MBI_DocumentType documentType)
        {
            return _documentTypeService.Update(documentType);
        }

        public bool DeleteDocumentType(MBI_DocumentType documentType)
        {
            return _documentTypeService.Delete(documentType);
        }
    }
}
