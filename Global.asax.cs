using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MedXplorer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticationRequest(object sender, EventArgs e)
        {
            var authcookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//create a cooKie and call from controller
            if (authcookie != null) //if true user
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authcookie.Value); //decrpyt their data
                if (authTicket != null && !authTicket.Expired)//and not null and not expired
                {
                    var roles = authTicket.UserData.Split(',');//then roles are separated
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);//roles are picked for give authorization
                }
            }
        }

    }
}
