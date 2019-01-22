using BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessRules.Impl
{
    public class ServicoBusiness : IServicoRules
    {
        public void AbrirServico(Servico servico)
        {
            if(servico.Duracao.HasValue && servico.Duracao > 240)
            {
                throw new Exception("Duração excedida para o programa.");
            }
            using (PutsContext db = new PutsContext())
            {
                Quarto q = db.Quartos.Find(servico.QuartoID);
                if (q.EstaOcupado)
                {
                    throw new PutsException("Quarto ocupado!");
                }
                q.EstaOcupado = true;
                db.Servicos.Add(servico);
                db.SaveChanges();
            }
        }

        public void FecharServico(Servico svc)
        {
            using (PutsContext db = new PutsContext())
            {
                Servico servico = db.Servicos.Find(svc.ID);
                Quarto q = db.Quartos.Find(servico.QuartoID);
                Profissional profissional = db.Profissionais.Find(servico.ProfissionalID);
                double valorBase = 50;
                double acrescimos = 0;
                if(profissional.EhVirgem)
                {
                    acrescimos += 1000;
                    profissional.EhVirgem = false;
                }
                if(profissional.Etnia.HasFlag(Etnia.Sueca) && profissional.Altura > 1.80)
                {
                    acrescimos += 300;
                }
                double valor = (double)profissional.ValorHora * servico.Duracao.Value + valorBase + acrescimos;
                servico.Valor = (decimal)valor;
                q.EstaOcupado = false;
                db.SaveChanges();
            }
        }
    }
}
