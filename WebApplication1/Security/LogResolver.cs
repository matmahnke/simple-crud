using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Diagnostics;

namespace WebApplication1.Security
{
    public class LogResolver
    {
        private static LogResolver instance;
        public static LogResolver GetInstance()
        {
            if(instance == null)
            {
               instance = new LogResolver();
            }
            return instance;
        }

        private LogResolver() { }
        private static ILog iLog;
        //Roda uma vez por app (se o serviço do servidor for reiniciado, este construtor é invocado de novo
        static LogResolver()
        {
            string logValue = ConfigurationManager.AppSettings["Log"];
            Type log = Type.GetType(logValue);
            
            //WebApplication1.Security.TextLog
            //WebApplication1.Security.EmailLog
            iLog = Activator.CreateInstance(log) as ILog;
            Trace.Listeners.Add(iLog as TraceListener);
        }

        public ILog GetLogReference()
        {
            return iLog;
        }

    }
}