using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Profissional
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NomeGuerra { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal ValorHora { get; set; }
        public Etnia Etnia { get; set; }
        public bool EhVirgem { get; set; }
        public bool TemSiliconeCima { get; set; }
        public bool TemSiliconeBaixo { get; set; }
        public double Altura { get; set; }
        public float Peso { get; set; }
        
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
