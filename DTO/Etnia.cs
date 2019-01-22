using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Flags]
    public enum Etnia
    {
        Latina = 1,
        Asiatica = 2, 
        Brasileira = 4,
        AfroDescendente = 8,
        Sueca = 16,
        Arabe = 32,
        Vietnamita = 64
    }

}
