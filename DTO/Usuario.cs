using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Usuario
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }
        public bool IsAdm { get; set; }
    }

}
