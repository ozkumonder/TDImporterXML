using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TDImporterXML.MvcUI.LogoHelper
{
    public static class LoginHelper
    {
        public static void LogIn(string userName, string rol, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(userName, true);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddHours(10), false, rol);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
        public static string GetSettings(string val)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        var settingList = ticket.UserData.Split(';');

                        if (settingList.Any(s => s.Contains($"{val}$")))
                        {
                            var setting = settingList.First(s => s.Contains($"{val}$")).Split('$');
                            return setting[1];
                        }
                    }
                }
            }

            return string.Empty;
        }


        public static void LogOut()
        {
            HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            FormsAuthentication.SignOut();

        }
    }
}