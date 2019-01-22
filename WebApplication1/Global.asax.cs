using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApplication1.Security;
using WebApplication1.WEB;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            this.AuthenticateRequest += MvcApplication_AuthenticateRequest;
        }

        void MvcApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["putsCookie"];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket =
                FormsAuthentication.Decrypt(cookie.Value);
                FormsIdentity identity = new FormsIdentity(ticket);
                MvcUser user = new MvcUser(identity, new string[]{"Financeiro"});
                user.UserName = cookie.Name;
                string[] userData = ticket.UserData.Split(',');
                user.ID = Convert.ToInt32(userData[0]);
                user.IsAdm = Convert.ToBoolean(userData[1]);
                Context.User = user;
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(ProfissionalCustomModelBinder), new ProfissionalCustomModelBinder());
            ControllerBuilder.Current.SetControllerFactory(typeof(PutsControllerFactory));
        }
        //Método do WebServer que executa SEMPRE antes de qualquer Controller
        protected void Authenticate_Request()
        {
            HttpCookie cookie = Request.Cookies["putsCookie"];
            if(cookie != null)
            {
                FormsAuthenticationTicket ticket = 
                FormsAuthentication.Decrypt(cookie.Value);
                FormsIdentity identity = new FormsIdentity(ticket);
                MvcUser user = new MvcUser(identity, null);
                user.UserName = cookie.Name;
                string[] userData = ticket.UserData.Split(',');
                user.ID = Convert.ToInt32(userData[0]);
                user.IsAdm = Convert.ToBoolean(userData[1]);
                Context.User = user;
            }
        }


    }
}
