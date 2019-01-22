using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Security
{
    public interface ILog
    {
        void Log(string message);
        void Log(Exception ex);
    }
}
