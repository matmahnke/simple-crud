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
    public class ProfissionalBusiness : BaseValidator<Profissional>, IEntityBase<Profissional>
    {
        public override void Validate(Profissional item)
        {
            //if(string.IsNullOrWhiteSpace(item.Nome))
            //{
            //    base.AddError(new ErrorField() { Message = "Favor, informe o nome", Field = "Nome" });
            //}
            //else if(item.Nome.Length > 60)
            //{
            //    base.AddError(new ErrorField() { Message = "O nome não pode conter mais de 60 caracteres", Field = "Nome" });
            //}
            //if (string.IsNullOrWhiteSpace(item.Email))
            //{
            //    base.AddError(new ErrorField() { Message = "Favor, informe o nome", Field = "Nome" });
            //}
            //else if (item.Email.Length > 70)
            //{
            //    base.AddError(new ErrorField() { Message = "O nome não pode conter mais de 70 caracteres", Field = "Nome" });
            //}
            base.Validate(item);
        }

        public void Add(Profissional item)
        {
            Validate(item);
            //Se chegou aqui, pode dale
            using(PutsContext db = new PutsContext())
            {
                db.Profissionais.Add(item);
                db.SaveChanges();
            }
        }

        public void Edit(Profissional item)
        {
            Validate(item);
            //Se chegou aqui, pode dale
            using (PutsContext db = new PutsContext())
            {
                db.Entry<Profissional>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Profissional item)
        {
            using (PutsContext db = new PutsContext())
            {
                Profissional profissional = db.Profissionais.Find(item.ID);
                if (profissional.Servicos == null || profissional.Servicos.Count == 0)
                {
                    db.Entry<Profissional>(profissional).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public Profissional GetByID(int id)
        {
            using(PutsContext db = new PutsContext())
            {
                return db.Profissionais.Find(id);
            }
        }

        public IList<Profissional> GetAll()
        {
            using (PutsContext db = new PutsContext())
            {
                return db.Profissionais.AsNoTracking().ToList();
            }
        }
    }
}
