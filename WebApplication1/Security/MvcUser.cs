using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApplication1.Security
{
    public class MvcUser : GenericPrincipal
    {
        public MvcUser(IIdentity identity, string[] roles):base(identity,roles)
        {
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public bool IsAdm { get; set; }
    }
}