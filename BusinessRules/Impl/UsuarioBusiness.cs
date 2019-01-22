using BusinessRules.Interfaces;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusinessRules.Impl
{
   public  class UsuarioBusiness : IEntityBase<Usuario>, IUserRules
    {
        public void Add(Usuario item)
        {
            //DEVERIA HAVER UMA VALIDAÇÃO DO USUÁRIO
            //SaltValue
            item.Senha = HashPassword(item.Senha);
            using (PutsContext db = new PutsContext())
            {
                db.Usuarios.Add(item);
                db.SaveChanges();
            }
        }

        public void Edit(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario item)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Login(string user, string senha)
        {
            //SaltValue
            string newSenha = HashPassword(senha);
            using (PutsContext db = new PutsContext())
            {
                return await db.Usuarios.FirstOrDefaultAsync(u => u.UserName == user && u.Senha == newSenha);
            }
        }

        public string HashPassword(string senha)
        {
            string previousSalt = "abc";
            string postSalt = "123";
            string newPassword = previousSalt + senha + postSalt;
            byte[] senhaEmBytes = Encoding.UTF8.GetBytes(newPassword);
            byte[] senhaHasheada = MD5.Create().ComputeHash(senhaEmBytes);
            return Convert.ToBase64String(senhaHasheada);
        }
    }
}
