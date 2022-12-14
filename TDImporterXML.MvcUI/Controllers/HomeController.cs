using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Business.Scheduler;
using TDImporterXML.Entities;

namespace TDImporterXML.MvcUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IFirmsService _firmsService;
        private readonly ILogoService _logoService;

        public HomeController(IFirmsService firmsService, ILogoService logoService)
        {
            _firmsService = firmsService;
            _logoService = logoService;
        }

        // GET: Home
        public ActionResult Index()
        {
          var fatura =  _logoService.GetInvoice(48276);
            var irsaliye = _logoService.GetDispatch(510886);
            var carifis = _logoService.GetArpVoucher(19293);
            var kasafis = _logoService.GetKsLine(6789);
            return View();
        }
    }
}