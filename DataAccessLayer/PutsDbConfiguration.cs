using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PutsDbConfiguration : DbConfiguration
    {
        public PutsDbConfiguration()
        {
            this.AddInterceptor(new PutsCommandInterceptor());
        }
    }
}
