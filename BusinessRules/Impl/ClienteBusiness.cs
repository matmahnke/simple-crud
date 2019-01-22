using BusinessRules.Interfaces;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
    public class ClienteBusiness : BaseValidator<Cliente>, IEntityBase<Cliente>
    {
        public override void Validate(Cliente item)
        {
            if(string.IsNullOrWhiteSpace(item.Nome))
            {
                base.AddError(new ErrorField() { Message = "Favor, informe o nome", Field = "Nome" });
            }
            else if(item.Nome.Length > 60)
            {
                base.AddError(new ErrorField() { Message = "O nome não pode conter mais de 60 caracteres", Field = "Nome" });
            }
            if (string.IsNullOrWhiteSpace(item.Email))
            {
                base.AddError(new ErrorField() { Message = "Favor, informe o nome", Field = "Nome" });
            }
            else if (item.Email.Length > 70)
            {
                base.AddError(new ErrorField() { Message = "O nome não pode conter mais de 70 caracteres", Field = "Nome" });
            }
            base.Validate(item);
        }

        public void Add(Cliente item)
        {
            Validate(item);
            //Se chegou aqui, pode dale
            using(PutsContext db = new PutsContext())
            {
                db.Clientes.Add(item);
                db.SaveChanges();
            }
        }

        public void Edit(Cliente item)
        {
            Validate(item);
            //Se chegou aqui, pode dale
            using (PutsContext db = new PutsContext())
            {
                db.Entry<Cliente>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Cliente item)
        {
            using (PutsContext db = new PutsContext())
            {
                Cliente cliente = db.Clientes.Find(item.ID);
                if (cliente.Servicos == null || cliente.Servicos.Count == 0)
                {
                    db.Entry<Cliente>(cliente).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public Cliente GetByID(int id)
        {
            using(PutsContext db = new PutsContext())
            {
                return db.Clientes.Find(id);
            }
        }

        public IList<Cliente> GetAll()
        {
            using (PutsContext db = new PutsContext())
            {
                return db.Clientes.AsNoTracking().ToList();
            }
        }
    }
}
