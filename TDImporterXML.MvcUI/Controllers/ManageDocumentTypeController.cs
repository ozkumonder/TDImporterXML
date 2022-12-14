using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Entities;
using TDImporterXML.MvcUI.ViewModel;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class ManageDocumentTypeController : Controller
    {
        private readonly IDocumentTypeService _documentTypeService;

        public ManageDocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        // GET: ManageDocumentType
        public ActionResult DocumentTypes()
        {
            var result = new DocumentTypeViewModel
            {
                DocumentTypes = _documentTypeService.GetAllDocumentTypes()
            };
            return View(result);
        }

        public ActionResult EditDocumentType(int id)
        {
            var result = new DocumentTypeViewModel
            {
                DocumentType = _documentTypeService.GetDocumentType(id)

            };
            return PartialView("_EditDocumentType", result);
        }
        [HttpPost]
        public ActionResult EditDocumentType(MBI_DocumentType documentType)
        {
            _documentTypeService.UpdateDocumentType(documentType);
            return RedirectToAction("DocumentTypes");
        }

        public ActionResult AddDocumentType(MBI_DocumentType documentType)
        {
            _documentTypeService.AddDocumentType(documentType);
            return RedirectToAction("DocumentTypes");
        }

        public ActionResult DeleteDocumentType(int id)
        {
            _documentTypeService.DeleteDocumentType(_documentTypeService.GetDocumentType(id));
            return RedirectToAction("DocumentTypes");
        }

    }
}