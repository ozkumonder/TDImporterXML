using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Entities;
using TDImporterXML.MvcUI.LogoHelper;

namespace TDImporterXML.MvcUI.Controllers
{
    public class ManageAccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IFirmsService _firmsService;

        public ManageAccountController(IUsersService usersService, IFirmsService firmsService)
        {
            _usersService = usersService;
            _firmsService = firmsService;
        }

        // GET: ManageAccount
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(MBI_Users model)
        {
            
                var result = _usersService.GetAllUsers().FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                var firmNr = _firmsService.GetAllFirms().FirstOrDefault(x => x.IsDefault == true).FirmNr;
                if (result != null)
                {
                    var settings = new StringBuilder();

                    settings.Append($"sUserName${result.UserName};");
                    settings.Append($"sPassword${result.Password};");
                    settings.Append($"sLogoUserName${result.LogoUserName};");
                    settings.Append($"sLogoPassword${result.LogoPassword};");
                    settings.Append($"sFirm${firmNr};");
                    LoginHelper.LogIn(model.UserName, settings.ToString(), false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //this.AddToastMessage("Hata", "Giriş Yapılamadı /r Kullanıcı Bilgilerinizi Kontrol Ediniz...",ToastType.Error);
                    ViewBag.LoginError = "Kullanıcı Bilgilerinizi Kontrol Ediniz...";
                    return View("Login");
                }
            

        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}