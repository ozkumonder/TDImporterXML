using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TDImporterXML.Business.Scheduler;
using TDImporterXML.MvcUI.Infrastructure;
using TDImporterXML_MvcUI;

namespace TDImporterXML.MvcUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();
           
            DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;

            //JobScheduler.Start();
        }

        protected void Application_Error(object sender, EventArgs e) 
        {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cok = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cok == null)
                    return;
                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(cok.Value);
                string[] roller = bilet.UserData.Split(';');
                FormsIdentity id = new FormsIdentity(bilet);
                GenericPrincipal priReis = new GenericPrincipal(id, roller);
                Context.User = priReis;

            }
            catch (CryptographicException cex)
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}