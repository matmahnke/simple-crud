using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Security;

namespace WebApplication1.WEB
{
    [Authorize]
    public class BaseAuthorizationController : Controller
    {
        protected MvcUser CurrentUser { get; set; }

        public BaseAuthorizationController(MvcUser user)
        {
            this.CurrentUser = user;
        }
    }
}