using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Interfaces
{
    interface IUserRules
    {
        Task<Usuario> Login(string user, string senha);
        string HashPassword(string senha);
    }
}
