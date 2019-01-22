using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication1.Security
{
    public class TextLog : TextWriterTraceListener, ILog
    {
        public void Log(string message)
        {
            this.Write(string.Format("{0} - {1} - {2}",DateTime.Now,message,(HttpContext.Current.User as MvcUser).UserName));
        }

        public void Log(Exception ex)
        {
            this.Write(string.Format("{0} - {1} - {2}", DateTime.Now, ex.Message + "\r\n" + ex.StackTrace, (HttpContext.Current.User as MvcUser).UserName));
        }

        protected override void Dispose(bool disposing)
        {
            this.Flush();
            base.Dispose(disposing);
        }
    }
}