using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Security
{
    public class EmailLog : EmailTraceListener, ILog
    {
        public void Log(string message)
        {
            this.Write(message);
        }

        public void Log(Exception ex)
        {
            this.Write(ex.Message);
        }
    }
}