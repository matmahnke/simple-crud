using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Servico
    {
        public int ID { get; set; }
        public decimal Valor { get; set; }
        public int? Duracao { get; set; }
        public int QuartoID { get; set; }
        public int ClienteID { get; set; }
        public int ProfissionalID { get; set; }

        public virtual Quarto Quarto { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Profissional Profissional { get; set; }
    }

}
